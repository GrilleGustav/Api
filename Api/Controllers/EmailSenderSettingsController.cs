// <copyright file="EmailSenderSettingsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Entities.Models.Settings.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Request.Settings.Sender;
using Models.Response;
using Models.Response.Settings.Sender;
using Models.View.Settings.Email;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
  /// <summary>
  /// Controller for the administration of email sender addresses of the application.
  /// </summary>
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class EmailSenderSettingsController : ControllerBase
  {
    private readonly ILogger<EmailSenderSettingsController> _logger;
    private readonly IEmailSenderService _emailSenderSettingsService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for the administration of email sender addresses of the application.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="emailSenderSettingsService">Manage email sender data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public EmailSenderSettingsController(ILogger<EmailSenderSettingsController> logger, IEmailSenderService emailSenderSettingsService, IMapper mapper)
    {
      _logger = logger;
      _emailSenderSettingsService = emailSenderSettingsService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email senders.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of email senders.</returns>
    [Authorize(Roles = "Admin,View,Create,Update,Delete,EmailAdmin,EmailView,EmailCreate,EmailUpdate,EmailDelete")]
    [HttpGet("[action]")]
    public async Task<ActionResult<EmailSenderSettingsResponse>> GetAll()
    {
      Result<List<EmailSender>> result = await _emailSenderSettingsService.GetAll();

      if (!result.IsSuccess)
      {
        EmailSenderSettingsResponse response = new EmailSenderSettingsResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);
        return Ok(response); 
      }
      return Ok(new EmailSenderSettingsResponse(_mapper.Map<IList<EmailSender>, IList<EmailSenderViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one email sender.
    /// </summary>
    /// <param name="id">Sender id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one email senders.</returns>
    [Authorize(Roles = "Admin,Create,Update,EmailAdmin,EmailCreate,EmailUpdate")]
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailSenderSettingResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<EmailSender> result = await _emailSenderSettingsService.GetOne(id);
      if (!result.IsSuccess)
      {
        EmailSenderSettingResponse response = new EmailSenderSettingResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);
        return Ok(response);
      }
      return Ok(new EmailSenderSettingResponse(_mapper.Map<EmailSender, EmailSenderViewModel>(result.Data)));
    }

    /// <summary>
    /// Add email sender address.
    /// </summary>
    /// <param name="emailSenderAddRequest">Email server id and sender name.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one email senders.</returns>
    [Authorize(Roles = "Admin,Creat,EmailAdmin,EmailCreate")]
    [HttpPost("[action]")]
    public async Task<ActionResult<EmailSenderSettingResponse>> Add([FromBody] EmailSenderAddRequest emailSenderAddRequest)
    {
      EmailSenderSettingResponse response = new EmailSenderSettingResponse();
      if (emailSenderAddRequest == null)
        return BadRequest();
      Result<EmailSender> result = await _emailSenderSettingsService.Create(_mapper.Map<EmailSender>(emailSenderAddRequest));
      if (!result.IsSuccess)
      {
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);
        return Ok(response);
      }

      response.EmailSender = _mapper.Map<EmailSender, EmailSenderViewModel>(result.Data);
      response.IsSuccess = true;

      if (!response.IsSuccess)
      {
        return Ok(response);
      }
      return StatusCode(201, response);
    }

    /// <summary>
    /// Delete email sender.
    /// </summary>
    /// <param name="id">Sender id.</param>
    /// <returns>The Task that represents asynchronous operation, containing result.</returns>
    [Authorize(Roles = "Admin,Delete,EmailAdmin,EmailDelete")]
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();
      Result<EmailSender> result = await _emailSenderSettingsService.Delete(id);
      ErrorResponse response = new ErrorResponse();
      if (!result.IsSuccess)
      {
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);
        return Ok(response);
      }

      response.IsSuccess = result.IsSuccess;
      return Ok(response);
    }
  }
}
