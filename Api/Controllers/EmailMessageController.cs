// <copyright file="EmailMessageController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Entities.Models.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response;
using Models.Response.Settings.Email;
using Models.View.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
  /// <summary>
  /// Controller to manage emails, who was send by application.
  /// </summary>
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class EmailMessageController : ControllerBase
  {
    private readonly ILogger<EmailMessageController> _logger;
    private readonly IMapper _mapper;
    private readonly IEmailMessageService _emailMesssageService;
    /// <summary>
    /// Controller to manage emails, who was send by application.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    /// <param name="emailMessageService">Service to manage email who was send by application.</param>
    public EmailMessageController(ILogger<EmailMessageController> logger, IMapper mapper, IEmailMessageService emailMessageService)
    {
      _logger = logger;
      _mapper = mapper;
      _emailMesssageService = emailMessageService;
    }

    /// <summary>
    /// Get all email, who was send by application.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or List  of emails.</returns>
    [Authorize(Roles = "Admin,EmailAdmin")]
    [HttpGet("[action]")]
    public async Task<ActionResult<EmailMessageResponse>> GetAll()
    {
      Result<List<EmailMessage>> result = await _emailMesssageService.GetAll();
      if (!result.IsSuccess)
      {
        EmailMessageResponse response = new EmailMessageResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error loading data.");
        return Ok(response);
      }

      return Ok(new EmailMessageResponse(_mapper.Map<IList<EmailMessage>, IList<EmailMessageViewModel>>(result.Data)));
    }
  }
}
