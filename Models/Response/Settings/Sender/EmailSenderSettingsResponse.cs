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
    /// Response to return emial senders.
    /// </summary>
    public EmailSenderSettingsResponse()
    { }

    /// <summary>
    /// Set initial with email senders.
    /// </summary>
    /// <param name="emailSenders">List of email senders.</param>
    public EmailSenderSettingsResponse(List<EmailSender> emailSenders)
    {
      this.EmailSenders = emailSenders;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set email senders.
    /// </summary>
    public List<EmailSender> EmailSenders { get; set; }
  }
}
