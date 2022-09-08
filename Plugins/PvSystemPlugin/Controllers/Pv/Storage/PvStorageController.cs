// <copyright file="PvStorageController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response;
using PvSystemPlugin.Entities.Models.Pv.Storage;
using PvSystemPlugin.Models.Request.Pv.Storage;
using PvSystemPlugin.Models.Response.Pv.Storage;
using PvSystemPlugin.Models.View.Pv.Storage;
using PvSystemPlugin.Services.Interfaces.Pv.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.Pv.Storage
{
  /// <summary>
  /// Controller for pv-storage.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class PvStorageController : ControllerBase
  {
    private ILogger<PvStorageController> _logger;
    private IPvStorageService _pvStorageService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for pv-storage.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="pvStorageService">Manage pv storage data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public PvStorageController(ILogger<PvStorageController> logger, IPvStorageService pvStorageService, IMapper mapper)
    {
      _logger = logger;
      _pvStorageService = pvStorageService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all pv storages.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of pv storages.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<PvStoragesResponse>> GetAll()
    {
      Result<List<PvStorage>> result = await _pvStorageService.GetAll();

      if (result.Data == null)
      {
        PvStoragesResponse response = new PvStoragesResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new PvStoragesResponse(_mapper.Map<IList<PvStorage>, IList<PvStorageViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one pv storage.
    /// </summary>
    /// <param name="id">Pv storage id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one pv storage.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<PvStorageResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<PvStorage> result = await _pvStorageService.GetOne(id);
      if (result.Data == null)
      {
        PvStorageResponse response = new PvStorageResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new PvStorageResponse(_mapper.Map<PvStorage, PvStorageViewModel>(result.Data)));
    }

    /// <summary>
    /// Add pv storage.
    /// </summary>
    /// <param name="request">Pv storage add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] PvStorageAddRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<PvStorage> result = await _pvStorageService.Create(_mapper.Map<PvStorageAddRequest, PvStorage>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update pv storage entity.
    /// </summary>
    /// <param name="request">Pv storage update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<PvStorageResponse>> Update([FromBody] PvStorageUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<PvStorage> result = await _pvStorageService.Update(_mapper.Map<PvStorageUpdateRequest, PvStorage>(request));
      PvStorageResponse response = new PvStorageResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.PvStorage = _mapper.Map<PvStorage, PvStorageViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete pv storage.
    /// </summary>
    /// <param name="id">Pv storage id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<PvStorage> result = await _pvStorageService.Delete(id);
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "9", errorMessage: "Error deleting record.");
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error deleting record.");

        response.AddErrors(result.Errors);
      }
      return Ok(response);
    }
  }
}
