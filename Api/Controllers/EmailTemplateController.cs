// <copyright file="EmailTemplateController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Entities.Models.Settings.Email;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
  /// <summary>
  /// Controller for administration of emial templates.
  /// </summary>
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class EmailTemplateController : ControllerBase
  {
    private ILogger<EmailTemplateController> _logger;
    private IEmailTemplateService _emailTemplateService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for administration of emial templates.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="emailTemplateService">Manage email template data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public EmailTemplateController(ILogger<EmailTemplateController> logger, IEmailTemplateService emailTemplateService, IMapper mapper)
    {
      _logger = logger;
      _emailTemplateService = emailTemplateService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email templates.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of templates.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<List<EmailTemplatesResponse>>> GetAll()
    {
      Result<List<EmailTemplate>> result = await _emailTemplateService.GetAll();
      if (!result.IsSccess)
      {
        EmailTemplatesResponse response = new EmailTemplatesResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error loading data.");
        return Ok(response);
      }
      return Ok(new EmailTemplatesResponse(_mapper.Map<IList<EmailTemplate>, IList<EmailTemplateViewModel>>(result.Data)));
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

      Result<EmailTemplate> result = await _emailTemplateService.GetOne(id);
      if (!result.IsSccess)
      {
        EmailTemplateResponse response = new EmailTemplateResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error loading data.");
        return Ok(response);
      }

      return Ok(new EmailTemplateResponse(_mapper.Map<EmailTemplate, EmailTemplateViewModel>(result.Data)));
    }

    /// <summary>
    /// Add new emailtemplate.
    /// </summary>
    /// <param name="data">New emailtemplate entity.</param>
    /// <returns>Error code or badrequest, if fails.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add(EmailTemplateViewModel data)
    {
      if (data == null)
        return BadRequest();

      Result<EmailTemplate> result = await _emailTemplateService.Create(_mapper.Map<EmailTemplateViewModel, EmailTemplate>(data));
      if (result.IsSccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return Ok(new ErrorResponse(true));
    }

    /// <summary>
    /// Update emailtemplate.
    /// </summary>
    /// <param name="data">Entity to update.</param>
    /// <returns>Error code or badrequest, if fails.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Update(EmailTemplate data)
    {
      if (data == null)
        return BadRequest();
      Result<EmailTemplate> result = await _emailTemplateService.Update(data);
      if (!result.IsSccess)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed");

        return Ok(new ErrorResponse(result.Errors));
      }

      return Ok(new ErrorResponse(true));
    }

    /// <summary>
    /// Delete Template. Default Templates can't delete.
    /// </summary>
    /// <param name="id">Template Id.</param>
    /// <returns>Some error or success if template was deletet.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<EmailTemplate> result = await _emailTemplateService.Delete(id);
      if (!result.IsSccess)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error Deleting record");

        return Ok(new ErrorResponse(result.Errors));
      }

      return Ok(new ErrorResponse(true));
    }

    /// <summary>
    /// Generate template priview.
    /// </summary>
    /// <param name="id">Template id.</param>
    /// <returns>Template with demo data.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailTemplateResponse>> Preview(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<EmailTemplate> result = await _emailTemplateService.Preview(id);
      if (!result.IsSccess)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating template preview.");

        return Ok(new ErrorResponse(result.Errors));
      }
      return Ok(new EmailTemplateResponse(_mapper.Map<EmailTemplate, EmailTemplateViewModel>(result.Data)));
    }

    /// <summary>
    /// Image upload.
    /// </summary>
    /// <param name="a">...</param>
    /// <returns>Image url.</returns>
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
          // Get file from request form.
          await Request.Form.Files[0].CopyToAsync(ms);
          // Gets file type like jpeg or png.
          string fileType = Request.Form.Files[0].ContentType.Split('/')[1]; 
          // Save file and return file name.
          fileName = await _emailTemplateService.ImageUpload(ms.ToArray(), fileType);
          // Forms the URL from the server address, image directory and file name
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
