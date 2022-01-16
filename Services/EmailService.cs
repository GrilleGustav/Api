// <copyright file="EmailService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Models.Account;
using Entities.Models.Email;
using Entities.Models.Settings.Email;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.WebUtilities;
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
    private readonly IRepositoryManager _repository;

    public EmailService(ILogger<EmailService> logger, IRepositoryManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    public async Task<int> SendMail(EmailMessage message)
    {
      return await this.Send(this.CreateMail(message), message);
    }

    public async Task<EmailMessage> GenerateRegisterConfirmMessage(User user, string clientURI, string token)
    {
      EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.EmailTemplateType == Enums.EmailTemplateType.Register && x.Default == true && x.LanguageCode == user.Language, false).SingleOrDefaultAsync();
      var param = new Dictionary<string, string>
      {
        {"token", token },
        {"email", user.Email }
      };
      var callback = QueryHelpers.AddQueryString(clientURI, param);
      string content = emailTemplate.Content;
      content = content.Replace("{Date}", DateTime.Now.ToString());
      content = content.Replace("{RegisterConfirm}", callback);
      content = content.Replace("{Firstname}", user.Firstname);
      content = content.Replace("{Lastname}", user.Lastname);
      content = content.Replace("{UserName}", user.UserName);

      EmailMessage emailMessage = new EmailMessage(new string[] { user.Email }, "developper@grillegustav.de", "Confirm Registration", content);
      return emailMessage;
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

    private async Task<int> Send(MimeMessage message, EmailMessage emailMessage)
    {
      EmailServer emailServer = await _repository.EmailServer.FindByCondition(x => x.Default == true, false).SingleOrDefaultAsync();
      using (SmtpClient client = new SmtpClient())
      {
        try
        {
          client.ServerCertificateValidationCallback = (s, c, h, e) => true;
          client.Connect(emailServer.ServerIp, int.Parse(emailServer.ServerPort), MailKit.Security.SecureSocketOptions.None);
          client.AuthenticationMechanisms.Remove("XOAUTH2");
          await client.AuthenticateAsync(emailServer.ServerUsername, emailServer.ServerPassword);
          client.Send(message);
          emailMessage.IsSend = true;
        }
        catch (Exception e)
        {
          _logger.LogError(e.Message);
          emailMessage.IsSend = false;
          return 1;
        }
        finally
        {
          _logger.LogInformation(string.Format("Email succesfully send to {0}", message.To));
          await client.DisconnectAsync(true);
          client.Dispose();
          _repository.EmailMessage.Create(emailMessage);
          await _repository.SaveAsync();
        }

        return 0;
      }
    }
  }
}
