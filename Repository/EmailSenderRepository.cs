// <copyright file="EmailSenderRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Entities.Models.Settings.Email;

namespace Repository
{
  public class EmailSenderRepository : RepositoryBase<EmailSender>, IEmailSenderRepository
  {
    public EmailSenderRepository(RepositoryContext repositoryContext) :base(repositoryContext)
    { }
  }
}
