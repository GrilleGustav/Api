// <copyright file="EmailSenderSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


using Contracts;
using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response;
using Models.Response.Settings.Sender;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class EmailSenderService : IEmailSenderService
  {
    private readonly ILogger<EmailSenderService> _logger;
    private readonly IRepositoryManager _repository;

    public EmailSenderService(IRepositoryManager repositoryManager, ILogger<EmailSenderService> logger)
    {
      _repository = repositoryManager;
      _logger = logger;
    }

    /// <summary>
    /// Get all email sender.
    /// </summary>
    /// <returns>List of email sender. If fails error code and or error message</returns>
    public async Task<EmailSenderSettingsResponse> GetAll()
    {
      EmailSenderSettingsResponse errorResponse = new EmailSenderSettingsResponse();
      try
      {
        return new EmailSenderSettingsResponse(await _repository.EmailSender.FindAll(false).ToListAsync());
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }

    /// <summary>
    /// Get one email sender.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email sender entity. If fails return error code and or error message.</returns>
    public async Task<EmailSenderSettingResponse> GetOne(int id)
    {
      EmailSenderSettingResponse emailSenderSettingResponse = new EmailSenderSettingResponse();
      try
      {
        EmailSender emailSender = await _repository.EmailSender.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailSender == null)
        {
          emailSenderSettingResponse.AddError(errorCode: "2", errorMessage: "No sender found.");
          return emailSenderSettingResponse;
        }

        return new EmailSenderSettingResponse(emailSender);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        emailSenderSettingResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailSenderSettingResponse;
      }
    }

    /// <summary>
    /// Create email sender.
    /// </summary>
    /// <param name="data">New email sender entity.</param>
    /// <returns>New email sender data base object.</returns>
    public async Task<EmailSenderSettingResponse> Create(EmailSender data)
    {
      EmailSenderSettingResponse emailSenderSettingResponse = new EmailSenderSettingResponse();
      try
      {
        EmailSender emailSender = await _repository.EmailSender.FindByCondition(x => x.Sender == data.Sender, false).SingleOrDefaultAsync();
        if (emailSender != null)
        {
          emailSenderSettingResponse.AddError(errorCode: "6", errorMessage: "Sender already exist.");
          return emailSenderSettingResponse;
        }

        _repository.EmailSender.Create(data);
        await _repository.SaveAsync();
        return new EmailSenderSettingResponse(emailSender: await _repository.EmailSender.FindByCondition(x => x.Sender == data.Sender, false).SingleOrDefaultAsync());
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        emailSenderSettingResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailSenderSettingResponse;
      }
    }

    /// <summary>
    /// Remove one email sender from database.
    /// </summary>
    /// <param name="data">Email sender entity id to remove.</param>
    /// <returns>If fails return erro code and message.</returns>
    public async Task<ErrorResponse> Delete(int id)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      try
      {
        EmailSender sender = await _repository.EmailSender.FindByCondition(x => x.Id == id, true).SingleOrDefaultAsync();
        _repository.EmailSender.Delete(sender);
        await _repository.SaveAsync();
        return new ErrorResponse();
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }
  }
}
