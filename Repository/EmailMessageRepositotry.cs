// <copyright file="EmailMessageRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Entities.Models.Email;

namespace Repository
{
  public class EmailMessageRepository : RepositoryBase<EmailMessage>, IEmailMessageRepository
  {
    private RepositoryContext _repositoryContext;
    public EmailMessageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
