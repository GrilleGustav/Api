// <copyright file="EmailServerSettingResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.View.Settings.Email;

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
    public EmailServerSettingResponse(EmailServerViewModel emailServer)
    {
      this.EmailServer = emailServer;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set email server.
    /// </summary>
    public EmailServerViewModel EmailServer { get; set; }
  }
}
