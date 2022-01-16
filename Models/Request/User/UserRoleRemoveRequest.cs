// <copyright file="UserRoleRemoveRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.User
{
  /// <summary>
  /// Delete user from role.
  /// </summary>
  public class UserRoleRemoveRequest
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
