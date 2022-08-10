// <copyright file="IBatteryBlockService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Pv.Storage
{
  /// <summary>
  /// Service to manage battery block in backend store.
  /// </summary>
  public interface IBatteryBlockService
  {
    /// <summary>
    /// Get all battery block.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of battery block.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<BatteryBlock>>> GetAll();

    /// <summary>
    /// Get one battery block.
    /// </summary>
    /// <param name="id">Battery block backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a Battery block.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryBlock>> GetOne(int id);

    /// <summary>
    /// Create battery block entity.
    /// </summary>
    /// <param name="data">Battery block entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryBlock>> Create(BatteryBlock data);

    /// <summary>
    /// Update batter block entity.
    /// </summary>
    /// <param name="data">Batter block entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryBlock>> Update(BatteryBlock data);

    /// <summary>
    /// Delete battery block record.
    /// </summary>
    /// <param name="id">Battery block entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryBlock>> Delete(int id);
  }
}
