// <copyright file="ProductionAddressController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Entities.Models.Pv.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Request.Pv.Storage;
using Models.Response;
using Models.Response.Pv.Storage;
using Models.View.Pv.Storage;
using Services.Interfaces.Pv.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.Pv.Storage
{
  /// <summary>
  /// Controller for production address.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class ProductionAddressController : ControllerBase
  {
    private ILogger<ProductionAddressController> _logger;
    private IProductionAddressService _productionAddressService;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="productionAddressService">Manage production address data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public ProductionAddressController(ILogger<ProductionAddressController> logger, IProductionAddressService productionAddressService, IMapper mapper)
    {
      _logger = logger;
      _productionAddressService = productionAddressService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all production addresses.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of production addressses.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<ProductionAddressesResponse>> GetAll()
    {
      Result<List<ProductionAddress>> result = await _productionAddressService.GetAll();

      if (result.Data == null)
      {
        ProductionAddressesResponse response = new ProductionAddressesResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new ProductionAddressesResponse(_mapper.Map<IList<ProductionAddress>, IList<ProductionAddressViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one production address.
    /// </summary>
    /// <param name="id">Production address id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one production address.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ProductionAddressResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<ProductionAddress> result = await _productionAddressService.GetOne(id);
      if (result.Data == null)
      {
        ProductionAddressResponse response = new ProductionAddressResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new ProductionAddressResponse(_mapper.Map<ProductionAddress, ProductionAddressViewModel>(result.Data)));
    }

    /// <summary>
    /// Add production address.
    /// </summary>
    /// <param name="request">Production address add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] ProductionAddressAddRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<ProductionAddress> result = await _productionAddressService.Create(_mapper.Map<ProductionAddressAddRequest, ProductionAddress>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update production address entity.
    /// </summary>
    /// <param name="request">Production address update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ProductionAddressResponse>> Update([FromBody] ProductionAddressUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<ProductionAddress> result = await _productionAddressService.Update(_mapper.Map<ProductionAddressUpdateRequest, ProductionAddress>(request));
      ProductionAddressResponse response = new ProductionAddressResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.ProductionAddress = _mapper.Map<ProductionAddress, ProductionAddressViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete production address.
    /// </summary>
    /// <param name="id">production address id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<ProductionAddress> result = await _productionAddressService.Delete(id);
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
