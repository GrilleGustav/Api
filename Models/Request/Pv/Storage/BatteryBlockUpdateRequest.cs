// <copyright file="BatteryBlockUpdateRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Request.Pv.Storage
{
  /// <summary>
  /// Battery block update request.
  /// </summary>
  public class BatteryBlockUpdateRequest
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
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Get or set Pv Storage id.
    /// </summary>
    public int PvStorageId { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    [Required]
    public DateTime ConcurrencyStamp { get; set; }

    /// <summary>
    /// A DateTime value that shows when record changed.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// A DateTime value that shows when record was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    // Navigation Properties.

    /// <summary>
    /// Navigation property to pv storage.
    /// </summary>
    public PvStorage PvStorage { get; set; }
  }
}
