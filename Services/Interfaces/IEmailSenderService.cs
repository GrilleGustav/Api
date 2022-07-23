// <copyright file="IEmailSenderSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Models;
using Models.Response;
using Models.Response.Settings.Sender;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailSenderService
  {
    /// <summary>
    /// Get all email sender.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of email senders.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<EmailSender>>> GetAll();

    /// <summary>
    /// Get one email sender.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a email sender.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailSender>> GetOne(int id);

    /// <summary>
    /// Create email sender.
    /// </summary>
    /// <param name="data">New email sender entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing email sender or task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailSender>> Create(EmailSender data);

    /// <summary>
    /// Remove one email sender from database.
    /// </summary>
    /// <param name="id">Email sender entity id to remove.</param>
    /// <returns>If fails return erro code and message.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<EmailSender>> Delete(int id);
  }
}
