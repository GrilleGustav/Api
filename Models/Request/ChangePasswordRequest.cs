using Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Request
{
  /// <summary>
  /// Change passowrd request.
  /// </summary>
  public class ChangePasswordRequest
  {
    /// <summary>
    /// Get or set password.
    /// </summary>
    [Required]
    public string Password { get; set; }

    [Required]
    [NotEqual("Password")]
    public string NewPassword { get; set; }

    /// <summary>
    /// Get or set confirmation password.
    /// </summary>
    [Compare("NewPassword")]
    public string NewPasswordConfirm { get; set; }

    /// <summary>
    /// Get or set user email.
    /// </summary>
    [Required]
    public string Email { get; set; }
  }
}
