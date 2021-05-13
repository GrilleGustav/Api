// <copyright file="AuthenticationResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

namespace Models.Response
{
  /// <summary>
  /// User authentication response.
  /// </summary>
  public class AuthenticationResponse
  {
    /// <summary>
    /// Get or set authentication successful.
    /// </summary>
    public bool IsAuthSuccessful { get; set; }

    /// <summary>
    /// Get or set error message.
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Get or set user token.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Get or set 2 step varification is required.
    /// </summary>
    public bool Is2StepVerificationRequired { get; set; }

    /// <summary>
    /// Authentifica provider.
    /// </summary>
    public string Provider { get; set; }
  }
}
