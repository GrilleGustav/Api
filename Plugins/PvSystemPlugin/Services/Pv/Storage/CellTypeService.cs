// <copyright file="CellTypeService.cs" company="GrilleGustav">
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
  /// Service to manage Pv battery cell type in backend store.
  /// </summary>
  public class CellTypeService : ICellTypeService
  {
    private readonly ILogger<CellTypeService> _logger;
    private readonly IRepositoryPvManager _repository;

    /// <summary>
    /// Service to manage Pv battery cell type in backend store.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    public CellTypeService(ILogger<CellTypeService> logger, IRepositoryPvManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all cell type.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of cell type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<CellType>>> GetAll()
    {
      try
      {
        return new Result<List<CellType>>(await _repository.CellType.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<CellType>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<CellType>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one cell type.
    /// </summary>
    /// <param name="id">Cell type backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a cell type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellType>> GetOne(int id)
    {
      try
      {
        return new Result<CellType>(await _repository.CellType.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create cell type entity.
    /// </summary>
    /// <param name="data">Cell type entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellType>> Create(CellType data)
    {
      try
      {
        _repository.CellType.Create(data);
        await _repository.SaveAsync();
        return new Result<CellType>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellType>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellType>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update cell type entity.
    /// </summary>
    /// <param name="data">Cell Type entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellType>> Update(CellType data)
    {
      try
      {
        CellType cellType = await _repository.CellType.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (cellType.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.CellType.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<CellType> result = new Result<CellType>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(cellType);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<CellType>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellType>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellType>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete cell type record.
    /// </summary>
    /// <param name="id">Cell type entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellType>> Delete(int id)
    {
      try
      {
        CellType cellType = await _repository.CellType.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (cellType != null)
        {
          _repository.CellType.Delete(cellType);
          await _repository.SaveAsync();
          return new Result<CellType>(true);
        }

        return new Result<CellType>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellType>(new Error("1", "Error loading data."));
      }
    }
  }
}
