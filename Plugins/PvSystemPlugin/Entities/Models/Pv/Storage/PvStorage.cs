﻿// <copyright file="PvStorage.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace PvSystemPlugin.Entities.Models.Pv.Storage
{
  /// <summary>
  /// Pv-Storage.
  /// </summary>
  public class PvStorage
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
    public DateTime ConcurrencyStamp { get; set; }

    /// <summary>
    /// A DateTime value that shows when record changed.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// A DateTime value that shows when record was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    // Navigation Propertys

    /// <summary>
    /// Navigation property to battery cell.
    /// </summary>
    public List<BatteryBlock> BatteryBlocks { get; set; }

    /// <summary>
    /// Navigation property to pv comments.
    /// </summary>
    public List<PvComments> PvComments { get; set; }
  }
}
