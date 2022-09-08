// <copyright file="CellSpecificationController.cs" company="GrilleGustav">
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
  /// Controller for cell specification.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class CellSpecificationController : ControllerBase
  {
    private ILogger<CellSpecificationController> _logger;
    private ICellSpecificationService _cellSpecificationService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for cell specification.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="cellSpecificationService">Manage cell specification data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public CellSpecificationController(ILogger<CellSpecificationController> logger, ICellSpecificationService cellSpecificationService, IMapper mapper)
    {
      _logger = logger;
      _cellSpecificationService = cellSpecificationService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all cell specifications.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of cell specifications.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<CellSpecificationsResponse>> GetAll()
    {
      Result<List<CellSpecification>> result = await _cellSpecificationService.GetAll();

      if (result.Data == null)
      {
        CellSpecificationsResponse response = new CellSpecificationsResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new CellSpecificationsResponse(_mapper.Map<IList<CellSpecification>, IList<CellSpecificationViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one cell specification.
    /// </summary>
    /// <param name="id">Cell specifications id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one cell specifications.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<CellSpecificationResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<CellSpecification> result = await _cellSpecificationService.GetOne(id);
      if (result.Data == null)
      {
        CellSpecificationResponse response = new CellSpecificationResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new CellSpecificationResponse(_mapper.Map<CellSpecification, CellSpecificationViewModel>(result.Data)));
    }

    /// <summary>
    /// Add cell specifications.
    /// </summary>
    /// <param name="request">Cell specifications add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] CellSpecificationAddRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<CellSpecification> result = await _cellSpecificationService.Create(_mapper.Map<CellSpecificationAddRequest, CellSpecification>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update cell specifications entity.
    /// </summary>
    /// <param name="request">Cell specifications update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<CellSpecificationResponse>> Update([FromBody] CellSpecificationUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<CellSpecification> result = await _cellSpecificationService.Update(_mapper.Map<CellSpecificationUpdateRequest, CellSpecification>(request));
      CellSpecificationResponse response = new CellSpecificationResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.CellSpecification = _mapper.Map<CellSpecification, CellSpecificationViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete cell specifications.
    /// </summary>
    /// <param name="id">Cell specifications id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<CellSpecification> result = await _cellSpecificationService.Delete(id);
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
