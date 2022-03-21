// <copyright file="EmailServerRepository.cs" company="GrilleGustav">
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
  public class EmailServerRepository : RepositoryBase<EmailServer>, IEmailServerRepository
  {
    private RepositoryContext _repositoryContext;
    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public EmailServerRepository(RepositoryContext repositoryContext) :base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
