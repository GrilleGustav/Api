using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
  public class RefreshTokenObject
  {
    public RefreshTokenObject(string refreshToken, string newToken)
    {
      RefreshToken = refreshToken;
      NewToken = newToken;
    }

    /// <summary>
    /// Get or set old token.
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// Get or set new token.
    /// </summary>
    public string NewToken { get; set; }
  }
}
