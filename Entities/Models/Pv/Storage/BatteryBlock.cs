// <copyright file="BatteryBlock.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Entities.Models.Pv.Storage
{
  public class BatteryBlock
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

    // Navigation Properties.

    /// <summary>
    /// Navigation property to battery cell.
    /// </summary>
    public List<BatteryCell> BatteryCells { get; set; }

    /// <summary>
    /// Navigation property to pv storage.
    /// </summary>
    public PvStorage PvStorage { get; set; }
  }
}
