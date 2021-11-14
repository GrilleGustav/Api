using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response
{
  public class GeneratedUrlTokenResponse : ErrorResponse
  {
    /// <summary>
    /// Token response.
    /// </summary>
    public GeneratedUrlTokenResponse()
    { }

    /// <summary>
    ///  Token response.
    /// </summary>
    /// <param name="url"></param>
    public GeneratedUrlTokenResponse(string url)
    {
      this.Url = url;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Token response with errors.
    /// </summary>
    /// <param name="errors">List of errors</param>
    public GeneratedUrlTokenResponse(List<Error> errors)
    {
      this.Errors = errors;
    }

    public GeneratedUrlTokenResponse(string url, List<Error> errors)
    {
      this.Url = url;
      this.Errors = errors;
    }

    /// <summary>
    /// Get or set Url with token.
    /// </summary>
    public string Url { get; set; }
  }
}
