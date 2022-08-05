// <copyright file="BatteryBlockResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;

namespace Models.Response.Pv.Storage
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
    public BatteryBlockResponse(BatteryBlock batteryBlock)
    {
      this.BatteryBlock = batteryBlock;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set battery block.
    /// </summary>
    public BatteryBlock BatteryBlock { get; set; }
  }
}
