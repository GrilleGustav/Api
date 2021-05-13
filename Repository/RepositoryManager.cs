// <copyright file="RepositoryManager.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using System.Threading.Tasks;

namespace Repository
{
  public class RepositoryManager : IRepositoryManager
  {
    private RepositoryContext _repositoryContext;
    private IEmailServerRepository _emailServerRepository;
    private IEmailSenderRepository _emailSenderRepository;
    private IEmailTemplateRepository _emailTemplateRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEmailServerRepository EmailServer
    {
      get
      {
        if (_emailServerRepository == null)
          _emailServerRepository = new EmailServerRepository(_repositoryContext);

        return _emailServerRepository;
      }
    }

    public IEmailSenderRepository EmailSender
    {
      get
      {
        if (_emailServerRepository == null)
          _emailSenderRepository = new EmailSenderRepository(_repositoryContext);

        return _emailSenderRepository;
      }
    }

    public IEmailTemplateRepository EmailTemplate
    {
      get
      {
        if (_emailTemplateRepository == null)
          _emailTemplateRepository = new EmailTemplateRepository(_repositoryContext);

        return _emailTemplateRepository;
      }
    }

    /// <summary>
    /// Save database actions.
    /// </summary>
    public void Save() => _repositoryContext.SaveChanges();

    /// <summary>
    /// Save asynchronous database actions.
    /// </summary>
    /// <returns>Returns number of entities changed or add or delete.</returns>
    public Task<int> SaveAsync() => _repositoryContext.SaveChangesAsync();
  }
}
