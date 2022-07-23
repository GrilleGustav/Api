// <copyright file="IEmailMessageService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Email;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailMessageService
  {
    /// <summary>
    /// Get all email messages, the system has send.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of email messages.</returns>
    Task<Result<List<EmailMessage>>> GetAll();
  }
}
