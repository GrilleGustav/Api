// <copyright file="ICellTypeService.cs" company="GrilleGustav">
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
  /// Service to manage Pv battery cell type in backend store.
  /// </summary>
  public interface ICellTypeService
  {
    /// <summary>
    /// Get all cell type.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of cell type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<CellType>>> GetAll();

    /// <summary>
    /// Get one cell type.
    /// </summary>
    /// <param name="id">Cell type backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a cell type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellType>> GetOne(int id);

    /// <summary>
    /// Create cell type entity.
    /// </summary>
    /// <param name="data">Cell type entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellType>> Create(CellType data);

    /// <summary>
    /// Update cell type entity.
    /// </summary>
    /// <param name="data">Production address entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellType>> Update(CellType data);

    /// <summary>
    /// Delete cell type record.
    /// </summary>
    /// <param name="id">Cell type entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<CellType>> Delete(int id);
  }
}
