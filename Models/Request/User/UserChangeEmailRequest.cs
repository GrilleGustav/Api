using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Request.User
{
  public class UserChangeEmailRequest
  {
    /// <summary>
    /// Get or set user email.
    /// </summary>
    [Required]
    public string UserEmail { get; set; }

    /// <summary>
    /// Get or set new email.
    /// </summary>
    [Required]
    public string NewEmail { get; set; }

    /// <summary>
    /// Get or set email change token.
    /// </summary>
    [Required]
    public string Token { get; set; }
  }
}
