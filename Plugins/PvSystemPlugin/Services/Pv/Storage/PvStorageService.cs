// <copyright file="PvServiceService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using PvSystemPlugin.Contracts;
using PvSystemPlugin.Entities.Models.Pv.Storage;
using PvSystemPlugin.Services.Interfaces.Pv.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PvSystemPlugin.Services.Pv.Storage
{
  /// <summary>
  /// Service to manage Pv storage in backend store.
  /// </summary>
  public class PvStorageService : IPvStorageService
  {
    private readonly ILogger<PvStorageService> _logger;
    private readonly IRepositoryPvManager _repository;

    /// <summary>
    /// Service to manage Pv storage in backend store.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    public PvStorageService(ILogger<PvStorageService> logger, IRepositoryPvManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all pv storages.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of pv storages.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<PvStorage>>> GetAll()
    {
      try
      {
        return new Result<List<PvStorage>>(await _repository.PvStorage.FindAll(false).Include(x => x.BatteryBlocks).Include(x => x.PvComments).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<PvStorage>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<PvStorage>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one pv storage.
    /// </summary>
    /// <param name="id">Pv storage backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a pv storage.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<PvStorage>> GetOne(int id)
    {
      try
      {
        return new Result<PvStorage>(await _repository.PvStorage.FindByCondition(x => x.Id == id, false).Include(x => x.BatteryBlocks).Include(x => x.PvComments).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<PvStorage>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<PvStorage>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<PvStorage>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create pv storage entity.
    /// </summary>
    /// <param name="data">Pv storage entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<PvStorage>> Create(PvStorage data)
    {
      try
      {
        _repository.PvStorage.Create(data);
        await _repository.SaveAsync();
        return new Result<PvStorage>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<PvStorage>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<PvStorage>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<PvStorage>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<PvStorage>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update pv storage entity.
    /// </summary>
    /// <param name="data">Pv storage entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<PvStorage>> Update(PvStorage data)
    {
      try
      {
        PvStorage pvStorage = await _repository.PvStorage.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (pvStorage.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.PvStorage.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<PvStorage> result = new Result<PvStorage>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(pvStorage);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<PvStorage>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<PvStorage>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<PvStorage>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<PvStorage>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<PvStorage>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete pv storage record.
    /// </summary>
    /// <param name="id">Pv storage entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<PvStorage>> Delete(int id)
    {
      try
      {
        CellSpecification cellSpecification = await _repository.CellSpecification.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (cellSpecification != null)
        {
          _repository.CellSpecification.Delete(cellSpecification);
          await _repository.SaveAsync();
          return new Result<PvStorage>(true);
        }

        return new Result<PvStorage>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<PvStorage>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<PvStorage>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<PvStorage>(new Error("1", "Error loading data."));
      }
    }
  }
}
