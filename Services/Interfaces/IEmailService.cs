// <copyright file="IEmailService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Account;
using Entities.Models.Email;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  /// <summary>
  /// Service for gernerating and sending email content.
  /// </summary>
  public interface IEmailService
  {
    /// <summary>
    /// Creating and sending email.
    /// </summary>
    /// <param name="message">Email message.</param>
    /// <returns>The Task that represents asynchronous operation, containing information abaut sending status.</returns>
    Task<int> SendMail(EmailMessage message);

    /// <summary>
    /// Generate register confirm message.
    /// </summary>
    /// <param name="user">User obejct.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="token">Register confirm token.</param>
    /// <returns>Email message.</returns>
    Task<EmailMessage> GenerateRegisterConfirmMessage(User user, string clientURI, string token);

    /// <summary>
    /// Generate password reset message.
    /// </summary>
    /// <param name="user">User obejct.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="token">Password reset token.</param>
    /// <returns>Email message.</returns>
    Task<EmailMessage> GeneratePasswordResetMessage(User user, string clientURI, string token);

    /// <summary>
    /// Generate email chnage message,.
    /// </summary>
    /// <param name="user">User object.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="token">Change email token.</param>
    /// <returns></returns>
    Task<EmailMessage> GenerateChangeEmailMessage(User user, string clientURI, string token);

    /// <summary>
    /// Generate Two factor email message.
    /// </summary>
    /// <param name="user">User object.</param>
    /// <param name="clientURI">Client url to view.</param>
    /// <param name="code">Two factor code.</param>
    /// <returns></returns>
    Task<EmailMessage> GenerateTwoFactorEmailMessage(User user, string code);
  }
}
