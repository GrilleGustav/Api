// <copyright file="RegisterRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
  /// <summary>
  /// User registration request.
  /// </summary>
  public class RegistrationRequest
  {
    /// <summary>
    /// Get or set firstname.
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// Get or set lastname.
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Get or set language.
    /// </summary>
    [Required(ErrorMessage = "Email is required.")]
    [JsonProperty(PropertyName = "language1")]
    public Language Language { get; set; }

    /// <summary>
    /// Get or set email.
    /// </summary>
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    /// <summary>
    /// Get or set password.
    /// </summary>
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }

    /// <summary>
    /// Get or set confirmation password.
    /// </summary>
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    /// <summary>
    /// Get or set clientURI.
    /// </summary>
    public string ClientURI { get; set; }
  }
}
