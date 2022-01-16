using Api.Jwt;
using Api.Models;
using AutoMapper;
using Entities.Models.Account;
using Entities.Models.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Request;
using Models.Request.User;
using Models.Response;
using Models.Response.Group;
using Models.Response.User;
using Models.View.Settings.Role;
using Models.View.User;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;
    private readonly JwtHandler _jwtHandler;

    public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IEmailService emailService, IConfiguration configuration, JwtHandler jwtHandler)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _mapper = mapper;
      _emailService = emailService;
      _configuration = configuration;
      _jwtSettings = _configuration.GetSection("JwtSettings");
      _jwtHandler = jwtHandler;

    }

    [AllowAnonymous]
    [HttpGet("[action]")]
    public ActionResult<UsersSettingsResponse> GetAll()
    {
      return Ok(new UsersSettingsResponse(_userManager.Users.ToList()));
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<UserSettingsResponse>> GetOne(string id)
    {
      UserSettingsResponse userSettingsResponse = new UserSettingsResponse();
      if (id == null)
        return BadRequest();

      Entities.Models.Account.User user = await _userManager.FindByIdAsync(id);

      if (user == null)
      {
        userSettingsResponse.AddError(errorCode: "2");
        return Ok(userSettingsResponse);
      }
      try
      {
        var a = new UserSettingsResponse(_mapper.Map<UserDetailViewModel>(user));
      }
      catch(Exception e)
      {
        var er = e;
      }

      return Ok(new UserSettingsResponse(_mapper.Map<UserDetailViewModel>(user)));
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<UserSettingsResponse>> Update([FromBody] UserDetailRequest detailRequest)
    {
      UserSettingsResponse userSettingsResponse = new UserSettingsResponse();
      if (detailRequest == null)
        return BadRequest();

      if (!ModelState.IsValid)
        return BadRequest();

      User userOriginal = await _userManager.FindByIdAsync(detailRequest.Id);
      
      if (userOriginal == null)
      {
        userSettingsResponse.AddError(errorCode: "2", errorMessage: "User not found.");
        return Ok(userSettingsResponse);
      }

      var email = userOriginal.Email;

      if (userOriginal.ConcurrencyStamp != detailRequest.ConcurrencyStamp)
      {
        userSettingsResponse.AddError(errorCode: "11", errorMessage: "This record was beeing editied by another user");
        userSettingsResponse.User = _mapper.Map<UserDetailViewModel>(userOriginal);
        userSettingsResponse.IsSuccess = false;
        return userSettingsResponse;
      }

      User user = _mapper.Map<UserDetailRequest, User>(detailRequest, userOriginal);

      if (userOriginal.Email != email)
      {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        EmailMessage emailMessage = await _emailService.GenerateRegisterConfirmMessage(user, detailRequest.ClientUrl, token);
        await _emailService.SendMail(emailMessage);
        user.EmailConfirmed = false;
      }

      IdentityResult result = await _userManager.UpdateAsync(user);

      if (!result.Succeeded)
      {
        foreach(IdentityError error in result.Errors)
        {
          userSettingsResponse.AddError(errorCode: error.Code, errorMessage: error.Description);
        }
        return Ok(userSettingsResponse);
      }

      userSettingsResponse.IsSuccess = true;
      return Ok(userSettingsResponse);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<GeneratedUrlTokenResponse>> EmailChangeToken([FromBody] TokenUrlRequest tokenRequest)
    {
      GeneratedUrlTokenResponse response = new GeneratedUrlTokenResponse();
      if (string.IsNullOrEmpty(tokenRequest.Id) || string.IsNullOrEmpty(tokenRequest.ClientUrl))
        return BadRequest();
      User user = await _userManager.FindByIdAsync(tokenRequest.Id);

      if (user == null)
      {
        response.AddError(errorCode: "2", errorMessage: "User not found.");
      }

      var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

      EmailMessage emailMessage = await _emailService.GenerateRegisterConfirmMessage(user, tokenRequest.ClientUrl, token);
      await _emailService.SendMail(emailMessage);

      var param = new Dictionary<string, string>
      {
        {"token", token },
        {"email", user.Email }
      };
      response.Url = QueryHelpers.AddQueryString(tokenRequest.ClientUrl, param);
      response.IsSuccess = true;

      return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
      string refreshToken = request.RefreshToken;
      User user = _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == refreshToken && y.UserId == x.Id));

      var existingRefreshToken = _jwtHandler.GetValidRefreshToken(refreshToken, user);
      if (existingRefreshToken == null)
        return BadRequest(new { message = "Ivalid token." });

      existingRefreshToken.RevokedByIp = IpAddress();
      existingRefreshToken.Revoked = DateTime.UtcNow;

      return Ok(await _jwtHandler.GenerateTokens(user, IpAddress(), HttpContext, 0));
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> RevokeToken([FromBody] RevokeTokenRequest request)
    {
      // accept refresh token from request body or cookie.
      string token = request.Token ?? Request.Cookies["refreshToken"];

      if (string.IsNullOrEmpty(token))
        return BadRequest(new { message = "token is required." });

      var response = await _jwtHandler.RevokeToken(token, IpAddress());

      if (response.Errors.Count == 0)
        response.IsSuccess = true;

      return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<RolesSettingsResponse>> GetUserRoles(string id)
    {
      RolesSettingsResponse response = new RolesSettingsResponse();
      if (id == null)
        return BadRequest();

      User user = await _userManager.FindByIdAsync(id);
      IList<string> roleNames = await _userManager.GetRolesAsync(user);
      List<Role> roles = await _roleManager.Roles.Where(x => roleNames.Any(y => y == x.Name)).ToListAsync();
      response.Roles = roles;

      response.IsSuccess = true;
      return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> UpdateUserRoles([FromBody] UserRolesUpdateRequest request)
    {
      ErrorResponse response = new ErrorResponse();
      if (!ModelState.IsValid)
        return BadRequest();

      User user = await _userManager.FindByIdAsync(request.UserId);
      IList<string> userRoles = await _userManager.GetRolesAsync(user);

      List<Role> userRoles2 = new List<Role>();
      foreach ( string roleName in userRoles)
      {
        userRoles2.Add(new Role(name: roleName, description: null));
      }

      List<Role> d = userRoles2.Where(x => !request.Roles.Any(y => y.Name == x.Name)).ToList();
      List<Role> a = request.Roles.Where(x => !userRoles2.Any(y => y.Name == x.Name)).ToList();
      foreach (Role role in d)
      {
        await _userManager.RemoveFromRoleAsync(user, role.Name);
      }

      await _userManager.AddToRolesAsync(user, a.Select(x => x.Name));

      response.IsSuccess = true;
      return Ok(response);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ClaimsSettingsResponse>> GetUserClaims(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        return BadRequest();

      ClaimsSettingsResponse response = new ClaimsSettingsResponse();
      User user = await _userManager.FindByIdAsync(id);
      if (user == null)
      {
        response.AddError(errorCode: "2", errorMessage: "User not found.");
        return Ok(response);
      }

      IList<Claim> claims = await _userManager.GetClaimsAsync(user);
      return Ok(new ClaimsSettingsResponse(_mapper.Map<IList<ClaimViewModel>>(claims)));
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> UpdateUserClaims([FromBody] UserClaimsUpdateRequest request)
    {
      ErrorResponse response = new ErrorResponse();
      if (!ModelState.IsValid)
        return BadRequest();

      User user = await _userManager.FindByIdAsync(request.UserId);
      IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
      IList<Claim> claims = new List<Claim>();
      foreach(string claim in request.Claims)
      {
        claims.Add(new Claim(ClaimTypes.Role, claim));
      }

      List<Claim> d = userClaims.Where(x => !claims.Any(y => y.Value == x.Value)).ToList();
      List<Claim> a = claims.Where(x => !userClaims.Any(y => y.Value == x.Value)).ToList();

      await _userManager.RemoveClaimsAsync(user, d);
      await _userManager.AddClaimsAsync(user, a);

      response.IsSuccess = true;
      return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> AddUserRole([FromBody] UserRoleAddRequest request)
    {
      ErrorResponse response = new ErrorResponse();
      if (!ModelState.IsValid)
        return BadRequest();
      User user = await _userManager.FindByIdAsync(request.UserId);
      if (user == null)
      {
        response.AddError(errorCode: "2", errorMessage: "User not found.");
        return Ok(response);
      }

      IdentityResult result = await _userManager.AddToRoleAsync(user, request.RoleName);
      if (!result.Succeeded)
      {
        foreach (IdentityError error in result.Errors)
        {
          response.AddError(errorCode: error.Code, errorMessage: error.Description);
        }
        return Ok(response);
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> RemoveRole([FromBody] UserRoleRemoveRequest request)
    {
      ErrorResponse response = new ErrorResponse();
      if (!ModelState.IsValid)
        return BadRequest();
      User user = await _userManager.FindByIdAsync(request.UserId);
      if (user == null)
      {
        response.AddError(errorCode: "2", errorMessage: "User not found.");
        return Ok(response);
      }

      IdentityResult result = await _userManager.RemoveFromRoleAsync(user, request.RoleName);
      if (!result.Succeeded)
      {
        foreach (IdentityError error in result.Errors)
        {
          response.AddError(errorCode: error.Code, errorMessage: error.Description);
        }
        return Ok(response);
      }

      response.IsSuccess = true;
      return Ok(response);
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
