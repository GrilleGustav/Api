// <copyright file="IPvStorageService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Pv.Storage
{
  /// <summary>
  /// Service to manage Pv storage in backend store.
  /// </summary>
  public interface IPvStorageService
  {
    /// <summary>
    /// Get all pv storages.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of pv storages.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<PvStorage>>> GetAll();

    /// <summary>
    /// Get one pv storage.
    /// </summary>
    /// <param name="id">Pv storage backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a pv storage.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<PvStorage>> GetOne(int id);

    /// <summary>
    /// Create pv storage entity.
    /// </summary>
    /// <param name="data">Pv storage entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<PvStorage>> Create(PvStorage data);

    /// <summary>
    /// Update pv storage entity.
    /// </summary>
    /// <param name="data">Pv storage entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<PvStorage>> Update(PvStorage data);

    /// <summary>
    /// Delete pv storage record.
    /// </summary>
    /// <param name="id">Pv storage entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<PvStorage>> Delete(int id);
  }
}
