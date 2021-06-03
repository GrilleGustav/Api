// <copyright file="AccountsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Api.Jwt;
using AutoMapper;
using Contracts;
using Entities.Models.Account;
using Entities.Models.Email;
using Entities.Models.Settings.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Models.Request;
using Models.Response;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
  
  [ApiController]
  [Route("[controller]")]
  public class AccountsController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly JwtHandler _jwtHandler;
    private readonly IEmailService _emailService;
    private readonly IRepositoryManager _repositoryManager;

    public AccountsController(UserManager<User> userManager, IMapper mapper, JwtHandler jwtHandler, IEmailService emailService, IRepositoryManager repositoryManager)
    {
      _userManager = userManager;
      _mapper = mapper;
      _jwtHandler = jwtHandler;
      _emailService = emailService;
      _repositoryManager = repositoryManager;
    }

    /// <summary>
    /// Register user and send confirmation email.
    /// </summary>
    /// <param name="registrationRequest">User registration request.</param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterUser([FromBody] RegistrationRequest registrationRequest)
    {
      if (registrationRequest == null || !ModelState.IsValid)
        return BadRequest();

      var user = _mapper.Map<User>(registrationRequest);

      var result = await _userManager.CreateAsync(user, registrationRequest.Password);

      if (!result.Succeeded)
      {
        var errors = result.Errors.Select(e => e.Description);
        return BadRequest(new RegistrationResponse { Errors = errors });
      }

      var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
      EmailMessage emailMessage = await this.GenerateRegisterConfirmMessage(user, registrationRequest.ClientURI, token);
      await _emailService.SendMail(emailMessage);

      await _userManager.AddToRoleAsync(user, "User");

      return StatusCode(201);
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult<ErrorResponse>> UserDelete([FromQuery] string email)
    {
      var user = await _userManager.FindByEmailAsync(email);
      if (user == null)
        return BadRequest(new ErrorResponse("User.1", "User with emial not found"));
      var result = await _userManager.DeleteAsync(user);
      if (result.Succeeded)
        return Ok(new ErrorResponse());
      else
        return Ok(new ErrorResponse(errorCode: "User.2", errorMessage: "User can't delete."));
    }

    /// <summary>
    /// Check if user with email already exist.
    /// </summary>
    /// <param name="emailExistRequest">User account email</param>
    /// <returns>Returns httpStatusCode 200, user with email already exist or or httpStatusCode 400.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<EmailExistResponse>> UserAccountExist([FromBody]EmailExistRequest emailExistRequest)
    {
      if (emailExistRequest != null && ModelState.IsValid)
      {
        if (!string.IsNullOrEmpty(emailExistRequest.Email))
        {
          User user = await _userManager.FindByEmailAsync(emailExistRequest.Email);
          if (user == null)
            return Ok(new EmailExistResponse(exist: false));
          else
            return Ok(new EmailExistResponse(exist: true));
        }
        else
          return BadRequest();
      }
      else
        return BadRequest();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest authenticationRequest)
    {
      var user = await _userManager.FindByNameAsync(authenticationRequest.Email);
      if (user == null)
        return BadRequest("Invalid Request");

      if (!await _userManager.IsEmailConfirmedAsync(user))
        return Unauthorized();

      if (!await _userManager.CheckPasswordAsync(user, authenticationRequest.Password))
      {
        await _userManager.AccessFailedAsync(user);

        if (await _userManager.IsLockedOutAsync(user))
        {
          //var content = $"Your account is locked out. To reset the password click this link: {userForAuthentication.clientURI}";
          //var message = new Message(new string[] { userForAuthentication.Email }, "Locked out account information", content, null);
          //await _emailSender.SendEmailAsync(message);

          return Unauthorized();
        }

        return Unauthorized();
      }

      if (await _userManager.GetTwoFactorEnabledAsync(user))
        return await GenerateOTPFor2StepVerification(user);
      string token;
      if (authenticationRequest.StayLoggedIn)
        token = await _jwtHandler.GenerateToken(user, 525600);
      else
        token = await _jwtHandler.GenerateToken(user, 0);

      await _userManager.ResetAccessFailedCountAsync(user);
      //List<string> test = new List<string>();
      //test.Add("User");
      //test.Add("Administrator");
      //var a = await _userManager.AddToRolesAsync(user, test);

      return Ok(new AuthenticationResponse { IsAuthSuccessful = true, Token = token });
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> TwoStepVerification([FromBody] TwoFactorRequest twoFactorRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var user = await _userManager.FindByEmailAsync(twoFactorRequest.Email);
      if (user == null)
        return BadRequest();

      var validVerification = await _userManager.VerifyTwoFactorTokenAsync(user, twoFactorRequest.Provider, twoFactorRequest.Token);
      if (!validVerification)
        return BadRequest();

      var token = await _jwtHandler.GenerateToken(user);
      return Ok(new AuthenticationResponse { IsAuthSuccessful = true, Token = token });
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<ErrorResponse>> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
    {
      var user = await _userManager.FindByEmailAsync(email);
      if (user == null)
        return BadRequest(new ErrorResponse(errorCode: "account.1", errorMessage: "User not found."));

      var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
      if (!confirmResult.Succeeded)
        return Ok(new ErrorResponse(errorCode: "account.2", errorMessage: "confirm email fails."));

      return Ok(new ErrorResponse());
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> ResendEmailConfirmLink([FromBody] EmailConfirmLinkRequest request)
    {
      if (request == null)
        return BadRequest(new ErrorResponse(errorCode: "account.3"));
      else if (request.Email == null || request.ClientURI == null)
        return BadRequest(new ErrorResponse(errorCode: "account.4"));

      var user = await _userManager.FindByEmailAsync(request.Email);

      var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

      EmailMessage emailMessage = await this.GenerateRegisterConfirmMessage(user, request.ClientURI, token);
      await _emailService.SendMail(emailMessage);
      return Ok(new ErrorResponse());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest forgotPasswordDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
      if (user == null)
        return BadRequest("Invalid Request");

      var token = await _userManager.GeneratePasswordResetTokenAsync(user);
      var param = new Dictionary<string, string>
      {
        {"token", token },
        {"email", forgotPasswordDto.Email }
      };

      var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);

      //var message = new Message(new string[] { "codemazetest@gmail.com" }, "Reset password token", callback, null);
      //await _emailSender.SendEmailAsync(message);

      return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var user = await _userManager.FindByEmailAsync(resetPasswordRequest.Email);
      if (user == null)
        return BadRequest("Invalid Request");

      var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordRequest.Token, resetPasswordRequest.Password);
      if (!resetPassResult.Succeeded)
      {
        var errors = resetPassResult.Errors.Select(e => e.Description);

        return BadRequest(new { Errors = errors });
      }

      await _userManager.SetLockoutEndDateAsync(user, new DateTime(2000, 1, 1));

      return Ok();
    }

    [HttpPost("ExternalLogin")]
    public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthRequest externalAuth)
    {
      var payload = await _jwtHandler.VerifyGoogleToken(externalAuth);
      if (payload == null)
        return BadRequest("Invalid External Authentication.");

      var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

      var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
      if (user == null)
      {
        user = await _userManager.FindByEmailAsync(payload.Email);

        if (user == null)
        {
          user = new User { Email = payload.Email, UserName = payload.Email };
          await _userManager.CreateAsync(user);

          //prepare and send an email for the email confirmation

          await _userManager.AddToRoleAsync(user, "Viewer");
          await _userManager.AddLoginAsync(user, info);
        }
        else
        {
          await _userManager.AddLoginAsync(user, info);
        }
      }

      if (user == null)
        return BadRequest("Invalid External Authentication.");

      //check for the Locked out account

      var token = await _jwtHandler.GenerateToken(user);
      return Ok(new AuthenticationResponse { Token = token, IsAuthSuccessful = true });
    }

    private async Task<IActionResult> GenerateOTPFor2StepVerification(User user)
    {
      var providers = await _userManager.GetValidTwoFactorProvidersAsync(user);
      if (!providers.Contains("Email"))
        return Unauthorized(new AuthenticationResponse { ErrorMessage = "Invalid 2-Step Verification Provider." });

      var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
      //var message = new Message(new string[] { user.Email }, "Authentication token", token, null);
      //await _emailSender.SendEmailAsync(message);

      return Ok(new AuthenticationResponse { Is2StepVerificationRequired = true, Provider = "Email" });
    }

    private async Task<EmailMessage> GenerateRegisterConfirmMessage(User user, string clientURI, string token)
    {
      EmailTemplate emailTemplate = await _repositoryManager.EmailTemplate.FindByCondition(x => x.EmailTemplateType == Enums.EmailTemplateType.Register && x.Default == true, false).SingleOrDefaultAsync();
      var param = new Dictionary<string, string>
      {
        {"token", token },
        {"email", user.Email }
      };
      var callback = QueryHelpers.AddQueryString(clientURI, param);
      string content = emailTemplate.Content;
      content = content.Replace("{Date}", DateTime.Now.ToString());
      content = content.Replace("{RegisterConfirm}", callback);
      content = content.Replace("{Firstname}", user.Firstname);
      content = content.Replace("{Lastname}", user.Lastname);
      content = content.Replace("{UserName}", user.UserName);

      EmailMessage emailMessage = new EmailMessage(new string[] { user.Email }, "developper@grillegustav.de", "Confirm Registration", content);
      return emailMessage;
    }
  }
}
