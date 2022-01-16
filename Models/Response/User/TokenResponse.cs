using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response.User
{
  /// <summary>
  /// Token response.
  /// </summary>
  public class TokenResponse : ErrorResponse
  {
    /// <summary>
    /// Token response.
    /// </summary>
    public TokenResponse()
    { }

    /// <summary>
    /// Token response
    /// </summary>
    /// <param name="token">Access token.</param>
    /// <param name="refreshToken">Refresh token.</param>
    public TokenResponse(string token, string refreshToken)
    {
      this.Token = token;
      this.RefreshToken = refreshToken;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set Access token.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Get or set Refresh token.
    /// </summary>
    public string RefreshToken { get; set; }
  }
}
