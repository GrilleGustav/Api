// <copyright file="BatteryCellsResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Models.View.Pv.Storage;
using System.Collections.Generic;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Battery cells response.
  /// </summary>
  public class BatteryCellsResponse : ErrorResponse
  {
    /// <summary>
    /// Battery cells reponse.
    /// </summary>
    public BatteryCellsResponse()
    { }

    /// <summary>
    /// Battery cells response.
    /// </summary>
    /// <param name="batteryCells">List of Battery cells.</param>
    public BatteryCellsResponse(IList<BatteryCellViewModel> batteryCells)
    {
      this.BatteryCells = batteryCells;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set battery cells.
    /// </summary>
    public IList<BatteryCellViewModel> BatteryCells { get; set; }
  }
}
