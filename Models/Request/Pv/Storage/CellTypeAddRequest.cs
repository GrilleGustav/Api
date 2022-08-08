// <copyright file="CellTypeAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new cell type.
  /// </summary>
  public class CellTypeAddRequest
  {
    /// <summary>
    /// Get or set celltype name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set code.
    /// </summary>
    [Required]
    public char Code { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }
  }
}
