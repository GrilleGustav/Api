// <copyright file="EmailServerRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Entities.Models.Settings.Email;

namespace Repository
{
  public class EmailServerRepository : RepositoryBase<EmailServer>, IEmailServerRepository
  {
    private RepositoryContext _repositoryContext;
    public EmailServerRepository(RepositoryContext repositoryContext) :base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
