// <copyright file="BatterBlockController.cs" company="GrilleGustav">
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

namespace Api.Controllers.Pv.Storage
{
  /// <summary>
  /// Controller for battery block.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class BatteryBlockController : ControllerBase
  {
    private ILogger<BatteryBlockController> _logger;
    private IBatteryBlockService _batteryBlockService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for battery block.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="batteryblockService">Manage battery block data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public BatteryBlockController(ILogger<BatteryBlockController> logger, IBatteryBlockService batteryBlockService, IMapper mapper)
    {
      _logger = logger;
      _batteryBlockService = batteryBlockService;
      _mapper = mapper;
    }


    /// <summary>
    /// Get all battery block.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of battery block.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<BatteryBlocksResponse>> GetAll()
    {
      Result<List<BatteryBlock>> result = await _batteryBlockService.GetAll();

      if (result.Data == null)
      {
        BatteryBlocksResponse response = new BatteryBlocksResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new BatteryBlocksResponse(_mapper.Map<IList<BatteryBlock>, IList<BatteryBlockViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one battery block.
    /// </summary>
    /// <param name="id">Battery block id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one battery block.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<BatteryBlockResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<BatteryBlock> result = await _batteryBlockService.GetOne(id);
      if (result.Data == null)
      {
        BatteryBlockResponse response = new BatteryBlockResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new BatteryBlockResponse(_mapper.Map<BatteryBlock, BatteryBlockViewModel>(result.Data)));
    }

    /// <summary>
    /// Add battery block.
    /// </summary>
    /// <param name="request">Battery block add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] BatteryBlockAddRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<BatteryBlock> result = await _batteryBlockService.Create(_mapper.Map<BatteryBlockAddRequest, BatteryBlock>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update battery block entity.
    /// </summary>
    /// <param name="request">Battery block update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<BatteryBlockResponse>> Update([FromBody] BatteryBlockUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<BatteryBlock> result = await _batteryBlockService.Update(_mapper.Map<BatteryBlockUpdateRequest, BatteryBlock>(request));
      BatteryBlockResponse response = new BatteryBlockResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.BatteryBlock = _mapper.Map<BatteryBlock, BatteryBlockViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete battery block.
    /// </summary>
    /// <param name="id">Battery block id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<BatteryBlock> result = await _batteryBlockService.Delete(id);
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
