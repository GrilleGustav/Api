// <copyright file="EmailTemplateRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Entities.Models.Settings.Email;

namespace Repository
{
  public class EmailTemplateRepository : RepositoryBase<EmailTemplate>, IEmailTemplateRepository
  {
    private RepositoryContext _repositoryContext;
    public EmailTemplateRepository(RepositoryContext repositoryContext) :base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
