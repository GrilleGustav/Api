// <copyright file="RegistrationResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Models.Response
{
  public class RegistrationResponse
  {
    /// <summary>
    /// Get or set registration successful.
    /// </summary>
    public bool IsSuccessfulRegistration { get; set; }

    /// <summary>
    /// Get or set one or more errors.
    /// </summary>
    public IEnumerable<string> Errors { get; set; }
  }
}
