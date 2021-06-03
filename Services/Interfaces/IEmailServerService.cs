// <copyright file="IEmailServerSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Models.Request.Settings.Email;
using Models.Response;
using Models.Response.Settings.Email;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailServerService
  {
    /// <summary>
    /// Get all email server.
    /// </summary>
    /// <returns>Email server or error code and error message.</returns>
    Task<EmailServerSettingsResponse> GetAll();

    /// <summary>
    /// Get one email server.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email server entity.</returns>
    Task<EmailServerSettingResponse> GetOne(int id);

    /// <summary>
    /// Get default email server.
    /// </summary>
    /// <returns>Email server entity.</returns>
    Task<EmailServerSettingResponse> GetDefault();

    /// <summary>
    /// Update email server. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity.</param>
    /// <returns>If update failed return error code.</returns>
    Task<ErrorResponse> Update(EmailServer data);

    /// <summary>
    /// Create email server entity.  If entity to create default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity</param>
    /// <returns>If create failed return error code.</returns>
    Task<ErrorResponse> Create(EmailServer data);

    /// <summary>
    /// Delete one email server entity.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Error code and message if could not delete.</returns>
    Task<ErrorResponse> Delete(int id);

    /// <summary>
    /// Check if server with Ip/Domain and port exist.
    /// </summary>
    /// <param name="emailServerExistRequest">Data object with Ip/Domain and port.</param>
    /// <returns>If fails return some error code and message, otherwise return true if server with Ip/Domain and port exist. If no server found return false.</returns>
    Task<EmailServerExistResponse> EmailServerExist(EmailServerExistRequest emailServerExistRequest);
  }
}
