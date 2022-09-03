// <copyright file="PvStoragesResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;
using System.Collections.Generic;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Pv storages response.
  /// </summary>
  public class PvStoragesResponse : ErrorResponse
  {
    /// <summary>
    /// Pv storages response.
    /// </summary>
    public PvStoragesResponse()
    { }

    /// <summary>
    /// Pv storages response.
    /// </summary>
    /// <param name="pvStorages">Pv storages.</param>
    public PvStoragesResponse(IList<PvStorageViewModel> pvStorages)
    {
      this.PvStorages = pvStorages;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set pv storages.
    /// </summary>
    public IList<PvStorageViewModel> PvStorages { get; set; }
  }
}
