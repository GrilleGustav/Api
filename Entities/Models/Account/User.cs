// <copyright file="User.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Attributes;
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
    /// Get or set phone number.
    /// </summary>
    [Placeholder("base")]
    [ProtectedPersonalData]
    public override string PhoneNumber { get; set; }

    /// <summary>
    /// Get or set username.
    /// </summary>
    [Placeholder("base")]
    [ProtectedPersonalData]
    public override string UserName { get; set; }

    /// <summary>
    /// Get or ser email.
    /// </summary>
    [Placeholder("base")]
    [ProtectedPersonalData]
    public override string Email { get; set; }

    /// <summary>
    /// Get or set Firstname.
    /// </summary>
    [Placeholder("base")]
    [ProtectedPersonalData]
    public string Firstname { get; set; }

    /// <summary>
    /// Get or set Lastname.
    /// </summary>
    [Placeholder("base")]
    [ProtectedPersonalData]
    public string Lastname { get; set; }

    /// <summary>
    /// Get or set Language.
    /// </summary>
    [Placeholder("base")]
    public Language Language { get; set; }

    /// <summary>
    /// Get or set time user was crated.
    /// </summary>
    [Placeholder("base")]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Get or set last user access.
    /// </summary>
    [Placeholder("base")]
    public DateTime LastAccessedOn { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    [Placeholder("base")]
    public DateTime UpdatedOn { get; set; }

    // Navigation Properties

    public virtual List<RefreshToken> RefreshTokens { get; set; }
  }
}
