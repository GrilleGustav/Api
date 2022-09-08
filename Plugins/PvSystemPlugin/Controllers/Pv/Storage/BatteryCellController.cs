// <copyright file="BatterCellController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
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

namespace PvSystemPlugin.Controllers.Pv.Storage
{
  /// <summary>
  /// Controller for battery cell.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class BatteryCellController : ControllerBase
  {
    private ILogger<BatteryCellController> _logger;
    private IBatteryCellService _batteryCellService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for battery cell.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="batteryCellService">Manage battery cell data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public BatteryCellController(ILogger<BatteryCellController> logger, IBatteryCellService batteryCellService, IMapper mapper)
    {
      _logger = logger;
      _batteryCellService = batteryCellService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all battery cells.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of battery cells.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<BatteryCellsResponse>> GetAll()
    {
      Result<List<BatteryCell>> result = await _batteryCellService.GetAll();

      if (result.Data == null)
      {
        BatteryCellsResponse response = new BatteryCellsResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new BatteryCellsResponse(_mapper.Map<IList<BatteryCell>, IList<BatteryCellViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one battery cell.
    /// </summary>
    /// <param name="id">Battery cell id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one battery cell.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<BatteryCellResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<BatteryCell> result = await _batteryCellService.GetOne(id);
      if (result.Data == null)
      {
        BatteryCellResponse response = new BatteryCellResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new BatteryCellResponse(_mapper.Map<BatteryCell, BatteryCellViewModel>(result.Data)));
    }

    /// <summary>
    /// Add battery cell.
    /// </summary>
    /// <param name="request">Battery cell add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] BatteryCellAddRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<BatteryCell> result = await _batteryCellService.Create(_mapper.Map<BatteryCellAddRequest, BatteryCell>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update battery cell entity.
    /// </summary>
    /// <param name="request">Battery cells update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<BatteryCellResponse>> Update([FromBody] BatteryCellUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<BatteryCell> result = await _batteryCellService.Update(_mapper.Map<BatteryCellUpdateRequest, BatteryCell>(request));
      BatteryCellResponse response = new BatteryCellResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.BatteryCell = _mapper.Map<BatteryCell, BatteryCellViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete battery cell.
    /// </summary>
    /// <param name="id">Battery cell id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<BatteryCell> result = await _batteryCellService.Delete(id);
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
