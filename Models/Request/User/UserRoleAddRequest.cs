// <copyright file="UserRoleAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.User
{
  /// <summary>
  /// Add user to role.
  /// </summary>
  public class UserRoleAddRequest
  {
    /// <summary>
    /// Get or set role name.
    /// </summary>
    [Required]
    public string RoleName { get; set; }

    /// <summary>
    /// Get or set user id.
    /// </summary>
    [Required]
    public string UserId { get; set; }
  }
}
