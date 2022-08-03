// <copyright file="EmailSettings.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Attributes;
using System;
using System.Collections.Generic;

namespace Entities.Models.Settings.Email
{
  /// <summary>
  /// Settings for Email Server.
  /// </summary>
  public class EmailServer
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set Server ip.
    /// </summary>
    public string ServerIp { get; set; }

    /// <summary>
    /// Get or set Server port.
    /// </summary>
    public string ServerPort { get; set; }

    /// <summary>
    /// Get or set Server credential User.
    /// </summary>
    public string ServerUsername { get; set; }

    /// <summary>
    /// Get or set Server credential Password.
    /// </summary>
    public string ServerPassword { get; set; }

    /// <summary>
    /// Server description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Default Server.
    /// </summary>
    public bool Default { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    public DateTime ConcurrencyStamp { get; set; }

    /// <summary>
    /// A DateTime value that shows when record changed.
    /// </summary>
    public DateTime UpdatedOn { get; set; }
  }
}
