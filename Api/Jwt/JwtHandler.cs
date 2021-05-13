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

namespace Api.Jwt
{
  public class JwtHandler
  {
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;
    private readonly IConfigurationSection _googleSettings;
    private readonly UserManager<User> _userManager;

    public JwtHandler(IConfiguration configuration, UserManager<User> userManager)
    {
      _userManager = userManager;
      _configuration = configuration;
      _jwtSettings = _configuration.GetSection("JwtSettings");
      _googleSettings = _configuration.GetSection("GoogleAuthSettings");
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
      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      return claims;
    }

    /// <summary>
    /// Get token options.
    /// </summary>
    /// <param name="signingCredentials">Credentials with key and secret.</param>
    /// <param name="claims">Current user claims</param>
    /// <returns>Token options.</returns>
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims, double expiration = 0)
    {
      var tokenOptions = new JwtSecurityToken(
        issuer: _jwtSettings.GetSection("validIssuer").Value,
        audience: _jwtSettings.GetSection("validAudience").Value,
        claims: claims,
        expires: (expiration == 0) ? DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)) : DateTime.Now.AddMinutes(expiration),
        signingCredentials: signingCredentials);

      return tokenOptions;
    }

    /// <summary>
    /// Generate JASON Web Token.
    /// </summary>
    /// <param name="user">Current user.</param>
    /// <returns>JSON Web Token.</returns>
    public async Task<string> GenerateToken(User user, double expiration = 0)
    {
      var signingCredentials = GetSigningCredentials();
      var claims = await GetClaims(user);
      var tokenOptions = GenerateTokenOptions(signingCredentials, claims, expiration);
      var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

      return token;
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
  }
}
