// <copyright file="CellSpecificationService.cs" company="GrilleGustav">
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
  /// Service to manage Pv battery cell specification in backend store.
  /// </summary>
  public class CellSpecificationService : ICellSpecificationService
  {
    private readonly ILogger<CellSpecificationService> _logger;
    private readonly IRepositoryPvManager _repository;

    /// <summary>
    /// Service to manage Pv battery cell specification in backend store.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    public CellSpecificationService(ILogger<CellSpecificationService> logger, IRepositoryPvManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all cell specification.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of cell specification.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<CellSpecification>>> GetAll()
    {
      try
      {
        return new Result<List<CellSpecification>>(await _repository.CellSpecification.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<CellSpecification>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<CellSpecification>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one cell specification.
    /// </summary>
    /// <param name="id">Cell specification backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a cell specification.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellSpecification>> GetOne(int id)
    {
      try
      {
        return new Result<CellSpecification>(await _repository.CellSpecification.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellSpecification>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellSpecification>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellSpecification>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create cell specification entity.
    /// </summary>
    /// <param name="data">Cell specification entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellSpecification>> Create(CellSpecification data)
    {
      try
      {
        _repository.CellSpecification.Create(data);
        await _repository.SaveAsync();
        return new Result<CellSpecification>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellSpecification>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellSpecification>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellSpecification>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellSpecification>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update cell specification entity.
    /// </summary>
    /// <param name="data">Cell specification entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellSpecification>> Update(CellSpecification data)
    {
      try
      {
        CellSpecification cellSpecification = await _repository.CellSpecification.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (cellSpecification.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.CellSpecification.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<CellSpecification> result = new Result<CellSpecification>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(cellSpecification);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<CellSpecification>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellSpecification>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellSpecification>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellSpecification>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<CellSpecification>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete cell specification record.
    /// </summary>
    /// <param name="id">Cell specification entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<CellSpecification>> Delete(int id)
    {
      try
      {
        CellSpecification cellSpecification = await _repository.CellSpecification.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (cellSpecification != null)
        {
          _repository.CellSpecification.Delete(cellSpecification);
          await _repository.SaveAsync();
          return new Result<CellSpecification>(true);
        }

        return new Result<CellSpecification>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellSpecification>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellSpecification>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<CellSpecification>(new Error("1", "Error loading data."));
      }
    }
  }
}
