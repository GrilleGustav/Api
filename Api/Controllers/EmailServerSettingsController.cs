// <copyright file="EmailServerSettingsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Response.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Models.Response;
using Models.Request.Settings.Email;
using Entities.Models.Settings.Email;

namespace Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class EmailServerSettingsController : ControllerBase
  {
    private ILogger<EmailServerSettingsController> _logger;
    private IEmailServerService _emailServerSettingsService;
    private readonly IMapper _mapper;

    public EmailServerSettingsController(ILogger<EmailServerSettingsController> logger, IEmailServerService emailServerSettingsService, IMapper mapper)
    {
      _logger = logger;
      _emailServerSettingsService = emailServerSettingsService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email servers.
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<List<EmailServerSettingsResponse>>> GetAll()
    {
      EmailServerSettingsResponse emailServerSettingsResponse = await _emailServerSettingsService.GetAll();
      return Ok(emailServerSettingsResponse);
    }

    /// <summary>
    /// Get one email server.
    /// </summary>
    /// <param name="id">Server id.</param>
    /// <returns>Return one email server.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailServerSettingResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      return Ok(await _emailServerSettingsService.GetOne(id));
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] EmailServerAddRequest emailServerAddRequest)
    {
      if (emailServerAddRequest == null || !ModelState.IsValid)
        return BadRequest();

      return StatusCode(201, await _emailServerSettingsService.Create(_mapper.Map<EmailServer>(emailServerAddRequest)));
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Update([FromBody] EmailServerEditRequest emailServerEditRequest)
    {
      if (emailServerEditRequest == null)
        return BadRequest();

      return Ok(await _emailServerSettingsService.Update(_mapper.Map<EmailServer>(emailServerEditRequest)));
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      return Ok(await _emailServerSettingsService.Delete(id));
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<EmailServerExistResponse>> Exist([FromBody] EmailServerExistRequest emailServerExistRequest)
    {
      if (emailServerExistRequest == null)
        return BadRequest();
      else if (emailServerExistRequest.ServerIp == null || emailServerExistRequest.ServerPort == null)
        return BadRequest();

      return Ok(await _emailServerSettingsService.EmailServerExist(emailServerExistRequest));
    }
  }
}
