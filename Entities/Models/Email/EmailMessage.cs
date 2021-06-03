// <copyright file="EmailMessage.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Models.Email
{
  public class EmailMessage
  {
    public List<MailboxAddress> To { get; set; }

    public string From { get; set; }

    public string Subject { get; set; }

    public string Content { get; set; }

    public EmailMessage(IEnumerable<string> to, string from, string subject, string content)
    {
      To = new List<MailboxAddress>();
      To.AddRange(to.Select(x => new MailboxAddress(x.Split('@')[0], x)));
      From = from;
      Subject = subject;
      Content = content;
    }
  }
}
