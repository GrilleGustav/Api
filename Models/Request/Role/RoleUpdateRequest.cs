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
    /// Get or set Id.
    /// </summary>
    [Required]
    public string Id { get; set; }

    /// <summary>
    /// Get or set name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set role description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Get pr set concurrencyStamp.
    /// </summary>
    [Required]
    public string ConcurrencyStamp { get; set; }

    /// <summary>
    /// Get or set list of claims.
    /// </summary>
    public IList<string> Claims { get; set; }
  }
}
