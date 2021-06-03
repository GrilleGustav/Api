// <copyright file="EmailSenderSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


using Contracts;
using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
      try
      {
        return new EmailSenderSettingsResponse(await _repository.EmailSender.FindAll(false).ToListAsync());
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailSenderSettingsResponse("EmailSenderSettings.1");
      }
    }

    /// <summary>
    /// Get one email sender.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email sender entity. If fails return error code and or error message.</returns>
    public async Task<EmailSenderSettingResponse> GetOne(int id)
    {
      try
      {
        EmailSender emailSender = await _repository.EmailSender.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailSender == null)
          return new EmailSenderSettingResponse(errorCode: "EmailSenderSettings.2", errorMessage: "No sender found.");

        return new EmailSenderSettingResponse(emailSender);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailSenderSettingResponse("EmailSenderSettings.3", e.Message);
      }
    }

    /// <summary>
    /// Create email sender.
    /// </summary>
    /// <param name="data">New email sender entity.</param>
    /// <returns>New email sender data base object.</returns>
    public async Task<EmailSenderSettingResponse> Create(EmailSender data)
    {
      try
      {
        EmailSender emailSender = await _repository.EmailSender.FindByCondition(x => x.Sender == data.Sender, false).SingleOrDefaultAsync();
        if (emailSender != null)
          return new EmailSenderSettingResponse(errorCode: "EmailSenderSettings.7", errorMessage: "Sender already exist.");

        _repository.EmailSender.Create(data);
        await _repository.SaveAsync();
        return new EmailSenderSettingResponse(emailSender: await _repository.EmailSender.FindByCondition(x => x.Sender == data.Sender, false).SingleOrDefaultAsync());
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailSenderSettingResponse(errorCode: "EmailSenderSettings.8", errorMessage: e.Message);
      }
    }

    /// <summary>
    /// Remove one email sender from database.
    /// </summary>
    /// <param name="data">Email sender entity id to remove.</param>
    /// <returns>If fails return erro code and message.</returns>
    public async Task<ErrorResponse> Delete(int id)
    {
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
        return new ErrorResponse(errorCode: "EmailSenderSettings.9", errorMessage: e.Message);
      }
    }
  }
}
