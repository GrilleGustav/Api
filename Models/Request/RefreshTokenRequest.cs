using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
  /// <summary>
  /// Refresh token request.
  /// </summary>
  public class RefreshTokenRequest
  {
    /// <summary>
    /// Get or set refresh token.
    /// </summary>
    public string RefreshToken { get; set; }
  }
}
