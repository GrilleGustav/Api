// <copyright file="ProductionAddressUpdateRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace PvSystemPlugin.Models.Request.Pv.Storage
{
  /// <summary>
  /// ProductionAddress update request.
  /// </summary>
  public class ProductionAddressUpdateRequest
  {
    /// <summary>
    /// Get or set Id
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Proction address name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set production address code.
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
