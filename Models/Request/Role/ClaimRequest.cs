// <copyright file="ClaimRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.Role
{
  /// <summary>
  /// Add claim to role request.
  /// </summary>
  public class ClaimRequest
  {
    /// <summary>
    /// Get or set Role id.
    /// </summary>
    [Required]
    public string RoleId { get; set; }

    /// <summary>
    /// Get or set claim value.
    /// </summary>
    [Required]
    public string ClaimValue { get; set; }
  }
}
