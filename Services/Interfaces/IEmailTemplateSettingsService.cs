using Entities.Models.Settings.Email;
using Enums;
using Models.Response;
using Models.Response.Settings.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailTemplateSettingsService
  {
    /// <summary>
    /// Get all email templates.
    /// </summary>
    /// <returns>List of email templates. If fails error code and error message.</returns>
    Task<EmailTemplatesResponse> GetAll();

    /// <summary>
    /// Get one email template.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email template entity. If fails return error code and or error message.</returns>
    Task<EmailTemplateResponse> GetOne(int id);

    /// <summary>
    /// Get default template for template type.
    /// </summary>
    /// <param name="emailTemplateType">Email template type.</param>
    /// <returns>Emial template.</returns>
    Task<EmailTemplateResponse> GetDefaultTemplateForType(EmailTemplateType emailTemplateType);

    /// <summary>
    /// Update email template. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>If update failed return error code.</returns>
    Task<ErrorResponse> Update(EmailTemplate data);

    /// <summary>
    /// Create emial template entity. If entity to create default true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>If create failed return error code.</returns>
    Task<ErrorResponse> Create(EmailTemplate data);

    /// <summary>
    /// Delete template entity.
    /// </summary>
    /// <param name="id">Entity Id.</param>
    /// <returns>Error code and message if could not delete.</returns>
    Task<ErrorResponse> Delete(int id);
  }
}
