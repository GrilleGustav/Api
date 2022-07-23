using AutoMapper;
using Entities.Models.Settings.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Response;
using Models.Response.Settings.Email;
using Models.View.Settings.Email;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
  /// <summary>
  /// Controller to manage template types.
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class TemplateTypeController : ControllerBase
  {
    private ILogger<TemplateTypeController> _logger;
    private ITemplateTypeService _templateTypeService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller for manage template types.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="templateTypeService">Service to manage template types in backend store.</param>
    /// <param name="maper">Mapper to copy the same properties of two different objects from the source object to target object.</param>
    public TemplateTypeController(ILogger<TemplateTypeController> logger, ITemplateTypeService templateTypeService, IMapper maper)
    {
      _logger = logger;
      _templateTypeService = templateTypeService;
      _mapper = maper;
    }

    /// <summary>
    /// Get all template tapes.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of template types.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<TemplateTypesResponse>> GetAll()
    {
      Result<List<TemplateType>> result = await _templateTypeService.GetAll();
      
      if (!result.IsSuccess)
      {
        TemplateTypesResponse response = new TemplateTypesResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error loading data.");
        return Ok(response);
      }

      return Ok(new TemplateTypesResponse(_mapper.Map<List<TemplateType>, List<TemplateTypeViewModel>>(result.Data)));
    }

    /// <summary>
    /// Get one template type.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing one template type.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<TemplateTypeResponse>> GetOne(int id)
    {
      if (id == 0)
        return BadRequest();

      Result<TemplateType> result = await _templateTypeService.GetOne(id);

      if (!result.IsSuccess)
      {
        TemplateTypeResponse response = new TemplateTypeResponse();
        response.AddErrors(result.Errors);
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error loading data.");
        return Ok(response);
      }

      return Ok(new TemplateTypeResponse(_mapper.Map<TemplateType, TemplateTypeViewModel>(result.Data)));
    }

    /// <summary>
    /// Add new template type.
    /// </summary>
    /// <param name="data">Template rype</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or if add fails.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Add(TemplateTypeViewModel data)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      Result<TemplateType> result = await _templateTypeService.Create(_mapper.Map<TemplateTypeViewModel, TemplateType>(data));
      if (!result.IsSuccess)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError("Error creating entity. Data not changed.");

        return Ok(new ErrorResponse(result.Errors));
      }

      return Ok(new ErrorResponse(true));
    }

    //[HttpPost("[action]")]
    //public async Task<ActionResult<TemplateTypeResponse>> Update(TemplateTypeViewModel data)
  }
}
