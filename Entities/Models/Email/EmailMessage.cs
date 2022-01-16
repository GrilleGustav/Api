// <copyright file="EmailMessage.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Models.Email
{
  public class EmailMessage
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Get or set date emial was send.
    /// </summary>
    public DateTime SendOn { get; set; }

    /// <summary>
    /// Get or set list of receiver.
    /// </summary>
    public List<MailboxAddress> To { get; set; }

    /// <summary>
    /// Get or set list of receiver separated by semicolon.
    /// </summary>
    public string Receiver { get; set; }

    /// <summary>
    /// Get or set sender.
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Get or set subject.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Get or set content.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Get or set if email already send.
    /// </summary>
    public bool IsSend { get; set; }

    public EmailMessage()
    { }

    public EmailMessage(IEnumerable<string> to, string from, string subject, string content)
    {
      To = new List<MailboxAddress>();
      To.AddRange(to.Select(x => new MailboxAddress(x.Split('@')[0], x)));
      foreach (string receiver in to)
        Receiver = Receiver + receiver + ";";
      From = from;
      Subject = subject;
      Content = content;
    }
  }
}
