﻿// <copyright file="IEmailService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Account;
using Entities.Models.Email;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailService
  {
    Task<int> SendMail(EmailMessage message);

    Task<EmailMessage> GenerateRegisterConfirmMessage(User user, string clientURI, string token);

    Task<EmailMessage> GeneratePasswordResetMessage(User user, string clientURI, string token);
  }
}
