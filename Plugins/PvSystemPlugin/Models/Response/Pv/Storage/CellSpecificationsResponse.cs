// <copyright file="CellSpecificationsResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;
using System.Collections.Generic;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Cell specifications response.
  /// </summary>
  public class CellSpecificationsResponse : ErrorResponse
  {
    /// <summary>
    /// Cell specifications response.
    /// </summary>
    public CellSpecificationsResponse()
    { }

    /// <summary>
    /// Cell specifications response.
    /// </summary>
    /// <param name="cellSpecifications">List of cell specification.</param>
    public CellSpecificationsResponse(IList<CellSpecificationViewModel> cellSpecifications)
    {
      CellSpecifications = cellSpecifications;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set cell specifications.
    /// </summary>
    public IList<CellSpecificationViewModel> CellSpecifications { get; set; }
  }
}
