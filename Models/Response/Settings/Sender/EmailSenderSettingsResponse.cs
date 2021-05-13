// <copyright file="EmailSenderSettingsResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using System.Collections.Generic;

namespace Models.Response.Settings.Sender
{
  /// <summary>
  /// Response to return email senders.
  /// </summary>
  public class EmailSenderSettingsResponse : ErrorResponse
  {
    /// <summary>
    /// Set initial with email senders.
    /// </summary>
    /// <param name="emailSenders">List of email senders.</param>
    public EmailSenderSettingsResponse(List<EmailSender> emailSenders)
    {
      this.EmailSenders = emailSenders;
    }

    /// <summary>
    /// Set initial with error code.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    public EmailSenderSettingsResponse(string errorCode)
    {
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Set initial with error code and message.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    /// <param name="errorMessage">Error message.</param>
    public EmailSenderSettingsResponse(string errorCode, string errorMessage)
    {
      this.ErrorCode = errorCode;
      this.ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Get or set email senders.
    /// </summary>
    public List<EmailSender> EmailSenders { get; set; }
  }
}
