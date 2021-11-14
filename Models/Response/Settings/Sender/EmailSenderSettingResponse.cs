// <copyright file="EmailSenderSettingService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;

namespace Models.Response.Settings.Sender
{
  public class EmailSenderSettingResponse : ErrorResponse
  {
    /// <summary>
    /// Email sender settings reponse.
    /// </summary>
    public EmailSenderSettingResponse()
    { }

    /// <summary>
    /// Set initial with email sender.
    /// </summary>
    /// <param name="emailSenders">List of email senders.</param>
    public EmailSenderSettingResponse(EmailSender emailSender)
    {
      this.EmailSender = emailSender;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set email sender.
    /// </summary>
    public EmailSender EmailSender { get; set; }
  }
}
