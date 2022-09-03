// <copyright file=">ProductionAddressAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace PvSystemPlugin.Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new production address.
  /// </summary>
  public class ProductionAddressAddRequest
  {
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
  }
}
