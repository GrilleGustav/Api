// <copyright file=">BatteryBlockAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace PvSystemPlugin.Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new battery block.
  /// </summary>
  public class BatteryBlockAddRequest
  {
    /// <summary>
    /// Get or set name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Get or set Pv Storage id.
    /// </summary>
    public int PvStorageId { get; set; }
  }
}
