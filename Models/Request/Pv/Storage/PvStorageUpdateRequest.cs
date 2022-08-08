// <copyright file="PvStorageUpdateRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Request.Pv.Storage
{
  /// <summary>
  /// Pv storage uodate request.
  /// </summary>
  public class PvStorageUpdateRequest
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    [Required]
    public int Id { get; set; }

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

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    [Required]
    public DateTime ConcurrencyStamp { get; set; }
  }
}
