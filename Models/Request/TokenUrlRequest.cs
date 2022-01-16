// <copyright file="TokenRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
  /// <summary>
  /// Token request.
  /// </summary>
  public class TokenUrlRequest
  {
    /// <summary>
    /// Get or set user id.
    /// </summary>
    [Required]
    public string Id { get; set; }

    /// <summary>
    /// Get or set clientUrl.
    /// </summary>
    [Required]
    public string ClientUrl { get; set; }
  }
}
