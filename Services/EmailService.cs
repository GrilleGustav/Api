﻿// <copyright file="EmailService.cs" company="GrilleGustav">
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
using System.Threading.Tasks;

namespace Services
{
  /// <summary>
  /// Service for gernerating and sending email content.
  /// </summary>
  public class EmailService : IEmailService
  {
    private readonly ILogger<EmailService> _logger;
    private readonly IRepositoryManager _repository;
    private readonly IPlaceholderService _placeholderService;

    /// <summary>
    /// Service for gernerating and sending email content.
    /// </summary>
    /// <param name="logger">Logger service to log messages in console and log files.</param>
    /// <param name="repository">Access to backend store.</param>
    /// <param name="placeholderService"></param>
    public EmailService(ILogger<EmailService> logger, IRepositoryManager repository, IPlaceholderService placeholderService)
    {
      _logger = logger;
      _repository = repository;
      _placeholderService = placeholderService;
    }

    /// <summary>
    /// Creating and sending email.
    /// </summary>
    /// <param name="message">Email message.</param>
    /// <returns>The Task that represents asynchronous operation, containing information abaut sending status.</returns>
    public async Task<int> SendMail(EmailMessage message)
    {
      return await this.Send(this.CreateMail(message), message);
    }

    /// <summary>
    /// Generate register confirm message.
    /// </summary>
    /// <param name="user">User obejct.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="token">Register confirm token.</param>
    /// <returns>Email message.</returns>
    public async Task<EmailMessage> GenerateRegisterConfirmMessage(User user, string clientURI, string token)
    {
      EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.TemplateType.Name == "register" && x.Default == true && x.Language == user.Language, false).Include(y => y.EmailSender).SingleOrDefaultAsync();
      List<object> data = new List<object>();
      data.Add(user);
      string content = _placeholderService.ReplacePlaceholders(data, emailTemplate.Content);
      var param = new Dictionary<string, string>
      {
        { "token", token },
        { "email", user.Email }
      };

      var callback = QueryHelpers.AddQueryString(clientURI, param);
      content = content.Replace("{Date}", DateTime.Now.ToString());
      content = content.Replace("{RegisterConfirm}", callback);

      EmailMessage emailMessage = new EmailMessage(new string[] { user.Email }, emailTemplate.EmailSender.Sender, "Confirm registration", content);
      return emailMessage;
    }

    /// <summary>
    /// Generate password reset message.
    /// </summary>
    /// <param name="user">User obejct.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="token">Password reset token.</param>
    /// <returns>Email message.</returns>
    public async Task<EmailMessage> GeneratePasswordResetMessage(User user, string clientURI, string token)
    {
      EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.TemplateType.Name == "PasswordReset" && x.Default == true && x.Language == user.Language, false).Include(y => y.EmailSender).SingleOrDefaultAsync();
      List<object> data = new List<object>();
      data.Add(user);
      string content = _placeholderService.ReplacePlaceholders(data, emailTemplate.Content);
      var param = new Dictionary<string, string>
      {
        { "token", token },
        { "email", user.Email }
      };

      var callback = QueryHelpers.AddQueryString(clientURI, param);
      content = content.Replace("{Date}", DateTime.Now.ToString());
      content = content.Replace("{PasswordReset}", callback);

      EmailMessage emailMessage = new EmailMessage(new string[] { user.Email }, emailTemplate.EmailSender.Sender, "Reset password", content);
      return emailMessage;
    }

    /// <summary>
    /// Generate email change message.
    /// </summary>
    /// <param name="user">User object.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="token">Change email token.</param>
    /// <returns></returns>
    public async Task<EmailMessage> GenerateChangeEmailMessage(User user, string clientURI, string token)
    {
      EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.TemplateType.Name == "ChangeEmail" && x.Default == true && x.Language == user.Language, false).Include(y => y.EmailSender).SingleOrDefaultAsync();
      List<object> data = new List<object>();
      data.Add(user);
      string content = _placeholderService.ReplacePlaceholders(data, emailTemplate.Content);
      var param = new Dictionary<string, string>
      {
        { "token", token },
        { "email", user.Email }
      };

      var callback = QueryHelpers.AddQueryString(clientURI, param);
      content = content.Replace("{Date}", DateTime.Now.ToString());
      content = content.Replace("{ChangeEmialLink}", callback);

      EmailMessage emailMessage = new EmailMessage(new string[] { user.Email }, emailTemplate.EmailSender.Sender, "Change email", content);
      return emailMessage;
    }

    /// <summary>
    /// Generate Two factor email message.
    /// </summary>
    /// <param name="user">User object.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="code">Two factor code.</param>
    /// <returns></returns>
    public async Task<EmailMessage> GenerateTwoFactorEmailMessage(User user, string code)
    {
      EmailTemplate emailTemplate = await _repository.EmailTemplate.FindByCondition(x => x.TemplateType.Name == "TwoStep" && x.Default == true && x.Language == user.Language, false).Include(y => y.EmailSender).SingleOrDefaultAsync();
      List<object> data = new List<object>();
      data.Add(user);
      string content = _placeholderService.ReplacePlaceholders(data, emailTemplate.Content);

      content = content.Replace("{Date}", DateTime.Now.ToString());
      content = content.Replace("{TowStepCode}", code);

      EmailMessage emailMessage = new EmailMessage(new string[] { user.Email }, emailTemplate.EmailSender.Sender, "TwoFactor", content);
      return emailMessage;
    }

    /// <summary>
    /// Create mail.
    /// </summary>
    /// <param name="message">Email message.</param>
    /// <returns>>Mime message.</returns>
  private MimeMessage CreateMail(EmailMessage message)
    {
      MimeMessage emailMessage = new MimeMessage();
      emailMessage.From.Add(new MailboxAddress(message.From.Split('@')[0], message.From)); //need to edit
      emailMessage.To.AddRange(message.To);
      emailMessage.Subject = message.Subject;
      emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

      return emailMessage;
    }

    /// <summary>
    /// Sending email.
    /// </summary>
    /// <param name="message">Mime message.</param>
    /// <param name="emailMessage">Email message.</param>
    /// <returns>The Task that represents asynchronous operation, containing information abaut sending status.</returns>
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
