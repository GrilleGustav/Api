// <copyright file="AzthenticationRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
  /// <summary>
  /// Used for user authentication.
  /// </summary>
  public class AuthenticationRequest
  {
    /// <summary>
    /// Get or set user email.
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Get or set user password.
    /// </summary>
    [Required]
    public string Password { get; set; }

    /// <summary>
    /// Get or set stay logged in.
    /// </summary>
    public bool StayLoggedIn { get; set; } = false;

    /// <summary>
    /// Get or set client url.
    /// </summary>
    public string clientURI { get; set; }
  }
}
