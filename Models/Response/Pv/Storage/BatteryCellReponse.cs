// <copyright file="BatteryCellResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Battery cell response.
  /// </summary>
  public class BatteryCellReponse : ErrorResponse
  {
    /// <summary>
    /// Battery cell reponse.
    /// </summary>
    public BatteryCellReponse()
    { }

    /// <summary>
    /// Battery cell response.
    /// </summary>
    /// <param name="batteryCell">Battery cell.</param>
    public BatteryCellReponse(BatteryCell batteryCell)
    {
      this.BatteryCell = batteryCell;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set battery cell.
    /// </summary>
    public BatteryCell BatteryCell { get; set; }
  }
}
