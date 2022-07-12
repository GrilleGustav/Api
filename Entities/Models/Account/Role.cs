// <copyright file="UserRole.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using System;

namespace Entities.Models.Account
{
  /// <summary>
  /// User role.
  /// </summary>
  public class Role : IdentityRole<Guid>
  {
    /// <summary>
    /// Set up role.
    /// </summary>
    public Role()
    { }
    /// <summary>
    /// Set up role with name and description.
    /// </summary>
    /// <param name="name">Role name.</param>
    /// <param name="description">Role description.</param>
    public Role (string name, string description)
    {
      this.Name = name;
      this.Description = description;
    }
    /// <summary>
    /// Get or set role description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    public DateTime UpdatedOn { get; set; }
  }
}
