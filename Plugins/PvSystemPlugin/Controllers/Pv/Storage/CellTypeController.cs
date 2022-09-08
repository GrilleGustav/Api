// <copyright file="CellTypeController.cs" company="GrilleGustav">
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
  /// Controller for cell type.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class CellTypeController : ControllerBase
  {
    private ILogger<CellTypeController> _logger;
    private ICellTypeService _cellTypeService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for cell type.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="cellTypeService">Manage cell type data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public CellTypeController(ILogger<CellTypeController> logger, ICellTypeService cellTypeService, IMapper mapper)
    {
      _logger = logger;
      _cellTypeService = cellTypeService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all cell types.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of cell types.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<CellTypesResponse>> GetAll()
    {
      Result<List<CellType>> result = await _cellTypeService.GetAll();

      if (result.Data == null)
      {
        CellTypesResponse response = new CellTypesResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new CellTypesResponse(_mapper.Map<IList<CellType>, IList<CellTypeViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one cell type.
    /// </summary>
    /// <param name="id">Cell type id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one cell type.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<CellTypeResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<CellType> result = await _cellTypeService.GetOne(id);
      if (result.Data == null)
      {
        CellTypeResponse response = new CellTypeResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new CellTypeResponse(_mapper.Map<CellType, CellTypeViewModel>(result.Data)));
    }

    /// <summary>
    /// Add cell type.
    /// </summary>
    /// <param name="request">Cell type add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] CellTypeAddRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<CellType> result = await _cellTypeService.Create(_mapper.Map<CellTypeAddRequest, CellType>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update cell type entity.
    /// </summary>
    /// <param name="request">Cell type update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<CellTypeResponse>> Update([FromBody] CellTypeUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<CellType> result = await _cellTypeService.Update(_mapper.Map<CellTypeUpdateRequest, CellType>(request));
      CellTypeResponse response = new CellTypeResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.CellType = _mapper.Map<CellType, CellTypeViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete cell type.
    /// </summary>
    /// <param name="id">Cell type id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<CellType> result = await _cellTypeService.Delete(id);
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
