// <copyright file="TemplateTypeService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  /// <summary>
  /// Service to manage template types in backend store.
  /// </summary>
  public class TemplateTypeService : ITemplateTypeService
  {
    private readonly ILogger<TemplateTypeService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage template types in backend store.
    /// </summary>
    /// <param name="repository">Access to backend store.</param>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    public TemplateTypeService(IRepositoryManager repository, ILogger<TemplateTypeService> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    /// <summary>
    /// Get all template types.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing list of template types.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<TemplateType>>> GetAll()
    {
      try
      {
        return new Result<List<TemplateType>>(await _repository.TemplateType.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<TemplateType>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<TemplateType>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one template type.
    /// </summary>
    /// <param name="templateId">Template type id.</param>
    /// <returns>The Task that represents asynchronous operation, containing one template type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<TemplateType>> GetOne(int templateId)
    {
      try
      {
        return new Result<TemplateType>(await _repository.TemplateType.FindByCondition(x => x.Id == templateId, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<TemplateType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<TemplateType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<TemplateType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create template type entity.
    /// </summary>
    /// <param name="templateType">Template type entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<TemplateType>> Create(TemplateType templateType)
    {
      try
      {
        _repository.TemplateType.Create(templateType);
        await _repository.SaveAsync();
        return new Result<TemplateType>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<TemplateType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<TemplateType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<TemplateType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create template type entitys.
    /// </summary>
    /// <param name="templateType"></param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<TemplateType>> CreateRange(List<TemplateType> templateTypes)
    {
      try
      {
        _repository.TemplateType.CreateRange(templateTypes);
        await _repository.SaveAsync();
        return new Result<TemplateType>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<TemplateType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<TemplateType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<TemplateType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete template type entity.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<TemplateType>> Delete(int id)
    {
      try
      {
        TemplateType templateType = await _repository.TemplateType.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (templateType == null)
          return new Result<TemplateType>(new Error(errorCode: "8", errorMessage: "Can´t delete template type, type not found."));

        _repository.TemplateType.Delete(templateType);
        await _repository.SaveAsync();
        return new Result<TemplateType>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<TemplateType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<TemplateType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<TemplateType>(new Error("1", "Error loading data."));
      }
    }
  }
}
