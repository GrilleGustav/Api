using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Settings.Role
{
  public class ClaimViewModel
  {
    /// <summary>
    /// Get or set Issuer.
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// Get or set Original Issuer.
    /// </summary>
    public string OriginalIssuer { get; set; }

    /// <summary>
    /// Get or set Type.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Get or set Value.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Get or set Value type.
    /// </summary>
    public string ValueType { get; set; }
  }
}
