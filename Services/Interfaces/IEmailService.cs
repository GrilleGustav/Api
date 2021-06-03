// <copyright file="IEmailService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Email;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailService
  {
    Task<int> SendMail(EmailMessage message);
  }
}
