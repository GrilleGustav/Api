using Entities.Models.Settings.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response.Settings.Email
{
  public class EmailServerSettingResponse : ErrorResponse
  {
    /// <summary>
    /// Email server response.
    /// </summary>
    public EmailServerSettingResponse()
    { }

    /// <summary>
    /// Email server response.
    /// </summary>
    /// <param name="emailServer">Email server.</param>
    public EmailServerSettingResponse(EmailServer emailServer)
    {
      this.EmailServer = emailServer;
    }

    /// <summary>
    /// Email server response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    public EmailServerSettingResponse(string errorCode)
    {
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Email server response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    /// <param name="ErrorMessage">Error message.</param>
    public EmailServerSettingResponse(string errorCode, string errorMessage)
    {
      this.ErrorCode = errorCode;
      this.ErrorMessage = ErrorMessage;
    }

    /// <summary>
    /// Get or set email server.
    /// </summary>
    public EmailServer EmailServer { get; set; }
  }
}
