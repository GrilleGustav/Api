// <copyright file="EmailExistRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
  /// <summary>
  /// Email exist request.
  /// </summary>
  public class EmailExistRequest
  {
    /// <summary>
    /// Get or set email.
    /// </summary>
    [Required, EmailAddress]
    public string Email { get; set; }
  }
}
