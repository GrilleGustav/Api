using System.Collections.Generic;

namespace Models.Response.Group
{
  public class RolesSettingsResponse: ErrorResponse
  {
    /// <summary>
    /// New instance.
    /// </summary>
    public RolesSettingsResponse()
    { }

    /// <summary>
    /// Initiate with list of roles.
    /// </summary>
    /// <param name="roles">List of roles.</param>
    public RolesSettingsResponse(List<Entities.Models.Account.Role> roles)
    {
      this.Roles = roles;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set list of roles.
    /// </summary>
    public List<Entities.Models.Account.Role> Roles { get; set; }
  }
}
