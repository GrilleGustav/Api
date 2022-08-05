// <copyright file="VendorUpdateRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Request.Pv.Storage
{
  /// <summary>
  /// Vendor update request.
  /// </summary>
  public class VendorUpdateRequest
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
    /// Get or set vendor code.
    /// </summary>
    [Required]
    public string Code { get; set; }

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
