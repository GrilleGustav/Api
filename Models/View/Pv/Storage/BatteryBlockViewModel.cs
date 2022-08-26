// <copyright file="BatteryBlockViewModel.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv;
using System;
using System.Collections.Generic;

namespace Models.View.Pv.Storage
{
  /// <summary>
  /// Battery block view model.
  /// </summary>
  public class BatteryBlockViewModel
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set name.
    /// </summary>
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
    public DateTime ConcurrencyStamp { get; set; }

    /// <summary>
    /// A DateTime value that shows when record changed.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// A DateTime value that shows when record was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    // Navigation properties.

    /// <summary>
    /// Navigation property to pv comments.
    /// </summary>
    public List<PvComments> PvComments { get; set; }
  }
}
