// <copyright file="IEmailServerSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Models;
using Models.Request.Settings.Email;
using Models.Response;
using Models.Response.Settings.Email;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailServerService
  {
    /// <summary>
    /// Get all email servers.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of email servers.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<EmailServer>>> GetAll();

    /// <summary>
    /// Get one email server.
    /// </summary>
    /// <param name="serverId">Email server backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a email server.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailServer>> GetOne(int serverId);

    /// <summary>
    /// Get default server.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a email server.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailServer>> GetDefault();

    /// <summary>
    /// Update email server. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailServer>> Update(EmailServer data);

    /// <summary>
    /// Create email server entity.  If entity to create default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailServer>> Create(EmailServer data);

    /// <summary>
    /// Delete email server record.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailServer>> Delete(int id);

    /// <summary>
    /// Check if server with Ip/Domain and port exist.
    /// </summary>
    /// <param name="emailServerExistRequest">Data object with IP/Domain, port and Id. Id is only needed in the context of a change form.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result. Result  true if server with Ip/Domain and port exist. If no server found return false.</returns>
    /// <exception cref="Exception"></exception>
    Task<EmailServerExistResponse> EmailServerExist(EmailServerExistRequest emailServerExistRequest);
  }
}
