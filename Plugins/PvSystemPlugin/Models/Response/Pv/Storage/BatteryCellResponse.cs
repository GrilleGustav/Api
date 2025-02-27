﻿// <copyright file="BatteryCellResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Battery cell response.
  /// </summary>
  public class BatteryCellResponse : ErrorResponse
  {
    /// <summary>
    /// Battery cell reponse.
    /// </summary>
    public BatteryCellResponse()
    { }

    /// <summary>
    /// Battery cell response.
    /// </summary>
    /// <param name="batteryCell">Battery cell.</param>
    public BatteryCellResponse(BatteryCellViewModel batteryCell)
    {
      this.BatteryCell = batteryCell;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set battery cell.
    /// </summary>
    public BatteryCellViewModel BatteryCell { get; set; }
  }
}
