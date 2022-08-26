// <copyright file="BatteryBlockService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Services.Interfaces.Pv.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Pv.Storage
{
  /// <summary>
  /// Service to manage battery block in backend store.
  /// </summary>
  public class BatteryBlockService : IBatteryBlockService
  {
    private readonly ILogger<BatteryBlockService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage battery block in backend store.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    public BatteryBlockService(ILogger<BatteryBlockService> logger, IRepositoryManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all battery block.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of battery block.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<BatteryBlock>>> GetAll()
    {
      try
      {
        return new Result<List<BatteryBlock>>(await _repository.BatteryBlock.FindAll(false).Include(x => x.BatteryCells) .ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<BatteryBlock>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<BatteryBlock>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one battery block.
    /// </summary>
    /// <param name="id">Battery block backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a Battery block.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryBlock>> GetOne(int id)
    {
      try
      {
        return new Result<BatteryBlock>(await _repository.BatteryBlock.FindByCondition(x => x.Id == id, false).Include(x => x.BatteryCells).Include(x => x.PvComments).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryBlock>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryBlock>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryBlock>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create battery block entity.
    /// </summary>
    /// <param name="data">Battery block entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryBlock>> Create(BatteryBlock data)
    {
      try
      {
        _repository.BatteryBlock.Create(data);
        await _repository.SaveAsync();
        return new Result<BatteryBlock>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryBlock>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryBlock>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryBlock>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryBlock>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update batter block entity.
    /// </summary>
    /// <param name="data">Batter block entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryBlock>> Update(BatteryBlock data)
    {
      try
      {
        BatteryBlock batteryBlock = await _repository.BatteryBlock.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (batteryBlock.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.BatteryBlock.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<BatteryBlock> result = new Result<BatteryBlock>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(batteryBlock);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<BatteryBlock>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryBlock>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryBlock>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryBlock>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryBlock>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete battery block record.
    /// </summary>
    /// <param name="id">Battery block entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryBlock>> Delete(int id)
    {
      try
      {
        BatteryBlock batteryBlock = await _repository.BatteryBlock.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (batteryBlock != null)
        {
          _repository.BatteryBlock.Delete(batteryBlock);
          await _repository.SaveAsync();
          return new Result<BatteryBlock>(true);
        }

        return new Result<BatteryBlock>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryBlock>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryBlock>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryBlock>(new Error("1", "Error loading data."));
      }
    }
  }
}
