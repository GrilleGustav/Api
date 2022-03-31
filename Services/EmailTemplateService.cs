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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  /// <summary>
  /// Service to manage email templates.
  /// </summary>
  public class EmailTemplateService : IEmailTemplateService
  {
    private readonly ILogger<EmailTemplateService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage email templates.
    /// </summary>
    /// <param name="repository">Access to backend store.</param>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    public EmailTemplateService(IRepositoryManager repository, ILogger<EmailTemplateService> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    /// <summary>
    /// Get all email templates.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of templates.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<EmailTemplate>>> GetAll()
    {
      try
      {
        return new Result<List<EmailTemplate>>(await _repository.EmailTemplate.FindAll(false).Include(x => x.EmailSender).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<EmailTemplate>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<EmailTemplate>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one email template.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a template.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailTemplate>> GetOne(int id)
    {
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id, false).Include(x => x.EmailSender).SingleOrDefaultAsync();
        if (emailTemplate == null)
        {
          if (_logger.IsEnabled(LogLevel.Error))
            _logger.LogError("Record not found");

          return new Result<EmailTemplate>(new Error("3", "Record not found."));
        }

        return new Result<EmailTemplate>(emailTemplate);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get default template for template type.
    /// </summary>
    /// <param name="emailTemplateType">Email template type.</param>
    /// <returns>The Task that represents asynchronous operation, containing a template.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailTemplate>> GetDefaultTemplateForType(EmailTemplateType emailTemplateType)
    {
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == emailTemplateType, false).SingleOrDefaultAsync();
        if (emailTemplate == null)
        {
          if (_logger.IsEnabled(LogLevel.Error))
            _logger.LogError("Record not found");

          return new Result<EmailTemplate>(new Error("3", "Record not found."));
        }

        return new Result<EmailTemplate>(emailTemplate);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update email template. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailTemplate>> Update(EmailTemplate data)
    {
      try
      {
        EmailTemplate emailTemplateOriginal = await _repository.EmailTemplate.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (emailTemplateOriginal.ConcurrencyStamp.SequenceEqual(data.ConcurrencyStamp))
        {
          if (data.Default)
          {
            EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == data.EmailTemplateType && x.Language == data.Language && x.Id != data.Id, true).SingleOrDefaultAsync();
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
              if (_logger.IsEnabled(LogLevel.Error))
                _logger.LogError("Can't set default record to false.");

              return new Result<EmailTemplate>(new Error(errorCode: "4", errorMessage: "Can't set default record to false."));
            }
          }
        }
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<EmailTemplate> result = new Result<EmailTemplate>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(emailTemplateOriginal);
          result.IsSccess = false;
          return result;
        }

        _repository.EmailTemplate.Update(data);
        await _repository.SaveAsync();
        return new Result<EmailTemplate>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create emial template entity. If entity to create default true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailTemplate>> Create(EmailTemplate data)
    {
      try
      {
        if (data.Default)
        {
          EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Default == true && x.EmailTemplateType == data.EmailTemplateType && x.Language == data.Language, true).SingleOrDefaultAsync();
          if (emailTemplate != null)
          {
            emailTemplate.Default = false;
            await _repository.SaveAsync();
          }
        }

        _repository.EmailTemplate.Create(data);
        await _repository.SaveAsync();
        return new Result<EmailTemplate>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("5", "Error creating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete template entity.
    /// </summary>
    /// <param name="id">Entity Id.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailTemplate>> Delete(int id)
    {
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id && x.Default == true, false).SingleOrDefaultAsync();
          if (emailTemplate != null)
          {
            return new Result<EmailTemplate>(new Error(errorCode: "5", errorMessage: "Default template can't delete."));
          }

          _repository.EmailTemplate.Delete(emailTemplate);
          await _repository.SaveAsync();
        return new Result<EmailTemplate>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("5", "Error creating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailTemplate>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Generate Template Preview.
    /// </summary>
    /// <param name="id">Template Id.</param>
    /// <returns>The Task that represents asynchronous operation, containing email template with replaced variables.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailTemplate>> Preview(int id)
    {
      try
      {
        EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.Id == id, false).Include(x => x.EmailSender).SingleOrDefaultAsync();
        if (emailTemplate == null)
        {
          return new Result<EmailTemplate>(new Error("3", "Record not found."));
        }

        string newContent = emailTemplate.Content.Replace("{Date}", DateTime.Now.ToString());
        emailTemplate.Content = newContent;
        return new Result<EmailTemplate>(emailTemplate);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailTemplate>(new Error("1", "Error loading data."));
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
