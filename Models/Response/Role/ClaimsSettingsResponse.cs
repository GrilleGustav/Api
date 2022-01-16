using Models.View.Settings.Role;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Models.Response.Group
{
  /// <summary>
  /// Class to return claims to frontend.
  /// </summary>
  public class ClaimsSettingsResponse: ErrorResponse
  {
    /// <summary>
    /// Initiate Claims response to frontend. 
    /// </summary>
    public ClaimsSettingsResponse()
    { }

    public ClaimsSettingsResponse(IList<ClaimViewModel> claims)
    {
      this.Claims = claims;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set list of claims.
    /// </summary>
    public IList<ClaimViewModel> Claims { get; set; }
  }
}
