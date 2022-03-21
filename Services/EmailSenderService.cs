// <copyright file="EmailSenderSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


using AutoMapper;
using Contracts;
using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response;
using Models.Response.Settings.Sender;
using Models.View.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  /// <summary>
  /// Service to manage email sender in backend store.
  /// </summary>
  public class EmailSenderService : IEmailSenderService
  {
    private readonly ILogger<EmailSenderService> _logger;
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Service to manage email sender in abckend store.
    /// </summary>
    /// <param name="repositoryManager">Access to backend store.</param>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public EmailSenderService(IRepositoryManager repositoryManager, ILogger<EmailSenderService> logger, IMapper mapper)
    {
      _repository = repositoryManager;
      _logger = logger;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email sender.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of email senders.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<EmailSender>>> GetAll()
    {
      try
      {
        return new Result<List<EmailSender>>(await _repository.EmailSender.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<List<EmailSender>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<List<EmailSender>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one email sender.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a email sender.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailSender>> GetOne(int id)
    {
      try
      {
        return new Result<EmailSender>(await _repository.EmailSender.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create email sender.
    /// </summary>
    /// <param name="data">New email sender entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing email sender or task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailSender>> Create(EmailSender data)
    {
      try
      {
        EmailSender emailSender = await _repository.EmailSender.FindByCondition(x => x.Sender == data.Sender, false).SingleOrDefaultAsync();
        if (emailSender != null)
        {
          return new Result<EmailSender>(new Error("6", "Sender already exist."));
        }

        _repository.EmailSender.Create(data);
        await _repository.SaveAsync();
        return new Result<EmailSender>(await _repository.EmailSender.FindByCondition(x => x.Sender == data.Sender, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Remove one email sender from database.
    /// </summary>
    /// <param name="data">Email sender entity id to remove.</param>
    /// <returns>If fails return erro code and message.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailSender>> Delete(int id)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      try
      {
        EmailSender sender = await _repository.EmailSender.FindByCondition(x => x.Id == id, true).SingleOrDefaultAsync();
        _repository.EmailSender.Delete(sender);
        await _repository.SaveAsync();
        return new Result<EmailSender>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailSender>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", "Error loading data.");
        return new Result<EmailSender>(new Error(errorCode: "1", errorMessage: "Error loading data."));
      }
    }
  }
}
