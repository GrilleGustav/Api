using AutoMapper;
using Entities.Models.Settings.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Response;
using Models.Response.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class EmailTemplateController : ControllerBase
  {
    private ILogger<EmailTemplateController> _logger;
    private IEmailTemplateService _emailTemplateService;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public EmailTemplateController(ILogger<EmailTemplateController> logger, IEmailTemplateService emailTemplateService, IMapper mapper)
    {
      _logger = logger;
      _emailTemplateService = emailTemplateService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email templates.
    /// </summary>
    /// <returns>List of email templates.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<List<EmailTemplatesResponse>>> GetAll()
    {
      return Ok(await _emailTemplateService.GetAll());
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

      return Ok(await _emailTemplateService.GetOne(id));
    }

    /// <summary>
    /// Add new emailtemplate.
    /// </summary>
    /// <param name="data">New emailtemplate entity.</param>
    /// <returns>Error code or badrequest, if fails.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add (EmailTemplate data)
    {
      if (data == null)
        return BadRequest();

      return Ok(await _emailTemplateService.Create(data));
    }

    /// <summary>
    /// update emailtemplate.
    /// </summary>
    /// <param name="data">Entity to update.</param>
    /// <returns>Error code or badrequest, if fails.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Update(EmailTemplate data)
    {
      if (data == null)
        return BadRequest();

      return Ok(await _emailTemplateService.Update(data));
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      return Ok(await _emailTemplateService.Delete(id));
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailTemplateResponse>> Preview(int id)
    {
      if (id == 0)
        return BadRequest();

      return Ok(await _emailTemplateService.Preview(id));
    }

    
    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<ActionResult<string>> ImageUpload([FromForm] object a)
    {
      string fileName = "";
      string url = "";
      try
      {
        using (var ms = new MemoryStream(2048))
        {
          //await Request.Body.CopyToAsync(ms);
          await Request.Form.Files[0].CopyToAsync(ms);
          string fileType = Request.Form.Files[0].ContentType.Split('/')[1]; 
          fileName = await _emailTemplateService.ImageUpload(ms.ToArray(), fileType);
          url = string.Format("http://{0}/Upload/Editor/Images/{1}", Request.Host.Value, fileName);
        }
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return BadRequest();
      }
      return Ok(new EditorImageResponse(url));
    }
  }
}
