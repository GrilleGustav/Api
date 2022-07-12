using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response.Placeholder
{
  /// <summary>
  /// Placeholder response.
  /// </summary>
  public class PlaceholderResponse : ErrorResponse
  {
    /// <summary>
    /// Placeholder response.
    /// </summary>
    public PlaceholderResponse()
    { }

    /// <summary>
    /// Placeholder response.
    /// </summary>
    /// <param name="placeholder">List of palceholder.</param>
    public PlaceholderResponse(List<string> placeholder)
    {
      this.Placeholder = placeholder;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set list of placeholders.
    /// </summary>
    public List<string> Placeholder { get; set; }
  }
}
