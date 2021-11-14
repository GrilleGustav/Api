// <copyright file="JwtHandler.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Models.Request;
using Google.Apis.Auth;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Api.Models;
using Models.Response;
using Models.Response.User;

namespace Api.Jwt
{
  public class JwtHandler
  {
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;
    private readonly IConfigurationSection _googleSettings;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public JwtHandler(IConfiguration configuration, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
      _userManager = userManager;
      _configuration = configuration;
      _jwtSettings = _configuration.GetSection("JwtSettings");
      _googleSettings = _configuration.GetSection("GoogleAuthSettings");
      _roleManager = roleManager;
    }

    /// <summary>
    /// Get Claims user from user. Email and roles.
    /// </summary>
    /// <param name="user">Current user object.</param>
    /// <returns>List of current user claims.</returns>
    public async Task<List<Claim>> GetClaims(User user)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, user.Email)
      };

      var roles = await _userManager.GetRolesAsync(user);

      foreach (var roleName in roles)
      {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
          foreach (var claim in await _roleManager.GetClaimsAsync(await _roleManager.FindByNameAsync(roleName)))
            claims.Add(new Claim(ClaimTypes.Role, claim.Value));
        }
      }

      return claims;
    }

    /// <summary>
    /// Revoke token.
    /// </summary>
    /// <param name="token">Refresh token</param>
    /// <param name="ipAddress">Client ipaddress</param>
    /// <returns></returns>
    public async Task<ErrorResponse> RevokeToken(string token, string ipAddress)
    {
      ErrorResponse response = new ErrorResponse();
      User user = _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));

      // return false if no user found.
      if (user == null)
      {
        response.AddError(errorCode: "revoke.1", errorMessage: "No user found.");
        return response;
      }

      var refreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == token);

      // return false if token is not active
      if (!refreshToken.IsActive)
      {
        response.AddError(errorCode: "revoke.2", errorMessage: "Token is expired");
      }

      // revoke token and save
      refreshToken.Revoked = DateTime.UtcNow;
      refreshToken.RevokedByIp = ipAddress;
      var result = await _userManager.UpdateAsync(user);

      if (!result.Succeeded)
      {
        response.AddError(errorCode: "revoke.3", errorMessage: "Database error.");
      }

      return response;
    }

    /// <summary>
    /// Generate access token and refresh token.
    /// </summary>
    /// <param name="user">Current user.</param>
    /// <param name="ipAddress">Ipaddress from current user.</param>
    /// <param name="httpContext">HttpContext instance.</param>
    /// <param name="expiration">Access token lifetime.</param>
    /// <returns>Access token.</returns>
    public async Task<TokenResponse> GenerateTokens(User user, string ipAddress, HttpContext httpContext, double expiration = 0)
    {
      string accessToken = await GenerateAccessToken(user);

      RefreshToken refreshToken = GenerateRefreshToken(ipAddress, user.Id, expiration);

      //var cookieOptions = new CookieOptions
      //{
      //  HttpOnly = true,
      //  Secure = false,
      //  Expires = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("refreshTokenExpireInMinutes").Value))
      //};
      //httpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

      if (user.RefreshTokens == null)
        user.RefreshTokens = new List<RefreshToken>();

      user.RefreshTokens.Add(refreshToken);
      await _userManager.UpdateAsync(user);

      return new TokenResponse(accessToken, refreshToken.Token);
    }

    public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthRequest externalAuth)
    {
      try
      {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
          Audience = new List<string>() { _googleSettings.GetSection("clientId").Value }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
        return payload;
      }
      catch (Exception ex)
      {
        //log an exception
        return null;
      }
    }

    public RefreshToken GetValidRefreshToken(string token, User user)
    {
      if (user == null)
        return null;

      var existingToken = user.RefreshTokens.FirstOrDefault(x => x.Token == token);
      return IsRefreshTokenValid(existingToken) ? existingToken : null;
    }

    /// <summary>
    /// Get signing credentials.
    /// </summary>
    /// <returns>SigningCreadentials.</returns>
    private SigningCredentials GetSigningCredentials()
    {
      var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
      var secret = new SymmetricSecurityKey(key);

      return new SigningCredentials(secret, SecurityAlgorithms.HmacSha512);
    }

    /// <summary>
    /// Generate JASON Web Token.
    /// </summary>
    /// <param name="user">Current user.</param>
    /// <returns>JSON Web Token.</returns>
    private async Task<string> GenerateAccessToken(User user)
    {
      var signingCredentials = GetSigningCredentials();
      var claims = await GetClaims(user);
      var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
      var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

      return token;
    }

    /// <summary>
    /// Generate Refresh Token.
    /// </summary>
    /// <param name="ipAddress">The IP address of the token requirement.</param>
    /// <param name="userId">Current user id.</param>
    /// <param name="expiration">Expiration of refreshtoken.</param>
    /// <returns>Refesh-Token.</returns>
    private RefreshToken GenerateRefreshToken(string ipAddress, Guid userId, double expiration = 0)
    {
      using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
      {
        var randomBytes = new byte[64];
        rngCryptoServiceProvider.GetBytes(randomBytes);
        return new RefreshToken
        {
          Token = Convert.ToBase64String(randomBytes),
          Expires = (expiration == 0) ? DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("refreshTokenExpireInMinutes").Value)) : DateTime.Now.AddMinutes(expiration), // Todo Settings.
          Created = DateTime.UtcNow,
          CreatedByIp = ipAddress,
          UserId = userId
        };
      }
    }

    /// <summary>
    /// Get token options.
    /// </summary>
    /// <param name="signingCredentials">Credentials with key and secret.</param>
    /// <param name="claims">Current user claims</param>
    /// <returns>Token options.</returns>
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
      var tokenOptions = new JwtSecurityToken(
        issuer: _jwtSettings.GetSection("validIssuer").Value,
        audience: _jwtSettings.GetSection("validAudience").Value,
        claims: claims,
        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
        signingCredentials: signingCredentials);

      return tokenOptions;
    }

    /// <summary>
    /// Check if token is aktive and not expired.
    /// </summary>
    /// <param name="existingToken">Token.</param>
    /// <returns>True if token is Valid.</returns>
    private bool IsRefreshTokenValid(RefreshToken existingToken)
    {
      if (existingToken.IsActive)
        return true;

      return false;
    }
  }
}
