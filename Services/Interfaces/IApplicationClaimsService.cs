using Models;
using Models.Response.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
  /// <summary>
  /// Application claims service.
  /// </summary>
  public interface IApplicationClaimsService
  {
    /// <summary>
    /// Add application claim.
    /// </summary>
    /// <param name="applicationClaim">Application claim.</param>
    void AddClaim(ApplicationClaim applicationClaim);

    /// <summary>
    /// Add application claim.
    /// </summary>
    /// <param name="claimValue">Claim value.</param>
    /// <param name="displayGroup">Display group.</param>
    void AddClaim(string claimValue, string displayGroup);

    /// <summary>
    /// Get application claims.
    /// </summary>
    /// <returns>Application claims.</returns>
    List<ApplicationClaim> GetClaims();

    /// <summary>
    /// Get application claims grouped by display group.
    /// </summary>
    /// <returns>Application claims grouped by display group.</returns>
    Result<Dictionary<string, IGrouping<string, ApplicationClaim>>> GetClaimsGroupedBy();
  }
}
