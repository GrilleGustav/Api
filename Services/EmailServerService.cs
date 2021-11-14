// <copyright file="EmailServerSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Request.Settings.Email;
using Models.Response;
using Models.Response.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
  public class EmailServerService : IEmailServerService
  {
    private readonly ILogger<EmailServerService> _logger;
    private readonly IRepositoryManager _repository;

    public EmailServerService(IRepositoryManager repository, ILogger<EmailServerService> logger)
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
      EmailServerSettingsResponse emailServerSettingsResponse = new EmailServerSettingsResponse();
      try
      {
        return new EmailServerSettingsResponse(await _repository.EmailServer.FindAll(false).ToListAsync());
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        emailServerSettingsResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailServerSettingsResponse;
      }
    }

    /// <summary>
    /// Get one email server.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email server entity. If fails return error code and or error message.</returns>
    public async Task<EmailServerSettingResponse> GetOne(int id)
    {
      EmailServerSettingResponse emailServerSettingResponse = new EmailServerSettingResponse();
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailServer == null)
        {
          emailServerSettingResponse.AddError(errorCode: "2", errorMessage: "Not found.");
          return emailServerSettingResponse;
        }

        return new EmailServerSettingResponse(emailServer);
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        emailServerSettingResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailServerSettingResponse;
      }
    }

    /// <summary>
    /// Get default email server.
    /// </summary>
    /// <returns>Email server entity.</returns>
    public async Task<EmailServerSettingResponse> GetDefault()
    {
      EmailServerSettingResponse emailServerSettingResponse = new EmailServerSettingResponse();
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true, false).SingleOrDefaultAsync();
        if (emailServer == null)
        {
          emailServerSettingResponse.AddError(errorCode: "3", errorMessage: "No default server found.");
          return emailServerSettingResponse;
        }

        return new EmailServerSettingResponse(emailServer);
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        emailServerSettingResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailServerSettingResponse;
      }
    }

    /// <summary>
    /// Update email server. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity.</param>
    /// <returns>If update failed return error code.</returns>
    public async Task<ErrorResponse> Update(EmailServer data)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      try
      {
        if (data.Default)
        {
          EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true && x.Id != data.Id, true).SingleOrDefaultAsync();
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
          {
            errorResponse.AddError(errorCode: "4", errorMessage: "Can´t set default server to false.");
            return errorResponse;
          }
        }

        _repository.EmailServer.Update(data);
        await _repository.SaveAsync();
        return errorResponse;
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }

    /// <summary>
    /// Create email server entity.  If entity to create default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity</param>
    /// <returns>If create failed return error code.</returns>
    public async Task<ErrorResponse> Create(EmailServer data)
    {
      ErrorResponse errorResponse = new ErrorResponse();
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
        errorResponse.IsSuccess = true;
        return errorResponse;
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }

    /// <summary>
    /// Delete one email server entity.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Error code and message if could not delete.</returns>
    public async Task<ErrorResponse> Delete(int id)
    {
      ErrorResponse errorResponse = new ErrorResponse();
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailServer != null)
        {
          if (emailServer.Default == true)
          {
            errorResponse.AddError(errorCode: "5", errorMessage: "Default server can´t delete. Choose some other as default server first.");
            return errorResponse;
          }

          _repository.EmailServer.Delete(emailServer);
          await _repository.SaveAsync();
          return errorResponse;
        }

        errorResponse.AddError(errorCode: "2", errorMessage: "Server not found.");
        return errorResponse;
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        errorResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return errorResponse;
      }
    }

    /// <summary>
    /// Check if server with Ip/Domain and port exist.
    /// </summary>
    /// <param name="emailServerExistRequest">Data object with Ip/Domain and port.</param>
    /// <returns>If fails return some error code and message, otherwise return true if server with Ip/Domain and port exist. If no server found return false.</returns>
    public async Task<EmailServerExistResponse> EmailServerExist(EmailServerExistRequest emailServerExistRequest)
    {
      EmailServerExistResponse emailServerExistResponse = new EmailServerExistResponse();
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
        emailServerExistResponse.AddError("1", e.Message);
        return emailServerExistResponse;
      }
    }
  }
}
