// <copyright file="EmailConfirmLinkRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
  /// <summary>
  /// Request model for send new email confirm link.
  /// </summary>
  public class EmailConfirmLinkRequest
  {
    /// <summary>
    /// Get or set clientURI.
    /// </summary>
    [Required]
    public string ClientURI { get; set; }

    /// <summary>
    /// Get or set email.
    /// </summary>
    [Required]
    public string Email { get; set; }
  }
}
