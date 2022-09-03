// <copyright file=">PvStorageAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace PvSystemPlugin.Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new pv storage.
  /// </summary>
  public class PvStorageAddRequest
  {
    /// <summary>
    /// Get or set name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set usable capacity.
    /// </summary>
    public double UsableCapacity { get; set; }

    /// <summary>
    /// Get or set capacity.
    /// </summary>
    public double Capacity { get; set; }

    /// <summary>
    /// Get or set battery valtage.
    /// </summary>
    public double BatteryVoltage { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }
  }
}
