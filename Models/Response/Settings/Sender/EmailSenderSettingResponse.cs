// <copyright file="EmailSenderSettingService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;

namespace Models.Response.Settings.Sender
{
  public class EmailSenderSettingResponse : ErrorResponse
  {
    /// <summary>
    /// Set initial with email sender.
    /// </summary>
    /// <param name="emailSenders">List of email senders.</param>
    public EmailSenderSettingResponse(EmailSender emailSender)
    {
      this.EmailSender = emailSender;
    }

    /// <summary>
    /// Set initial with error code.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    public EmailSenderSettingResponse(string errorCode)
    {
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Set initial with error code and message.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    /// <param name="errorMessage">Error message.</param>
    public EmailSenderSettingResponse(string errorCode, string errorMessage)
    {
      this.ErrorCode = errorCode;
      this.ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Get or set email sender.
    /// </summary>
    public EmailSender EmailSender { get; set; }
  }
}
