// <copyright file="EmailMessageRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Entities.Models.Email;

namespace Repository
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public class EmailMessageRepository : RepositoryBase<EmailMessage>, IEmailMessageRepository
  {
    private RepositoryContext _repositoryContext;

    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public EmailMessageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
