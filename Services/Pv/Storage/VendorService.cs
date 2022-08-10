// <copyright file="VendorService.cs" company="GrilleGustav">
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
  /// Service to manage Pv battery vendor in backend store.
  /// </summary>
  public class VendorService : IVendorService
  {
    private readonly ILogger<VendorService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage Pv battery vendor in backend store.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    public VendorService(ILogger<VendorService> logger, IRepositoryManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all vendors.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of vendors.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<Vendor>>> GetAll()
    {
      try
      {
        return new Result<List<Vendor>>(await _repository.Vendor.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<Vendor>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<Vendor>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one vendor.
    /// </summary>
    /// <param name="id">Vendor backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a vendor.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<Vendor>> GetOne(int id)
    {
      try
      {
        return new Result<Vendor>(await _repository.Vendor.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<Vendor>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<Vendor>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<Vendor>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create vendor entity.
    /// </summary>
    /// <param name="data">Vendor entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<Vendor>> Create(Vendor data)
    {
      try
      {
        _repository.Vendor.Create(data);
        await _repository.SaveAsync();
        return new Result<Vendor>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<Vendor>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<Vendor>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<Vendor>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<Vendor>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update vendor entity.
    /// </summary>
    /// <param name="data">Vendor entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<Vendor>> Update(Vendor data)
    {
      try
      {
        Vendor vendor = await _repository.Vendor.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (vendor.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.Vendor.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<Vendor> result = new Result<Vendor>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(vendor);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<Vendor>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<Vendor>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<Vendor>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<Vendor>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<Vendor>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete vendor record.
    /// </summary>
    /// <param name="id">Vendor entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<Vendor>> Delete(int id)
    {
      try
      {
        Vendor vendor = await _repository.Vendor.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (vendor != null)
        {
          _repository.Vendor.Delete(vendor);
          await _repository.SaveAsync();
          return new Result<Vendor>(true);
        }

        return new Result<Vendor>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<Vendor>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<Vendor>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<Vendor>(new Error("1", "Error loading data."));
      }
    }
  }
}
