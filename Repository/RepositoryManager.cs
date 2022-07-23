// <copyright file="RepositoryManager.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using System.Threading.Tasks;

namespace Repository
{
  /// <summary>
  /// Manage database backend.
  /// </summary>
  public class RepositoryManager : IRepositoryManager
  {
    private RepositoryContext _repositoryContext;
    private IEmailServerRepository _emailServerRepository;
    private IEmailSenderRepository _emailSenderRepository;
    private IEmailTemplateRepository _emailTemplateRepository;
    private IEmailMessageRepository _emailMessageRepository;
    private IRefreshTokenRepository _refreshTokenRepository;
    private ITemplateTypeRepository _templateTypeRepository;

    /// <summary>
    /// Manage database backend.
    /// </summary>
    /// <param name="repositoryContext">Connection to database backend.</param>
    public RepositoryManager(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    /// <summary>
    /// Initiate email server repository and make it accessible.
    /// </summary>
    public IEmailServerRepository EmailServer
    {
      get
      {
        if (_emailServerRepository == null)
          _emailServerRepository = new EmailServerRepository(_repositoryContext);

        return _emailServerRepository;
      }
    }

    /// <summary>
    /// Initiate email sender repository and make it accessible.
    /// </summary>
    public IEmailSenderRepository EmailSender
    {
      get
      {
        if (_emailServerRepository == null)
          _emailSenderRepository = new EmailSenderRepository(_repositoryContext);

        return _emailSenderRepository;
      }
    }

    /// <summary>
    /// Initiate email template repository and make it accessible.
    /// </summary>
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
    /// Initiate email message repository and make it accessible.
    /// </summary>
    public IEmailMessageRepository EmailMessage
    {
      get
      {
        if (_emailMessageRepository == null)
          _emailMessageRepository = new EmailMessageRepository(_repositoryContext);

        return _emailMessageRepository;
      }
    }

    /// <summary>
    /// Initiate refresh token repository and make it accessible.
    /// </summary>
    public IRefreshTokenRepository RefreshToken
    {
      get
      {
        if (_refreshTokenRepository == null)
          _refreshTokenRepository = new RefreshTokenRepository(_repositoryContext);

        return _refreshTokenRepository;
      }
    }

    /// <summary>
    /// Initiate template type repository and make it accessible.
    /// </summary>
    public ITemplateTypeRepository TemplateType
    {
      get
      {
        if (_templateTypeRepository == null)
          _templateTypeRepository = new TemplateTypeRepository(_repositoryContext);

        return _templateTypeRepository;
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
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException"></exception>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException"></exception>
    public Task<int> SaveAsync() => _repositoryContext.SaveChangesAsync();
  }
}
