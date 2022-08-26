// <copyright file="PlaceholderController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response.Placeholder;
using Models.View.User;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Api.Controllers
{
  /// <summary>
  /// Controller for get placeholders for ckeditor.
  /// </summary>
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class PlaceholderController : ControllerBase
  {
    private ILogger<PlaceholderController> _logger;
    private IPlaceholderService _placeholderService;

    /// <summary>
    /// Controller for get placeholders for ckeditor.
    /// </summary>
    public PlaceholderController(ILogger<PlaceholderController> logger, IPlaceholderService placeholderService)
    {
      _logger = logger;
      _placeholderService = placeholderService;
    }

    /// <summary>
    /// Get placeholders from application.
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles = "Admin,View,Create,Update,EmailView,EmailCreate,EmailUpdate")]
    [HttpGet("[action]/{templateType}")]
    public ActionResult<PlaceholderResponse> GetPlaceholdersFromApplication(string templateType)
    {
      List<string> placeholderFilter = new List<string>();
      placeholderFilter.Add("base");
      placeholderFilter.Add(templateType);
      List<string> placeholder = _placeholderService.GetPlaceholdersFromApplication(placeholderFilter);

      switch (templateType)
      {
        case "Register":
          placeholder.Add("RegisterConfirm");
          break;
        case "PasswordReset":
          placeholder.Add("PasswortReset");
          break;
        case "ChangeEmail":
          placeholder.Add("ChangeEmialLink");
          break;
        case "TwoStep":
          placeholder.Add("TowStepCode");
          break;
        default:
          break;
      }

      return Ok(new PlaceholderResponse(placeholder));
    }
  }

}
