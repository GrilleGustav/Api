using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Request.User
{
  /// <summary>
  /// Change email token request.
  /// </summary>
  public class UserEmailChangeTokenRequest
  {
    /// <summary>
    /// Get or set user id.
    /// </summary>
    [Required]
    public string Id { get; set; }

    /// <summary>
    /// Get or set new email.
    /// </summary>
    [Required]
    public string NewEmail { get; set; }

    /// <summary>
    /// Get or set clientUrl.
    /// </summary>
    [Required]
    public string ClientUrl { get; set; }
  }
}
