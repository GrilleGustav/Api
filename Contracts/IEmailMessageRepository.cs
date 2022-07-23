// <copyright file="IEmailMessageRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Email;

namespace Contracts
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public interface IEmailMessageRepository : IRepositoryBase<EmailMessage>
  {
  }
}
