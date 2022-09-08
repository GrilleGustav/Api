// <copyright file="IProductionAddressService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models;
using PvSystemPlugin.Entities.Models.Pv.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PvSystemPlugin.Services.Interfaces.Pv.Storage
{
  /// <summary>
  /// Service to manage Pv battery production address in backend store.
  /// </summary>
  public interface IProductionAddressService
  {
    /// <summary>
    /// Get all production addresses.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of production addresses.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<ProductionAddress>>> GetAll();

    /// <summary>
    /// Get one production address.
    /// </summary>
    /// <param name="id">Production type backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a production address.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionAddress>> GetOne(int id);

    /// <summary>
    /// Create production address entity.
    /// </summary>
    /// <param name="data">Production address entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionAddress>> Create(ProductionAddress data);

    /// <summary>
    /// Update production address entity.
    /// </summary>
    /// <param name="data">Production address entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionAddress>> Update(ProductionAddress data);

    /// <summary>
    /// Delete production address record.
    /// </summary>
    /// <param name="id">Production address entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionAddress>> Delete(int id);
  }
}
