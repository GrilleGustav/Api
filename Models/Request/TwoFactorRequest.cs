// <copyright file="TwoFactorRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Request
{
  public class TwoFactorRequest
  {
    /// <summary>
    /// User email.
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Login provider.
    /// </summary>
    [Required]
    public string Provider { get; set; }

    /// <summary>
    /// User token.
    /// </summary>
    [Required]
    public string Token { get; set; }
  }
}
