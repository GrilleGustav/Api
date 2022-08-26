// <copyright file="VendorController.cs" company="GrilleGustav">
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
  /// Controller for pv-vendor.
  /// </summary>
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class VendorController : ControllerBase
  {
    private ILogger<VendorController> _logger;
    private IVendorService _vendorService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for pv-vendor.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="vendorService">Manage vendor data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public VendorController(ILogger<VendorController> logger, IVendorService vendorService, IMapper mapper)
    {
      _logger = logger;
      _vendorService = vendorService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all vendors.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of vendors.</returns>
    [Authorize(Roles = "Admin,View,Update,Create,Delete,PvStorageAdmin, PvStorageView,PvStorageUpdate,PvStorageCreate,PvStorageDelete")]
    [HttpGet("[action]")]
    public async Task<ActionResult<VendorsResponse>> GetAll()
    {
      Result<List<Vendor>> result = await _vendorService.GetAll();

      if (result.Data == null)
      {
        VendorsResponse response = new VendorsResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new VendorsResponse(_mapper.Map<IList<Vendor>, IList<VendorViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one vendor.
    /// </summary>
    /// <param name="id">Vendor id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one vendor.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<VendorResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<Vendor> result = await _vendorService.GetOne(id);
      if (result.Data == null)
      {
        VendorResponse response = new VendorResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new VendorResponse(_mapper.Map<Vendor, VendorViewModel>(result.Data)));
    }

    /// <summary>
    /// Add vendor.
    /// </summary>
    /// <param name="request">Vendor add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] VendorAddRequest request)
    {
       if (!ModelState.IsValid)
        return BadRequest();

      Result<Vendor> result = await _vendorService.Create(_mapper.Map<VendorAddRequest, Vendor>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update vendor entity.
    /// </summary>
    /// <param name="request">Vendor update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<VendorResponse>> Update([FromBody] VendorUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<Vendor> result = await _vendorService.Update(_mapper.Map<VendorUpdateRequest, Vendor>(request));
      VendorResponse response = new VendorResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.Vendor = _mapper.Map<Vendor, VendorViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete vendor.
    /// </summary>
    /// <param name="id">Vendor id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<Vendor> result = await _vendorService.Delete(id);
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
