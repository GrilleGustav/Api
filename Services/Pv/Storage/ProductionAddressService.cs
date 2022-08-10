// <copyright file="ProductionAddressService.cs" company="GrilleGustav">
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
using System.Text;
using System.Threading.Tasks;

namespace Services.Pv.Storage
{
  /// <summary>
  /// Service to manage Pv battery production address in backend store.
  /// </summary>
  public class ProductionAddressService : IProductionAddressService
  {
    private readonly ILogger<ProductionAddressService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage Pv battery production address in backend store.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    public ProductionAddressService(ILogger<ProductionAddressService> logger, IRepositoryManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all production addresses.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of production addresses.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<ProductionAddress>>> GetAll()
    {
      try
      {
        return new Result<List<ProductionAddress>>(await _repository.ProductionAddress.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<ProductionAddress>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<ProductionAddress>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one production address.
    /// </summary>
    /// <param name="id">Production address backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a production address.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionAddress>> GetOne(int id)
    {
      try
      {
        return new Result<ProductionAddress>(await _repository.ProductionAddress.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionAddress>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionAddress>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionAddress>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create production address entity.
    /// </summary>
    /// <param name="data">Production address entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionAddress>> Create(ProductionAddress data)
    {
      try
      {
        _repository.ProductionAddress.Create(data);
        await _repository.SaveAsync();
        return new Result<ProductionAddress>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionAddress>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionAddress>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionAddress>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionAddress>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update production address entity.
    /// </summary>
    /// <param name="data">Production address entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionAddress>> Update(ProductionAddress data)
    {
      try
      {
        ProductionAddress productionAddress = await _repository.ProductionAddress.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (productionAddress.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.ProductionAddress.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<ProductionAddress> result = new Result<ProductionAddress>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(productionAddress);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<ProductionAddress>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionAddress>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionAddress>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionAddress>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionAddress>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete production address record.
    /// </summary>
    /// <param name="id">Production address entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionAddress>> Delete(int id)
    {
      try
      {
        ProductionAddress productionAddress = await _repository.ProductionAddress.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (productionAddress != null)
        {
          _repository.ProductionAddress.Delete(productionAddress);
          await _repository.SaveAsync();
          return new Result<ProductionAddress>(true);
        }

        return new Result<ProductionAddress>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionAddress>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionAddress>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionAddress>(new Error("1", "Error loading data."));
      }
    }
  }
}
