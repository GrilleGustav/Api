// <copyright file="CellTypeResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Cell type response.
  /// </summary>
  public class CellTypeResponse : ErrorResponse
  {
    /// <summary>
    /// Cell type response.
    /// </summary>
    public CellTypeResponse()
    { }

    /// <summary>
    /// Cell type response.
    /// </summary>
    /// <param name="cellType">Cell type.</param>
    public CellTypeResponse(CellTypeViewModel cellType)
    {
      this.CellType = cellType;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set cell type.
    /// </summary>
    public CellTypeViewModel CellType { get; set; }
  }
}
