// <copyright file="EmailService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Models.Email;
using Entities.Models.Settings.Email;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class EmailService : IEmailService
  {
    private readonly ILogger<EmailService> _logger;
    private readonly IRepositoryManager _repositiry;

    public EmailService(ILogger<EmailService> logger, IRepositoryManager repository)
    {
      _logger = logger;
      _repositiry = repository;
    }

    public async Task<int> SendMail(EmailMessage message)
    {
      return await this.Send(this.CreateMail(message));
    }

    private MimeMessage CreateMail(EmailMessage message)
    {
      MimeMessage emailMessage = new MimeMessage();
      emailMessage.From.Add(new MailboxAddress(message.From.Split('@')[0], message.From)); //need to edit
      emailMessage.To.AddRange(message.To);
      emailMessage.Subject = message.Subject;
      emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

      return emailMessage;
    }

    private async Task<int> Send(MimeMessage message)
    {
      EmailServer emailServer = await _repositiry.EmailServer.FindByCondition(x => x.Default == true, false).SingleOrDefaultAsync();
      using (SmtpClient client = new SmtpClient())
      {
        try
        {
          client.ServerCertificateValidationCallback = (s, c, h, e) => true;
          client.Connect(emailServer.ServerIp, int.Parse(emailServer.ServerPort), MailKit.Security.SecureSocketOptions.None);
          client.AuthenticationMechanisms.Remove("XOAUTH2");
          await client.AuthenticateAsync(emailServer.ServerUsername, emailServer.ServerPassword);
          client.Send(message);
        }
        catch (Exception e)
        {
          _logger.LogError(e.Message);
          return 1;
        }
        finally
        {
          _logger.LogInformation(string.Format("Email succesfully send to {0}", message.To));
          await client.DisconnectAsync(true);
          client.Dispose();
        }

        return 0;
      }
    }
  }
}
