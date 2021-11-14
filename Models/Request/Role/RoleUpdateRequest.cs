using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;

namespace Models.Request.Role
{
  /// <summary>
  /// Update role request.
  /// </summary>
  public class RoleUpdateRequest
  {
    /// <summary>
    /// Get or set role.
    /// </summary>
    [Required]
    public Entities.Models.Account.Role Role { get; set; }

    /// <summary>
    /// Get or set list of claims.
    /// </summary>
    public IList<Claim> Claims { get; set; }
  }
}
