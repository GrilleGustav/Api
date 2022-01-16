using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response.Group
{
  /// <summary>
  /// Response object to return one role.
  /// </summary>
  public class RoleSettingsResponse: ErrorResponse
  {
    /// <summary>
    /// New instance.
    /// </summary>
    public RoleSettingsResponse()
    { }

    /// <summary>
    /// Initiate with role object.
    /// </summary>
    /// <param name="role">role object.</param>
    public RoleSettingsResponse(Entities.Models.Account.Role role)
    {
      this.Role = role;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set role.
    /// </summary>
    public Entities.Models.Account.Role Role { get; set; }
  }
}
