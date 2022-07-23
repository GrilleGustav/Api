// <copyright file="EmailSenderRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Entities.Models.Settings.Email;

namespace Repository
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public class EmailSenderRepository : RepositoryBase<EmailSender>, IEmailSenderRepository
  {
    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public EmailSenderRepository(RepositoryContext repositoryContext) :base(repositoryContext)
    { }
  }
}
