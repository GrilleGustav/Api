// <copyright file="ApplicationClaimsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response.Role;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
  /// <summary>
  /// Api Controller for Application claims.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class ApplicationClaimsController : ControllerBase
  {
    private readonly ILogger<ApplicationClaimsController> _logger;
    private readonly IMapper _mapper;
    private readonly IApplicationClaimsService _applicationClaimsService;

    /// <summary>
    /// Api Controller for Application claims.
    /// </summary>
    /// <param name="applicationClaimsService">Service to manage application claims.</param>
    public ApplicationClaimsController(ILogger<ApplicationClaimsController> logger, IMapper mapper, IApplicationClaimsService applicationClaimsService)
    {
      _logger = logger;
      _mapper = mapper;
      _applicationClaimsService = applicationClaimsService;
    }

    /// <summary>
    /// Get all application claims.
    /// </summary>
    /// <returns>Application claims.</returns>
    [HttpGet("[action]")]
    public ActionResult<ApplicationClaimsResponse> GetClaims()
    {
      Result<Dictionary<string, IGrouping<string, ApplicationClaim>>> result = _applicationClaimsService.GetClaimsGroupedBy();
      if (!result.IsSccess)
      {
        ApplicationClaimsResponse response = new ApplicationClaimsResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }
      ApplicationClaimsResponse applicationClaimsResponse = new ApplicationClaimsResponse();
      applicationClaimsResponse.ApplicationClaims = result.Data;
      return Ok(applicationClaimsResponse);
    }
  }
}
