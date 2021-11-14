using Api.Filters;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
  public class EmailMessageController : ControllerBase
  {
    private readonly IEmailMessageService _emailMesssageService;

    public EmailMessageController(IEmailMessageService emailMessageService)
    {
      _emailMesssageService = emailMessageService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<EmailMessageResponse>> GetAll()
    {
      EmailMessageResponse emailMessageResponse = await _emailMesssageService.GetAll();
      return Ok(emailMessageResponse);
    }
  }
}
