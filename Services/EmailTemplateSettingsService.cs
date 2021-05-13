using Contracts;
using Entities.Models.Settings.Email;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Response;
using Models.Response.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class EmailTemplateSettingsService : IEmailTemplateSettingsService
  {
    private readonly ILogger<EmailTemplateSettingsService> _logger;
    private readonly IRepositoryManager _repository;

    public EmailTemplateSettingsService(IRepositoryManager repository, ILogger<EmailTemplateSettingsService> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    /// <summary>
    /// Get all email templates.
    /// </summary>
    /// <returns>List of email templates. If fails error code and error message.</returns>
    public async Task<EmailTemplatesResponse> GetAll()
    {
      try
      {
        return new EmailTemplatesResponse(await _repository.EmailTemplate.FindAll(false).ToListAsync());
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailTemplatesResponse("EmailTemplate.1", e.Message);
      }
    }

    /// <summary>
    /// Get one email template.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email template entity. If fails return error code and or error message.</returns>
    public async Task<EmailTemplateResponse> GetOne(int id)
    {
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailTemplate == null)
          return new EmailTemplateResponse(errorCode: "EmailTemplate.2", errorMessage: "No email template found");

        return new EmailTemplateResponse(emailTemplate);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailTemplateResponse("EmailTemplate.3", e.Message);
      }
    }

    /// <summary>
    /// Get default template for template type.
    /// </summary>
    /// <param name="emailTemplateType">Email template type.</param>
    /// <returns>Emial template.</returns>
    public async Task<EmailTemplateResponse> GetDefaultTemplateForType(EmailTemplateType emailTemplateType)
    {
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == emailTemplateType, false).SingleOrDefaultAsync();
        if (emailTemplate == null)
          return new EmailTemplateResponse(errorCode: "EmailTemplate.2", errorMessage: "No email template found");

        return new EmailTemplateResponse(emailTemplate);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailTemplateResponse("EmailTemplate.4", e.Message);
      }
    }

    /// <summary>
    /// Update email template. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>If update failed return error code.</returns>
    public async Task<ErrorResponse> Update(EmailTemplate data)
    {
      try
      {
        if (data.Default)
        {
          EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == data.EmailTemplateType, true).SingleOrDefaultAsync();
          if (emailTemplate != null)
          {
            emailTemplate.Default = false;
            await _repository.SaveAsync();
          }
        }
        else
        {
          EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.Id == data.Id, false).SingleOrDefaultAsync();
          if (emailTemplate != null)
            return new ErrorResponse(errorCode: "EmailTemplate.5", errorMessage: "Can't set default server to false.");
        }

        _repository.EmailTemplate.Update(data);
        await _repository.SaveAsync();
        return new ErrorResponse();
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new ErrorResponse(errorCode: "EmailTemplate.6", errorMessage: e.Message);
      }
    }

    /// <summary>
    /// Create emial template entity. If entity to create default true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>If create failed return error code.</returns>
    public async Task<ErrorResponse> Create(EmailTemplate data)
    {
      try
      {
        if (data.Default)
        {
          EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == data.EmailTemplateType, true).SingleOrDefaultAsync();
          if (emailTemplate != null)
          {
            emailTemplate.Default = false;
            await _repository.SaveAsync();
          }
        }

        _repository.EmailTemplate.Create(data);
        await _repository.SaveAsync();
        return new ErrorResponse();
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new ErrorResponse(errorCode: "EmailTemplate.7", errorMessage: e.Message);
      }
    }

    /// <summary>
    /// Delete template entity.
    /// </summary>
    /// <param name="id">Entity Id.</param>
    /// <returns>Error code and message if could not delete.</returns>
    public async Task<ErrorResponse> Delete(int id)
    {
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailTemplate != null)
        {
          if (emailTemplate.Default == true)
            return new ErrorResponse(errorCode: "EmailTemplate.8", errorMessage: "Default template can't delete.");

          _repository.EmailTemplate.Delete(emailTemplate);
          await _repository.SaveAsync();
          return new ErrorResponse();
        }

        return new ErrorResponse(errorCode: "EmailTemplate.9", errorMessage: "Template not found");
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new ErrorResponse(errorCode: "EmailTemplate.10", errorMessage: e.Message);
      }
    }
  }
}
