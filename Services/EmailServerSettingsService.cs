// <copyright file="EmailServerSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Request.Settings.Email;
using Models.Response;
using Models.Response.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class EmailServerSettingsService : IEmailServerSettingsService
  {
    private readonly ILogger<EmailServerSettingsService> _logger;
    private readonly IRepositoryManager _repository;
    public EmailServerSettingsService(IRepositoryManager repository, ILogger<EmailServerSettingsService> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    /// <summary>
    /// Get all email server.
    /// </summary>
    /// <returns>List of email servers. If fails error code and error message.</returns>
    public async Task<EmailServerSettingsResponse> GetAll()
    {
      try
      {
        return new EmailServerSettingsResponse(await _repository.EmailServer.FindAll(false).ToListAsync());
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailServerSettingsResponse("EmailServerSettings_1", e.Message);
      }
    }

    /// <summary>
    /// Get one email server.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email server entity. If fails return error code and or error message.</returns>
    public async Task<EmailServerSettingResponse> GetOne(int id)
    {
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailServer == null)
          return new EmailServerSettingResponse(errorCode: "EmailServerSettings_2", errorMessage: "No server found.");

        return new EmailServerSettingResponse(emailServer);
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailServerSettingResponse("EmailServerSettings_3", e.Message);
      }
    }

    /// <summary>
    /// Get one email server with senders.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email server entity with senders. If fails return error code and or error message.</returns>
    public async Task<EmailServerSettingResponse> GetOneWithSenders(int id)
    {
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Id == id, false).Include(x => x.EmailSender).FirstOrDefaultAsync();
        if (emailServer == null)
          return new EmailServerSettingResponse(errorCode: "EmailServerSettings_13", errorMessage: "No server found.");

        return new EmailServerSettingResponse(emailServer);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailServerSettingResponse("EmailServerSettings_14", e.Message);
      }
    }

    /// <summary>
    /// Get default email server.
    /// </summary>
    /// <returns>Email server entity.</returns>
    public async Task<EmailServerSettingResponse> GetDefault()
    {
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true, false).SingleOrDefaultAsync();
        if (emailServer == null)
          return new EmailServerSettingResponse(errorCode: "EmailServerSettings_4", errorMessage: "No default server found.");

        return new EmailServerSettingResponse(emailServer);
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailServerSettingResponse("EmailServerSettings_5", e.Message);
      }
    }

    /// <summary>
    /// Update email server. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity.</param>
    /// <returns>If update failed return error code.</returns>
    public async Task<ErrorResponse> Update(EmailServer data)
    {
      try
      {
        if (data.Default)
        {
          EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true, true).SingleOrDefaultAsync();
          if (emailServer != null)
          {
            emailServer.Default = false;
            await _repository.SaveAsync();
          }
        }
        else
        {
          EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true && x.Id == data.Id, true).SingleOrDefaultAsync();
          if (emailServer != null)
            return new ErrorResponse(errorCode: "EmailServerSettings_6", errorMessage: "Can´t set default server to false.");
        }

        _repository.EmailServer.Update(data);
        await _repository.SaveAsync();
        return new ErrorResponse(errorCode: "EmailServerSettings_0");
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new ErrorResponse(errorCode: "EmailServerSettings_7", errorMessage: e.Message);
      }
    }

    /// <summary>
    /// Create email server entity.  If entity to create default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity</param>
    /// <returns>If create failed return error code.</returns>
    public async Task<ErrorResponse> Create(EmailServer data)
    {
      try
      {
        if (data.Default)
        {
          EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true, true).SingleOrDefaultAsync();
          if (emailServer != null)
          {
            emailServer.Default = false;
            await _repository.SaveAsync();
          }
        }

        _repository.EmailServer.Create(data);
        await _repository.SaveAsync();
        return new ErrorResponse(errorCode: "EmailServerSettings_0");
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return new ErrorResponse(errorCode: "EmailServerSettings_8", errorMessage: e.Message);
      }
    }

    /// <summary>
    /// Delete one email server entity.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Error code and message if could not delete.</returns>
    public async Task<ErrorResponse> Delete(int id)
    {
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailServer != null)
        {
          if (emailServer.Default == true)
            return new ErrorResponse(errorCode: "EmailServerSettings_9", errorMessage: "Default server can´t delete. Choose some other as default server first.");

          _repository.EmailServer.Delete(emailServer);
          await _repository.SaveAsync();
          return new ErrorResponse(errorCode: "EmailServerSettings_0");
        }

        return new ErrorResponse(errorCode: "EmailServerSettings_10", errorMessage: "Server not found.");
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return new ErrorResponse(errorCode: "EmailServerSettings_11", errorMessage: e.Message);
      }
    }

    /// <summary>
    /// Check if server with Ip/Domain and port exist.
    /// </summary>
    /// <param name="emailServerExistRequest">Data object with Ip/Domain and port.</param>
    /// <returns>If fails return some error code and message, otherwise return true if server with Ip/Domain and port exist. If no server found return false.</returns>
    public async Task<EmailServerExistResponse> EmailServerExist(EmailServerExistRequest emailServerExistRequest)
    {
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.ServerIp == emailServerExistRequest.ServerIp && x.ServerPort == emailServerExistRequest.ServerPort && x.Id != emailServerExistRequest.Id, false).SingleOrDefaultAsync();
        if (emailServer != null)
          return new EmailServerExistResponse(true);

        return new EmailServerExistResponse(false);
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        return new EmailServerExistResponse("EmailServerSettings_12", e.Message);
      }
    }
  }
}
