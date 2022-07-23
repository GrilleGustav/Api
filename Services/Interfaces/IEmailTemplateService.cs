using Entities.Models.Settings.Email;
using Enums;
using Microsoft.AspNetCore.Http;
using Models;
using Models.Response;
using Models.Response.Settings.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailTemplateService
  {
    /// <summary>
    /// Get all email templates.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of templates.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<EmailTemplate>>> GetAll();

    /// <summary>
    /// Get one email template.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email template entity. If fails return error code and or error message.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailTemplate>> GetOne(int id);

    /// <summary>
    /// Get default template for template type.
    /// </summary>
    /// <param name="Id">Email template type.</param>
    /// <returns>The Task that represents asynchronous operation, containing a template.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailTemplate>> GetDefaultTemplateForType(int id);

    /// <summary>
    /// Update email template. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailTemplate>> Update(EmailTemplate data);

    /// <summary>
    /// Create emial template entity. If entity to create default true, set other default to false.
    /// </summary>
    /// <param name="data">Email template entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailTemplate>> Create(EmailTemplate data);

    /// <summary>
    /// Delete template entity.
    /// </summary>
    /// <param name="id">Entity Id.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailTemplate>> Delete(int id);

    /// <summary>
    /// Generate Template Preview.
    /// </summary>
    /// <param name="id">Template Id.</param>
    /// <returns>The Task that represents asynchronous operation, containing email template with replaced variables.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailTemplate>> Preview(int id);

    Task<string> ImageUpload(byte[] data, string fileType);
  }
}
