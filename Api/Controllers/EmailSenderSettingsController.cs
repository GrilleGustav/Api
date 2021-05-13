// <copyright file="EmailSenderSettingsController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Entities.Models.Settings.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Request.Settings.Sender;
using Models.Response;
using Models.Response.Settings.Sender;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class EmailSenderSettingsController : ControllerBase
  {
    private ILogger<EmailSenderSettingsController> _logger;
    private IEmailSenderSettingsService _emailSenderSettingsService;
    private readonly IMapper _mapper;

    public EmailSenderSettingsController(ILogger<EmailSenderSettingsController> logger, IEmailSenderSettingsService emailSenderSettingsService, IMapper mapper)
    {
      _logger = logger;
      _emailSenderSettingsService = emailSenderSettingsService;
      _mapper = mapper;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<EmailSenderSettingsResponse>> GetAll()
    {
      EmailSenderSettingsResponse emailSenderSettingsResponse = await _emailSenderSettingsService.GetAll();
      return Ok(emailSenderSettingsResponse);
    }

    /// <summary>
    /// Get all sender from specified server.
    /// </summary>
    /// <param name="id">Email server id.</param>
    /// <returns>List of email senders or error code.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailSenderSettingsController>> GetAllFromSpecifiedServer(int id)
    {
      if (id == 0)
        return BadRequest();

      EmailSenderSettingsResponse emailSenderSettingsResponse = await _emailSenderSettingsService.GetAllFromSpecifiedServer(id);
      return Ok(emailSenderSettingsResponse);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailSenderSettingResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      EmailSenderSettingResponse emailSenderSettingResponse = await _emailSenderSettingsService.GetOne(id);
      return Ok(emailSenderSettingResponse);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<EmailSenderSettingResponse>> Add([FromBody] EmailSenderAddRequest emailSenderAddRequest)
    {
      if (emailSenderAddRequest == null)
        return BadRequest();

      return StatusCode(201, await _emailSenderSettingsService.Create(_mapper.Map<EmailSender>(emailSenderAddRequest)));
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      return Ok(await _emailSenderSettingsService.Delete(id));
    }
  }
}
