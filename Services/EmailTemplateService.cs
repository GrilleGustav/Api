using Contracts;
using Entities.Models.Settings.Email;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response;
using Models.Response.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class EmailTemplateService : IEmailTemplateService
  {
    private readonly ILogger<EmailTemplateService> _logger;
    private readonly IRepositoryManager _repository;

    public EmailTemplateService(IRepositoryManager repository, ILogger<EmailTemplateService> logger)
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
      EmailTemplatesResponse emailTemplatesResponse = new EmailTemplatesResponse();
      try
      {
        return new EmailTemplatesResponse(await _repository.EmailTemplate.FindAll(false).Include(x => x.EmailSender).ToListAsync());
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        emailTemplatesResponse.AddError("1", e.Message);
        return emailTemplatesResponse;
      }
    }

    /// <summary>
    /// Get one email template.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email template entity. If fails return error code and or error message.</returns>
    public async Task<EmailTemplateResponse> GetOne(int id)
    {
      EmailTemplateResponse emailTemplateResponse = new EmailTemplateResponse();
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailTemplate == null)
        {
          emailTemplateResponse.AddError(errorCode: "2", errorMessage: "Not found.");
          return emailTemplateResponse;
        }

        return new EmailTemplateResponse(emailTemplate);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        emailTemplateResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailTemplateResponse;
      }
    }

    /// <summary>
    /// Get default template for template type.
    /// </summary>
    /// <param name="emailTemplateType">Email template type.</param>
    /// <returns>Emial template.</returns>
    public async Task<EmailTemplateResponse> GetDefaultTemplateForType(EmailTemplateType emailTemplateType)
    {
      EmailTemplateResponse emailTemplateResponse = new EmailTemplateResponse();
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == emailTemplateType, false).SingleOrDefaultAsync();
        if (emailTemplate == null)
        {
          emailTemplateResponse.AddError(errorCode: "3", errorMessage: "No email template found");
          return emailTemplateResponse;
        }

        return new EmailTemplateResponse(emailTemplate);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        emailTemplateResponse.AddError("1", e.Message);
        return emailTemplateResponse;
      }
    }

    /// <summary>
    /// Update email template. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>If update failed return error code.</returns>
    public async Task<ErrorResponse> Update(EmailTemplate data)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      try
      {
        if (data.Default)
        {
          EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == data.EmailTemplateType && x.LanguageCode == data.LanguageCode && x.Id != data.Id, true).SingleOrDefaultAsync();
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
          {
            errorResponse.AddError(errorCode: "4", errorMessage: "Can't set default template to false.");
            return errorResponse;
          }
        }

        _repository.EmailTemplate.Update(data);
        await _repository.SaveAsync();
        return new ErrorResponse();
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }

    /// <summary>
    /// Create emial template entity. If entity to create default true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>If create failed return error code.</returns>
    public async Task<ErrorResponse> Create(EmailTemplate data)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      try
      {
        if (data.Default)
        {
          EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == data.EmailTemplateType && x.LanguageCode == data.LanguageCode, true).SingleOrDefaultAsync();
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
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }

    /// <summary>
    /// Delete template entity.
    /// </summary>
    /// <param name="id">Entity Id.</param>
    /// <returns>Error code and message if could not delete.</returns>
    public async Task<ErrorResponse> Delete(int id)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailTemplate != null)
        {
          if (emailTemplate.Default == true)
          {
            errorResponse.AddError(errorCode: "5", errorMessage: "Default template can't delete.");
            return errorResponse;
          }

          _repository.EmailTemplate.Delete(emailTemplate);
          await _repository.SaveAsync();
          return new ErrorResponse();
        }

        errorResponse.AddError(errorCode: "2", errorMessage: "Template not found");
        return errorResponse;
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }

    /// <summary>
    /// Generate Template Preview.
    /// </summary>
    /// <param name="id">Template Id.</param>
    /// <returns>Email template with replaced variables.</returns>
    public async Task<EmailTemplateResponse> Preview(int id)
    {
      EmailTemplateResponse emailTemplateResponse = new EmailTemplateResponse();
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id, false).Include(x => x.EmailSender).SingleOrDefaultAsync();
        if (emailTemplate != null)
        {
         string newContent = emailTemplate.Content.Replace("{Date}", DateTime.Now.ToString());
          emailTemplate.Content = newContent;
          return new EmailTemplateResponse(emailTemplate: emailTemplate);
        }
        emailTemplateResponse.AddError(errorCode: "2", errorMessage: "Not found.");
        return emailTemplateResponse;
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        emailTemplateResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailTemplateResponse;
      }
    }

    public async Task<string> ImageUpload(byte[] data, string fileType)
    {
      string fileExtension = "";
      switch (fileType)
      {
        case "jpeg":
          fileExtension = "jpg";
          break;
        case "png":
          fileExtension = "png";
          break;
        case "gif":
          fileExtension = "gif";
          break;
        case "bmp":
          fileExtension = "bmp";
          break;
        case "webp":
          fileExtension = "webp";
          break;
        case "tiff":
          fileExtension = "tiff";
          break;
        default:
          fileExtension = "jpg";
          break;
      }
      string fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), fileExtension);
      string imagePath = string.Format(@"./Upload/Editor/Images/{0}", fileName);
      try
      {
        using (FileStream fs = File.Create(imagePath))
        {
          await fs.WriteAsync(data, 0, data.Length);
        }

      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
      }

      return fileName;
    }
  }
}
