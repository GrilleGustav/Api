// <copyright file="EmailServerSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Contracts;
using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Request.Settings.Email;
using Models.Response;
using Models.Response.Settings.Email;
using Models.View.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
  /// <summary>
  /// Service to manage email server in backend store.
  /// </summary>
  public class EmailServerService : IEmailServerService
  {
    private readonly ILogger<EmailServerService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage email server in backend store.
    /// </summary>
    /// <param name="repository">Access to backend store.</param>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    public EmailServerService(IRepositoryManager repository, ILogger<EmailServerService> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    /// <summary>
    /// Get all email servers.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of email servers.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<EmailServer>>> GetAll()
    {
      try
      {
        return new Result<List<EmailServer>>(await _repository.EmailServer.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<EmailServer>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<EmailServer>>(new Error("1", "Error loading data."));
      }
    }


    /// <summary>
    /// Get one email server.
    /// </summary>
    /// <param name="serverId">Email server backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a email server.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailServer>> GetOne(int serverId)
    {
      try
      {
        return new Result<EmailServer>(await _repository.EmailServer.FindByCondition(x => x.Id == serverId, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get default server.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a email server.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailServer>> GetDefault()
    {
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true, false).SingleOrDefaultAsync();
        if (emailServer == null)
        {
          if (_logger.IsEnabled(LogLevel.Error))
            _logger.LogError("Error loading data, no default server found.");

          return new Result<EmailServer>(new Error(errorCode: "2", errorMessage: "Error loading data, no default server found."));
        }

        return new Result<EmailServer>(emailServer);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update email server. If entity to update default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailServer>> Update(EmailServer data)
    {
      try
      {
        EmailServer emailServerOriginal = await _repository.EmailServer.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (emailServerOriginal.ConcurrencyStamp == data.ConcurrencyStamp)
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
            EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true && x.Id == data.Id, false).SingleOrDefaultAsync();
            if (emailServer != null)
            {
              _logger.LogError("Can´t set default server to false.");
              return new Result<EmailServer>(new Error(errorCode: "4", errorMessage: "Can´t set default record to false."));
            }
          }

          _repository.EmailServer.Update(data);
          if (string.IsNullOrWhiteSpace(data.ServerPassword))
            _repository.EmailServer.IgnoreProperty(data, x => x.ServerPassword);

          await _repository.SaveAsync();
          return new Result<EmailServer>(true);
        }
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<EmailServer> result = new Result<EmailServer>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(emailServerOriginal);
          result.IsSuccess = false;
          return result;
        }
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailServer>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailServer>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailServer>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailServer>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create email server entity.  If entity to create default == true, set other default to false.
    /// </summary>
    /// <param name="data">Email server entity</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailServer>> Create(EmailServer data)
    {
      try
      {
        if (data.Default)
        {
          EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true, false).SingleOrDefaultAsync();
          if (emailServer != null)
          {
            emailServer.Default = false;
            await _repository.SaveAsync();
          }
        }

        _repository.EmailServer.Create(data);
        await _repository.SaveAsync();
        return new Result<EmailServer>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailServer>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailServer>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<EmailServer>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete email server record.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<EmailServer>> Delete(int id)
    {
      try
      {
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (emailServer != null)
        {
          if (emailServer.Default == true)
          {
            return new Result<EmailServer>(new Error(errorCode: "7", errorMessage: "Can´t delete default server. Choose some other as default server first."));
          }

          _repository.EmailServer.Delete(emailServer);
          await _repository.SaveAsync();
          return new Result<EmailServer>(true);
        }

        return new Result<EmailServer>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<EmailServer>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Check if server with Ip/Domain and port exist.
    /// </summary>
    /// <param name="emailServerExistRequest">Data object with IP/Domain, port and Id. Id is only needed in the context of a change form.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result. Result  true if server with Ip/Domain and port exist. If no server found return false.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<EmailServerExistResponse> EmailServerExist(EmailServerExistRequest emailServerExistRequest)
    {
      try
      {
        // If not null server already exist.
        EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.ServerIp == emailServerExistRequest.ServerIp && x.ServerPort == emailServerExistRequest.ServerPort && x.Id != emailServerExistRequest.Id, false).SingleOrDefaultAsync();
        if (emailServer != null)
          return new EmailServerExistResponse(true);

        return new EmailServerExistResponse(false);
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return null;
      }
    }
  }
}
