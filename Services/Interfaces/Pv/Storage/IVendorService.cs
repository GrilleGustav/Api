// <copyright file="IVendorService.cs" company="GrilleGustav">
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
  /// Service to manage Pv battery vendor in backend store.
  /// </summary>
  public interface IVendorService
  {
    /// <summary>
    /// Get all vendors.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of vendors.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<Vendor>>> GetAll();

    /// <summary>
    /// Get one vendor.
    /// </summary>
    /// <param name="serverId">Vendor backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a vendor.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<Vendor>> GetOne(int serverId);

    /// <summary>
    /// Create vendor entity.
    /// </summary>
    /// <param name="data">The Task that represents asynchronous operation, containing some errors or success.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<Vendor>> Create(Vendor data);

    /// <summary>
    /// Update vendor.
    /// </summary>
    /// <param name="vendor">Vendor entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<Vendor>> Update(Vendor data);

    /// <summary>
    /// Delete vendor record.
    /// </summary>
    /// <param name="id">Vendor entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<Vendor>> Delete(int id);
  }
}
