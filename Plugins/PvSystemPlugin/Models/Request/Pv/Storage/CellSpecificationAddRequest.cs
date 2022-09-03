// <copyright file="CellSpecificationAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


using System.ComponentModel.DataAnnotations;

namespace PvSystemPlugin.Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new cell specification.
  /// </summary>
  public class CellSpecificationAddRequest
  {
    /// <summary>
    /// Get or set name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set code.
    /// </summary>
    [Required]
    public string Code { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }
  }
}
