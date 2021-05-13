// <copyright file="ForgotPasswordRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
  /// <summary>
  /// Forget password request object.
  /// </summary>
  public class ForgotPasswordRequest
  {
    /// <summary>
    /// Get or set user email.
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Get or set clientUri.
    /// </summary>
    [Required]
    public string ClientURI { get; set; }
  }
}
