// <copyright file="RoleAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.Role
{
  /// <summary>
  /// Request for adding new role.
  /// </summary>
  public class RoleAddRequest
  {
    /// <summary>
    /// Get or set role name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Discription { get; set; }
  }
}
