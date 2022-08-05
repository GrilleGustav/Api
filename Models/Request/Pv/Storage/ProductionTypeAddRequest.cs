// <copyright file=">ProductionTypeAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new production type.
  /// </summary>
  public class ProductionTypeAddRequest
  {
    /// <summary>
    /// Get or set name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set production type code.
    /// </summary>
    [Required]
    public char Code { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }
  }
}
