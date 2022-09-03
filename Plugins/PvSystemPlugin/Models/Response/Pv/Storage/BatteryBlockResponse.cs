// <copyright file="BatteryBlockResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Battery block response.
  /// </summary>
  public class BatteryBlockResponse : ErrorResponse
  {
    /// <summary>
    /// Battery block response.
    /// </summary>
    public BatteryBlockResponse()
    { }

    /// <summary>
    /// Battery block response.
    /// </summary>
    /// <param name="batteryBlock">Battery bock.</param>
    public BatteryBlockResponse(BatteryBlockViewModel batteryBlock)
    {
      this.BatteryBlock = batteryBlock;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set battery block.
    /// </summary>
    public BatteryBlockViewModel BatteryBlock { get; set; }
  }
}
