// <copyright file="PvComments.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using System;

namespace Entities.Models.Pv
{
  /// <summary>
  /// Pv-Comments.
  /// </summary>
  public class PvComments
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set content.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// get or set pv storage id.
    /// </summary>
    public int? PvStorageId { get; set; }

    /// <summary>
    /// get or set battery block id.
    /// </summary>
    public int? BatteryBlockId { get; set; }

    /// <summary>
    /// get or set battery cell id.
    /// </summary>
    public int? BatterCellId { get; set; }

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
    /// Navigation property to pv storage.
    /// </summary>
    public PvStorage PvStorage { get; set; }

    /// <summary>
    /// Navigation property to battery block.
    /// </summary>
    public BatteryBlock BatteryBlock { get; set; }

    /// <summary>
    /// Navigation property to battery cell.
    /// </summary>
    public BatteryCell BatteryCell { get; set; }
  }
}
