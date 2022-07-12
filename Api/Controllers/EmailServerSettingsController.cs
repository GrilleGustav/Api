// <copyright file="EmailServerSettingsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Response.Settings.Email;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Response;
using Models.Request.Settings.Email;
using Entities.Models.Settings.Email;
using Models.View.Settings.Email;
using Models;
using System;
using System.Linq;

namespace Api.Controllers
{
  /// <summary>
  /// Controller for adminitration of email server.
  /// </summary>
  [Authorize(Roles = "Administrator")]
  [ApiController]
  [Route("[controller]")]
  public class EmailServerSettingsController : ControllerBase
  {
    private ILogger<EmailServerSettingsController> _logger;
    private IEmailServerService _emailServerSettingsService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for adminitration of email server.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="emailServerSettingsService">Manage email server data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public EmailServerSettingsController(ILogger<EmailServerSettingsController> logger, IEmailServerService emailServerSettingsService, IMapper mapper)
    {
      _logger = logger;
      _emailServerSettingsService = emailServerSettingsService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email servers.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of email servers.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<EmailServerSettingsResponse>> GetAll()
    {
      var result = await _emailServerSettingsService.GetAll();

      if (result.Data == null)
      {
        EmailServerSettingsResponse response = new EmailServerSettingsResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new EmailServerSettingsResponse(_mapper.Map<IList<EmailServer>, IList<EmailServerViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one email server.
    /// </summary>
    /// <param name="id">Server id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one email server.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailServerSettingResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<EmailServer> result = await _emailServerSettingsService.GetOne(id);
      if (result.Data == null)
      {
        EmailServerSettingResponse response = new EmailServerSettingResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }
      var test = new EmailServerSettingResponse(_mapper.Map<EmailServer, EmailServerViewModel>(result.Data));
      return Ok(new EmailServerSettingResponse(_mapper.Map<EmailServer, EmailServerViewModel>(result.Data)));
    }

    /// <summary>
    /// Add email server. If the new email server is the deafult server set other default server automatically.
    /// </summary>
    /// <param name="emailServerAddRequest">Email server data.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one email server.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] EmailServerAddRequest emailServerAddRequest)
    {
      if (emailServerAddRequest == null || !ModelState.IsValid)
        return BadRequest();

      Result<EmailServer> result = await _emailServerSettingsService.Create(_mapper.Map<EmailServerAddRequest, EmailServer>(emailServerAddRequest));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update email server entity.
    /// </summary>
    /// <param name="emailServerEditRequest">Email server data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<EmailServerSettingResponse>> Update([FromBody] EmailServerEditRequest request)
    {
      if (request == null)
        return BadRequest();

      EmailServerSettingResponse response = new EmailServerSettingResponse();
      Result<EmailServer> result = await _emailServerSettingsService.Update(_mapper.Map<EmailServerEditRequest, EmailServer>(request));
      if (result.IsSuccess == false)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.EmailServer = _mapper.Map<EmailServer, EmailServerViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }
      else
        response.IsSuccess = true;

      return Ok(response); ;
    }

    /// <summary>
    /// Delete email server.
    /// </summary>
    /// <param name="id">Email server id.</param>
    /// <returns>Some error or success if entity was deleted.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();
      ErrorResponse response = new ErrorResponse();
      Result<EmailServer> result = await _emailServerSettingsService.Delete(id);
      if (result.IsSuccess == false)
      {
        response.AddError(errorCode: "9", errorMessage: "Error deleting record.");
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error deleting record.");

        response.AddErrors(result.Errors);
      }
      return Ok(response);
    }

    /// <summary>
    /// Checks if the ip, port combination already exists.
    /// </summary>
    /// <param name="emailServerExistRequest"></param>
    /// <returns>The Task that represents asynchronous operation, containing task result. Result  true if server with Ip/Domain and port exist. If no server found return false.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<EmailServerExistResponse>> Exist([FromBody] EmailServerExistRequest emailServerExistRequest)
    {
      if (emailServerExistRequest == null)
        return BadRequest();
      else if (emailServerExistRequest.ServerIp == null || emailServerExistRequest.ServerPort == null)
        return BadRequest();

      EmailServerExistResponse response = await _emailServerSettingsService.EmailServerExist(emailServerExistRequest);

      if (response == null)
      {
        response = new EmailServerExistResponse();
        if (_logger.IsEnabled(LogLevel.Error)) 
          response.AddError(errorCode: "1", errorMessage: "Error validate data.");
      }
      // Return true if server already exist otherwise return false.
      return Ok(response);
    }
  }
}
