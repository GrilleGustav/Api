// <copyright file="ResetPasswordRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
  /// <summary>
  /// Password reset request object.
  /// </summary>
  public class ResetPasswordRequest
  {
    /// <summary>
    /// Get or set password.
    /// </summary>
    [Required]
    public string Password { get; set; }

    /// <summary>
    /// Get or set confirmation password.
    /// </summary>
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    /// <summary>
    /// Get or set user email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Get or set user token.
    /// </summary>
    public string Token { get; set; }
  }
}
