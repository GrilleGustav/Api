// <copyright file="EmailMessageService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Models.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
  /// <summary>
  /// Service to manage email messages in backend store.
  /// </summary>
  public class EmailMessageService : IEmailMessageService
  {
    private readonly ILogger<EmailMessageService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage email messages in backend store.
    /// </summary>
    /// <param name="repository">Access to backend store.</param>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    public EmailMessageService(IRepositoryManager repository, ILogger<EmailMessageService> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    /// <summary>
    /// Get all email messages, the system has send.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of email messages.</returns>
    public async Task<Result<List<EmailMessage>>> GetAll()
    {
      try
      {
        return new Result<List<EmailMessage>>(await _repository.EmailMessage.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<EmailMessage>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<EmailMessage>>(new Error("1", "Error loading data."));
      }
    }
  }
}
