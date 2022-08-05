// <copyright file="BatteryCellsResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using System.Collections.Generic;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Battery cells response.
  /// </summary>
  public class BatteryCellsReponse : ErrorResponse
  {
    /// <summary>
    /// Battery cells reponse.
    /// </summary>
    public BatteryCellsReponse()
    { }

    /// <summary>
    /// Battery cells response.
    /// </summary>
    /// <param name="batteryCells">List of Battery cells.</param>
    public BatteryCellsReponse(IList<BatteryCell> batteryCells)
    {
      this.BatteryCells = batteryCells;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set battery cells.
    /// </summary>
    public IList<BatteryCell> BatteryCells { get; set; }
  }
}
