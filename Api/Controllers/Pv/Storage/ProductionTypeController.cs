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
  /// Controller for pv production type.
  /// </summary>
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class ProductionTypeController : ControllerBase
  {
    private ILogger<ProductionTypeController> _logger;
    private IProductionTypeService _productionTypeService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for pv production type.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="productionTypeService">Manage production type data.</param>
    /// <param name="mapper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public ProductionTypeController(ILogger<ProductionTypeController> logger, IProductionTypeService productionTypeService, IMapper mapper)
    {
      _logger = logger;
      _productionTypeService = productionTypeService;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all production types.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or list of production types.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<ProductionTypesResponse>> GetAll()
    {
      Result<List<ProductionType>> result = await _productionTypeService.GetAll();

      if (result.Data == null)
      {
        ProductionTypesResponse response = new ProductionTypesResponse();
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new ProductionTypesResponse(_mapper.Map<IList<ProductionType>, IList<ProductionTypeViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one productiontype.
    /// </summary>
    /// <param name="id">Production type id.</param>
    /// <returns>The Task that represents asynchronous operation, containing data loading error or one production type.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ProductionTypeResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<ProductionType> result = await _productionTypeService.GetOne(id);
      if (result.Data == null)
      {
        ProductionTypeResponse response = new ProductionTypeResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(result.Errors.FirstOrDefault().ErrorMessage);

        return Ok(response);
      }

      return Ok(new ProductionTypeResponse(_mapper.Map<ProductionType, ProductionTypeViewModel>(result.Data)));
    }

    /// <summary>
    /// Add production type.
    /// </summary>
    /// <param name="request">Production type add request.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add([FromBody] ProductionTypeAddRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<ProductionType> result = await _productionTypeService.Create(_mapper.Map<ProductionTypeAddRequest, ProductionType>(request));
      if (result.IsSuccess == false)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return StatusCode(201, new ErrorResponse(true));
    }

    /// <summary>
    /// Update production type entity.
    /// </summary>
    /// <param name="request">Production type update data.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<VendorResponse>> Update([FromBody] ProductionTypeUpdateRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<ProductionType> result = await _productionTypeService.Update(_mapper.Map<ProductionTypeUpdateRequest, ProductionType>(request));
      ProductionTypeResponse response = new ProductionTypeResponse();
      if (!result.IsSuccess)
      {
        response.AddError(errorCode: "5", errorMessage: "Error updating entity. Data not changed.");
        response.AddErrors(result.Errors);
        response.ProductionType = _mapper.Map<ProductionType, ProductionTypeViewModel>(result.Data);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error updating entity. Data not changed.");
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Delete production type.
    /// </summary>
    /// <param name="id">Production type id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(int id)
    {
      if (id == 0)
        return BadRequest();

      ErrorResponse response = new ErrorResponse();
      Result<ProductionType> result = await _productionTypeService.Delete(id);
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
