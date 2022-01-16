// <copyright file="UserRolesUpdateRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Request.User
{
  /// <summary>
  /// Update user roles.
  /// </summary>
  public class UserRolesUpdateRequest
  {
    /// <summary>
    /// Get or set user roles.
    /// </summary>
    [Required]
    public List<Entities.Models.Account.Role> Roles { get; set; } 

    /// <summary>
    /// Get or set user id.
    /// </summary>
    [Required]
    public string UserId { get; set; }
  }
}
