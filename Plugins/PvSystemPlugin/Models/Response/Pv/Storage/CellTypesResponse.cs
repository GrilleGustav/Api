// <copyright file="CellTypesResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;
using System.Collections.Generic;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Cell types response.
  /// </summary>
  public class CellTypesResponse : ErrorResponse
  {
    /// <summary>
    /// Cell types response.
    /// </summary>
    public CellTypesResponse()
    { }

    /// <summary>
    /// Cell types response.
    /// </summary>
    /// <param name="cellType">Cell types.</param>
    public CellTypesResponse(IList<CellTypeViewModel> cellTypes)
    {
      this.CellTypes = cellTypes;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set cell types.
    /// </summary>
    public IList<CellTypeViewModel> CellTypes { get; set; }
  }
}
