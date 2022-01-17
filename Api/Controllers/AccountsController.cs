// <copyright file="AccountsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Api.Jwt;
using AutoMapper;
using Contracts;
using Entities.Models.Account;
using Entities.Models.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Models.Request;
using Models.Response;
using Models.Response.User;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
  /// <summary>
  /// Controller for authentication request.
  /// </summary>
  [Authorize]
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
    [AllowAnonymous]
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
      EmailMessage emailMessage = await _emailService.GenerateRegisterConfirmMessage(user, registrationRequest.ClientURI, token);
      await _emailService.SendMail(emailMessage);

      await _userManager.AddToRoleAsync(user, "User");

      return StatusCode(201);
    }

    /// <summary>
    /// Delete user from database.
    /// !!! User can't restored. !!!
    /// </summary>
    /// <param name="email">Email of user.</param>
    /// <returns>Return true, otherwise return one or more errors.</returns>
    [HttpDelete("[action]")]
    public async Task<ActionResult<ErrorResponse>> UserDelete([FromQuery] string email)
    {
      ErrorResponse errorResponse = new ErrorResponse();

      // Get user from database.
      var user = await _userManager.FindByEmailAsync(email);

      // If null user with email dosn't exist.
      if (user == null)
      {
        errorResponse.AddError(errorCode: "2", "User with emial not found");
        return BadRequest(errorResponse);
      }

      // Delete user from database. If fails returns some errors.
      var result = await _userManager.DeleteAsync(user);

      // If result true, set response true and return to frontend.
      if (result.Succeeded)
      {
        errorResponse.IsSuccess = true;
      }
      // Set errors to response.
      else
        errorResponse.AddError(errorCode: "7", "User can't delete.");
      return Ok(errorResponse);
    }

    /// <summary>
    /// Check if user with email already exist.
    /// </summary>
    /// <param name="emailExistRequest">User account email</param>
    /// <returns>Returns httpStatusCode 200, user with email already exist or or httpStatusCode 400.</returns>
    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<ActionResult<EmailExistResponse>> UserAccountExist([FromBody] EmailExistRequest emailExistRequest)
    {
      if (emailExistRequest != null && ModelState.IsValid)
      {
        if (!string.IsNullOrEmpty(emailExistRequest.Email))
        {
          User user = await _userManager.FindByEmailAsync(emailExistRequest.Email);
          if (user == null)
            return Ok(new EmailExistResponse(exist: false));
          else
          {
            if (!string.IsNullOrEmpty(emailExistRequest.Id))
            {
              if (user.Id == Guid.Parse(emailExistRequest.Id))
                return Ok(new EmailExistResponse(exist: false));
              else
                return Ok(new EmailExistResponse(exist: true));
            }
            else
              return Ok(new EmailExistResponse(exist: true));
          }
        }
        else
          return BadRequest();
      }
      else
        return BadRequest();
    }

    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="authenticationRequest">Required login data. Username, password</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest authenticationRequest)
    {
      // Find user by username.
      var user = await _userManager.FindByNameAsync(authenticationRequest.Email);
      if (user == null)
        return BadRequest("Invalid Request");
      
      // Check if email is already confirmed.
      if (!await _userManager.IsEmailConfirmedAsync(user))
        return Unauthorized();

      // Check user pasword.
      if (!await _userManager.CheckPasswordAsync(user, authenticationRequest.Password))
      {
        // If password is wrong. Increase access failed counter.
        await _userManager.AccessFailedAsync(user);

        // Check if user acccount is locked.
        if (await _userManager.IsLockedOutAsync(user))
        {
          //var content = $"Your account is locked out. To reset the password click this link: {userForAuthentication.clientURI}";
          //var message = new Message(new string[] { userForAuthentication.Email }, "Locked out account information", content, null);
          //await _emailSender.SendEmailAsync(message);

          return Unauthorized();
        }

        return Unauthorized();
      }

      // Check if twofactor is enabled on this user. 
      if (await _userManager.GetTwoFactorEnabledAsync(user))
        return await GenerateOTPFor2StepVerification(user);
      TokenResponse tokenResponse;

      // Generate access token and refresh token. If stay logged in is enabled user need to login after one year again.
      if (authenticationRequest.StayLoggedIn)
        tokenResponse = await _jwtHandler.GenerateTokens(user, IpAddress(), HttpContext, 525600);
      else
        tokenResponse = await _jwtHandler.GenerateTokens(user, IpAddress(), HttpContext, 0);

      // If user has succesfully logged in access fail  counter will be reset.
      await _userManager.ResetAccessFailedCountAsync(user);

      // return successfully locked in user.
      return Ok(new AuthenticationResponse { IsAuthSuccessful = true, Token = tokenResponse.Token, RefreshToken = tokenResponse.RefreshToken });
    }

    [AllowAnonymous]
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

      TokenResponse tokenResponse = await _jwtHandler.GenerateTokens(user, IpAddress(), HttpContext, 0);
      return Ok(new AuthenticationResponse { IsAuthSuccessful = true, Token = tokenResponse.Token, RefreshToken = tokenResponse.RefreshToken });
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<ErrorResponse>> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      var user = await _userManager.FindByEmailAsync(email);
      if (user == null)
      {
        errorResponse.AddError(errorCode: "2", "User not found.");
        return BadRequest(errorResponse);
      }

      var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
      if (!confirmResult.Succeeded)
      {
        errorResponse.AddError(errorCode: "8", "Confirm email fails.");
        return Ok(errorResponse);
      }

      return Ok(new ErrorResponse());
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> ResendEmailConfirmLink([FromBody] EmailConfirmLinkRequest request)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      if (request == null)
      {
        errorResponse.AddError(errorCode: "9");
        return BadRequest(errorResponse);
      }
      else if (request.Email == null || request.ClientURI == null)
      {
        errorResponse.AddError(errorCode: "10");
        return BadRequest(errorResponse);
      }

      var user = await _userManager.FindByEmailAsync(request.Email);

      var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

      EmailMessage emailMessage = await _emailService.GenerateRegisterConfirmMessage(user, request.ClientURI, token);
      await _emailService.SendMail(emailMessage);
      return Ok(new ErrorResponse());
    }

    // ToDo: ErrorResponse
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

    // ToDo: ErrorResponse
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

      TokenResponse tokenResponse = await _jwtHandler.GenerateTokens(user, IpAddress(), HttpContext, 0);
      return Ok(new AuthenticationResponse { Token = tokenResponse.Token, RefreshToken = tokenResponse.RefreshToken, IsAuthSuccessful = true });
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

    /// <summary>
    /// Get IP from request.
    /// </summary>
    /// <returns>Ip-Address.</returns>
    private string IpAddress()
    {
      if (Request.Headers.ContainsKey("X-Forwarded-For"))
        return Request.Headers["X-Forwarded-For"];
      else
      {
        var test = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        return test;
      }
    }
  }
}
