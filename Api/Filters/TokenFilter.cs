﻿using Api.Jwt;
using Entities.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Models.Response;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Filters
{
  public class TokenFilter : IAsyncAuthorizationFilter
  {
    public TokenFilter()
    {
    }

    /// <summary>
    /// Check user roles have been changed in the background and force frontend to refresh access token, if something changed.
    /// </summary>
    /// <param name="context">HttpContext.</param>
    /// <returns></returns>
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
      UserManager<User> _userManager = context.HttpContext.RequestServices.GetService(typeof(UserManager<User>)) as UserManager<User>;
      JwtHandler _jwtHandler = context.HttpContext.RequestServices.GetService(typeof(JwtHandler)) as JwtHandler;
      string requestPath = context.HttpContext.Request.Path.ToString();
      if (!requestPath.Contains("RefreshToken"))
      {
        var email = context.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        if (email != null)
        {
          User user = await _userManager.FindByEmailAsync(email);
          if (user != null)
          {

            List<Claim> roles = context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Name || x.Type == ClaimTypes.Role).ToList();
            List<Claim> claims = await _jwtHandler.GetClaims(user);
            if (roles.Count != claims.Count)
            {
              var errorResponse = new ErrorResponse();
              errorResponse.AddError(errorCode: "1000", errorMessage: "Roles of current user are changed. Use refresh token to renew accesstoken.");
              errorResponse.TokenNeedsRefresh = true;
              context.Result = new OkObjectResult(errorResponse);
            }
          }
        }
      }
    }
  }
}
