// <copyright file="ExternalAuthRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

namespace Models.Request
{
  /// <summary>
  /// External authentication object.
  /// </summary>
  public class ExternalAuthRequest
  {
    /// <summary>
    /// Get or set provider.
    /// </summary>
    public string Provider { get; set; }

    /// <summary>
    /// Get or set idToken.
    /// </summary>
    public string IdToken { get; set; }
  }
}
