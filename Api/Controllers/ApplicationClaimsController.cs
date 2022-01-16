// <copyright file="ApplicationClaimsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response.Role;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class ApplicationClaimsController : ControllerBase
  {
    private readonly IApplicationClaimsService _applicationClaimsService;

    public ApplicationClaimsController(IApplicationClaimsService applicationClaimsService)
    {
      _applicationClaimsService = applicationClaimsService;
    }

    [HttpGet("[action]")]
    public ActionResult<ApplicationClaimsResponse> GetClaims()
    {
      return Ok(_applicationClaimsService.GetClaimsGroupedBy());
    }
  }
}
