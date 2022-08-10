// <copyright file="IBatteryCellService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Pv.Storage
{
  /// <summary>
  /// Service to manage battery cell in backend store.
  /// </summary>
  public interface IBatteryCellService
  {
    /// <summary>
    /// Get all battery cell.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of battery cell.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<BatteryCell>>> GetAll();

    /// <summary>
    /// Get one battery cell.
    /// </summary>
    /// <param name="id">Battery cell backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a Battery cell.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryCell>> GetOne(int id);

    /// <summary>
    /// Create battery cell entity.
    /// </summary>
    /// <param name="data">Battery cell entity to create.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryCell>> Create(BatteryCell data);

    /// <summary>
    /// Update batter cell entity.
    /// </summary>
    /// <param name="data">Batter cell entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryCell>> Update(BatteryCell data);

    /// <summary>
    /// Delete battery cell record.
    /// </summary>
    /// <param name="id">Battery cell entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<BatteryCell>> Delete(int id);
  }
}
