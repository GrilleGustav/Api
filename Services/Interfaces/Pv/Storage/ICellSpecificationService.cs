// <copyright file="ICellSpecificationService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Pv.Storage
{
  /// <summary>
  /// Service to manage Pv battery cell specification in backend store.
  /// </summary>
  public interface ICellSpecificationService
  {
    /// <summary>
    /// Get all cell specification.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of cell specification.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<CellSpecification>>> GetAll();

    /// <summary>
    /// Get one cell specification.
    /// </summary>
    /// <param name="id">Cell specification backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a cell specification.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellSpecification>> GetOne(int id);

    /// <summary>
    /// Create cell specification entity.
    /// </summary>
    /// <param name="data">Cell specification entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellSpecification>> Create(CellSpecification data);

    /// <summary>
    /// Update cell specification entity.
    /// </summary>
    /// <param name="data">cell specification entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellSpecification>> Update(CellSpecification data);

    /// <summary>
    /// Delete cell specification record.
    /// </summary>
    /// <param name="id">Cell specification entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellSpecification>> Delete(int id);
  }
}
