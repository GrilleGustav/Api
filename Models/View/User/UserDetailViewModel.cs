// <copyright file="UserDetailViewModel.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.View.User
{
  /// <summary>
  /// User detail view model.
  /// </summary>
  public class UserDetailViewModel
  {
    /// <summary>
    /// Get or set Id.
    /// </summary>
    [Required]
    public string Id { get; set; }

    /// <summary>
    /// Get or set Firstname.
    /// </summary>
    [Required]
    public string Firstname { get; set; }

    /// <summary>
    /// Get or set Lastname.
    /// </summary>
    [Required]
    public string Lastname { get; set; }

    /// <summary>
    /// Get or set Language.
    /// </summary>
    [Required]
    public Language Language { get; set; }

    /// <summary>
    /// Gets or sets the date and time, in UTC, when any user lockout ends.
    /// 
    /// Hint: 
    ///   A value in the past means the user is not locked out.
    /// </summary>
    public DateTimeOffset LockoutEnd { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating if two factor authentication is enabled for this user.
    /// 
    /// Value:
    ///   True if 2fa is enabled, otherwise false.
    /// </summary>
    [Required]
    public virtual bool TwoFactorEnabled { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating if a user has confirmed their telephone address.
    /// 
    /// Value:True if the telephone number has been confirmed, otherwise false.
    /// </summary>
    [Required]
    public virtual bool PhoneNumberConfirmed { get; set; }

    /// <summary>
    /// Gets or sets a telephone number for the user.
    /// </summary>
    public virtual string PhoneNumber { get; set; }

    /// <summary>
    /// A random value that must change whenever a user is persisted to the store.
    /// </summary>
    [Required]
    public virtual string ConcurrencyStamp { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating if a user has confirmed their email address.
    /// 
    /// Value:
    ///   True if the email address has been confirmed, otherwise false.
    /// </summary>
    [Required]
    public virtual bool EmailConfirmed { get; set; }

    /// <summary>
    /// Gets or sets the email address for this user.
    /// </summary>
    [Required, EmailAddress]
    public virtual string Email { get; set; }

    /// <summary>
    /// Gets or sets the user name for this user.
    /// </summary>
    [Required]
    public virtual string UserName { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating if the user could be locked out.
    /// 
    /// Value:
    ///   True if the user could be locked out, otherwise false.
    /// </summary>
    public virtual bool LockoutEnabled { get; set; }
  }
}
