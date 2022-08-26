// <copyright file="BatteryCellService.cs" company="GrilleGustav">
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
  /// Service to manage battery cell in backend store.
  /// </summary>
  public class BatteryCellService : IBatteryCellService
  {
    private readonly ILogger<BatteryCellService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage battery cell in backend store.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    public BatteryCellService(ILogger<BatteryCellService> logger, IRepositoryManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all battery cell.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of battery cell.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<BatteryCell>>> GetAll()
    {
      try
      {
        return new Result<List<BatteryCell>>(await _repository.BatteryCell.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<BatteryCell>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<BatteryCell>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one battery cell.
    /// </summary>
    /// <param name="id">Battery cell backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a Battery cell.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryCell>> GetOne(int id)
    {
      try
      {
        return new Result<BatteryCell>(await _repository.BatteryCell.FindByCondition(x => x.Id == id, false).Include(x => x.PvComments).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryCell>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryCell>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryCell>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create battery cell entity.
    /// </summary>
    /// <param name="data">Battery cell entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryCell>> Create(BatteryCell data)
    {
      try
      {
        _repository.BatteryCell.Create(data);
        await _repository.SaveAsync();
        return new Result<BatteryCell>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryCell>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryCell>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryCell>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryCell>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update batter cell entity.
    /// </summary>
    /// <param name="data">Batter cell entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryCell>> Update(BatteryCell data)
    {
      try
      {
        BatteryCell batteryCell = await _repository.BatteryCell.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (batteryCell.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.BatteryCell.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<BatteryCell> result = new Result<BatteryCell>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(batteryCell);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<BatteryCell>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryCell>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryCell>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryCell>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<BatteryCell>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete battery cell record.
    /// </summary>
    /// <param name="id">Battery cell entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<BatteryCell>> Delete(int id)
    {
      try
      {
        BatteryCell batteryCell = await _repository.BatteryCell.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (batteryCell != null)
        {
          _repository.BatteryCell.Delete(batteryCell);
          await _repository.SaveAsync();
          return new Result<BatteryCell>(true);
        }

        return new Result<BatteryCell>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryCell>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryCell>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<BatteryCell>(new Error("1", "Error loading data."));
      }
    }
  }
}
