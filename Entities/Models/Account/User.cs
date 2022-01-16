// <copyright file="User.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Entities.Models.Account
{
  /// <summary>
  /// Application user.
  /// </summary>
  public class User : IdentityUser<Guid>
  {
    /// <summary>
    /// Get or set Firstname.
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// Get or set Lastname.
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Get or set Language.
    /// </summary>
    public Language Language { get; set; }

    /// <summary>
    /// Get or set time user was crated.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Get or set last user access.
    /// </summary>
    public DateTime LastAccessedOn { get; set; }

    // Navigation Properties

    public virtual List<RefreshToken> RefreshTokens { get; set; }
  }
}
