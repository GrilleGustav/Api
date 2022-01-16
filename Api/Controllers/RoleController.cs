// <copyright file="RoleController.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Contracts;
using Entities.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Request.Role;
using Models.Response;
using Models.Response.Group;
using Models.View.Settings.Role;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
  /// <summary>
  /// Controller to manage user roles.
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class RoleController : ControllerBase
  {
    RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Controller to manage user roles.
    /// </summary>
    /// <param name="roleManager">Instance to manage roles in database.</param>
    /// <param name="mapper">Mapper to map entities from database to view data.</param>
    public RoleController(RoleManager<Role> roleManager, IMapper mapper, IRepositoryManager repository)
    {
      _roleManager = roleManager;
      _mapper = mapper;
      _repository = repository;
    }

    /// <summary>
    /// Get all rolews from database.
    /// </summary>
    /// <returns>List of roles.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<RolesSettingsResponse>> GetAll()
    {
      return Ok(new RolesSettingsResponse(await _roleManager.Roles.ToListAsync()));
    }

    /// <summary>
    /// Get one role.
    /// </summary>
    /// <param name="id">Role id.</param>
    /// <returns>Return role. Otherwise return one or more errors.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<RoleSettingsResponse>> GetOne(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        return BadRequest();

      RoleSettingsResponse response = new RoleSettingsResponse();
      Role role = await _roleManager.FindByIdAsync(id);
      if (role == null)
      {
        response.AddError(errorCode: "20", errorMessage: "Role not found");
        return Ok(response);
      }

      return Ok(new RoleSettingsResponse(role));
    }

    /// <summary>
    /// Add new role.
    /// </summary>
    /// <param name="request">Role data with name and description.</param>
    /// <returns>Return added role. Otherwise return one or more errors.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<RoleSettingsResponse>> Add([FromBody] RoleAddRequest request)
    {
      RoleSettingsResponse response = new RoleSettingsResponse();

      // Return bad request if input data send.
      if (request == null)
        return BadRequest();

      // Return bad request if input modelm data not valid.
      if (!ModelState.IsValid)
        return BadRequest();

      if (await _roleManager.RoleExistsAsync(request.Name))
      {
        response.IsSuccess = false;
        response.AddError(errorCode: "23", errorMessage: "Role with name already exist.");
        return Ok(response);
      }
      Role role = new Role(name: request.Name, description: request.Discription);
      IdentityResult result = await _roleManager.CreateAsync(role);
      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
        {
          response.AddError(errorCode: error.Code, errorMessage: error.Description);
        }
        return Ok(response);
      }

      response.IsSuccess = true;
      response.Role = await _roleManager.FindByNameAsync(request.Name);
      foreach (string value in request.Claims)
      {
        var claim = new Claim(ClaimTypes.Role, value);
        IdentityResult claimResult = await _roleManager.AddClaimAsync(role, claim);
        if (!claimResult.Succeeded)
        {
          foreach (var error in result.Errors)
          {
            response.AddError(errorCode: error.Code, errorMessage: error.Description);
          }
          return Ok(response);
        }
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Update role name or description.
    /// </summary>
    /// <param name="request">Changed role.</param>
    /// <returns>if role successfuly changed return true. Otherwise return one or more errors.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> Update([FromBody] RoleUpdateRequest request)
    {
      ErrorResponse response = new ErrorResponse();

      // Return bad request if input modelm data not valid.
      if (!ModelState.IsValid)
        return BadRequest();

      IdentityResult result = await _roleManager.UpdateAsync(request.Role);

      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
        {
          response.AddError(errorCode: error.Code, errorMessage: error.Description);
        }
        return Ok(response);
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Remove role with all related claims.
    /// </summary>
    /// <param name="id">Role id.</param>
    /// <returns>Return success true if role successfuly removed. Otherwise return one or more errors.</returns>
    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<ErrorResponse>> Delete(string id)
    {
      ErrorResponse response = new ErrorResponse();
      if (string.IsNullOrWhiteSpace(id))
        return BadRequest();

      Role role = await _roleManager.FindByIdAsync(id);
      if (role == null)
      {
        response.AddError(errorCode: "20", errorMessage: "Role not found");
        return Ok(response);
      }

      IdentityResult result = await _roleManager.DeleteAsync(role);
      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
        {
          response.AddError(errorCode: error.Code, errorMessage: error.Description);
        }
        return Ok(response);
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    /// <summary>
    /// Return claims from specified role.
    /// </summary>
    /// <param name="roleId">Role id.</param>
    /// <returns>List of claims. Otherwise return one or more errors.</returns>
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ClaimsSettingsResponse>> GetClaimsFromRole(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        return BadRequest();

      ClaimsSettingsResponse response = new ClaimsSettingsResponse();
      Role role = await _roleManager.FindByIdAsync(id);
      if (role == null)
      {
        response.AddError(errorCode: "20", errorMessage: "Role not found");
        return Ok(response);
      }

      IList<Claim> claims = await _roleManager.GetClaimsAsync(role);

      return Ok(new ClaimsSettingsResponse(_mapper.Map<IList<ClaimViewModel>>(claims)));
    }

    /// <summary>
    /// Add claim to role.
    /// </summary>
    /// <param name="request">Role and claim value.</param>
    /// <returns>If claim is added return is_success = true. Otherwise return one or more errors.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> AddClaimToRole([FromBody] ClaimRequest request)
    {
      ErrorResponse response = new ErrorResponse();

      // Return bad request if input data send.
      if (request == null)
        return BadRequest();

      // Return bad request if input modelm data not valid.
      else if (!ModelState.IsValid)
        return BadRequest();

      Role role = await _roleManager.FindByIdAsync(request.RoleId);

      if (role == null)
      {
        response.AddError(errorCode: "20", errorMessage: "Role not found");
        return Ok(response);
      }
      Claim claim = new Claim(ClaimTypes.Role, request.ClaimValue);
      IdentityResult result = await _roleManager.AddClaimAsync(role, claim);
      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
        {
          response.AddError(errorCode: error.Code, errorMessage: error.Description);
        }
        return Ok(response);
      }

      response.IsSuccess = true;
      return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> UpdateRoleClaims([FromBody] ClaimsRequest request)
    {
      ErrorResponse response = new ErrorResponse(true);
      if (request == null)
        return BadRequest();
      Role role = await _roleManager.FindByIdAsync(request.RoleId);
      IList<Claim> claims = await _roleManager.GetClaimsAsync(role);
      // Create new claims
      List<Claim> requestClaims = new List<Claim>();
      foreach (string claimValue in request.Claims)
      {
        requestClaims.Add(new Claim(ClaimTypes.Role, claimValue));
      }
      // Claims how needs to delete.
      List<Claim> d = claims.Where(x => !requestClaims.Any(y => y.Value == x.Value)).ToList();
      List<Claim> a = requestClaims.Where(x => !claims.Any(y => y.Value == x.Value)).ToList();
      foreach (Claim claim in d)
      {
        await _roleManager.RemoveClaimAsync(role, claim);
      }

      foreach (Claim claim in a)
      {
        await _roleManager.AddClaimAsync(role, claim);
      }

      return Ok(response);

    }

    /// <summary>
    /// Remove claim from role.
    /// </summary>
    /// <param name="request">Role and claim from role to remove.</param>
    /// <returns>If claim was removed from role return is_success = true. Otherwise return one or more errors.</returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<ErrorResponse>> RemoveClaimFromRole([FromBody] ClaimRequest request)
    {
      ErrorResponse response = new ErrorResponse();

      // Return bad request if input data send.
      if (request == null)
        return BadRequest();

      // Return bad request if input modelm data not valid.
      else if (!ModelState.IsValid)
        return BadRequest();

      Role role = await _roleManager.FindByIdAsync(request.RoleId);

      if (role == null)
      {
        response.AddError(errorCode: "20", errorMessage: "Role not found");
        return Ok(response);
      }

      IList<Claim> claims = await _roleManager.GetClaimsAsync(role);
      if (claims.Count == 0)
      {
        response.AddError(errorCode: "22", errorMessage: "No claims found in role.");
        return Ok(response);
      }

      Claim claim = claims.Where(x => x.Value == request.ClaimValue).SingleOrDefault();
      if (claim == null)
      {
        response.AddError(errorCode: "21", errorMessage: "Record to be deleted not found.");
        return Ok(response);
      }

      await _roleManager.RemoveClaimAsync(role, claim);
      response.IsSuccess = true;
      return Ok(response);
    }

  }
}
