// <copyright file="EmailSenderRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;

namespace Contracts
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public interface IEmailSenderRepository : IRepositoryPvBase<EmailSender>
  {
  }
}
