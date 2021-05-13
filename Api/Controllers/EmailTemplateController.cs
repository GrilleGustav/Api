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

namespace Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class EmailTemplateController : ControllerBase
  {
    private ILogger<EmailTemplateController> _logger;
    private IEmailTemplateSettingsService _emailTemplateSettingsService;
    private readonly IMapper _mapper;

    public EmailTemplateController(ILogger<EmailTemplateController> logger, IEmailTemplateSettingsService emailTemplateSettingsService, IMapper mapper)
    {
      _logger = logger;
      _emailTemplateSettingsService = emailTemplateSettingsService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email templates.
    /// </summary>
    /// <returns>List of email templates.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<List<EmailTemplatesResponse>>> GetAll()
    {
      return Ok(await _emailTemplateSettingsService.GetAll());
    }

    /// <summary>
    /// Get one email template.
    /// </summary>
    /// <param name="id">Template id.</param>
    /// <returns>Return one email template.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailTemplateResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      return Ok(await _emailTemplateSettingsService.GetOne(id));
    }
  }
}
