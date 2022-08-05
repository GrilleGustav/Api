// <copyright file="IProductionTypeService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Pv.Storage
{
  /// <summary>
  /// Service to manage Pv battery production type in backend store.
  /// </summary>
  public interface IProductionTypeService
  {
    /// <summary>
    /// Get all production types.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of production types.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<ProductionType>>> GetAll();

    /// <summary>
    /// Get one production type.
    /// </summary>
    /// <param name="serverId">Production type backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a production type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionType>> GetOne(int id);

    /// <summary>
    /// Create production type entity.
    /// </summary>
    /// <param name="data">The Task that represents asynchronous operation, containing some errors or success.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionType>> Create(Vendor data);

    /// <summary>
    /// Update production type entity.
    /// </summary>
    /// <param name="vendor">Production type entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionType>> Update(Vendor data);

    /// <summary>
    /// Delete production type record.
    /// </summary>
    /// <param name="id">Production type entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<ProductionType>> Delete(int id);
  }
}
