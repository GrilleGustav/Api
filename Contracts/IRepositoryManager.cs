// <copyright file="IRepositoryManager.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
  public interface IRepositoryManager
  {
    IEmailServerRepository EmailServer { get; }

    IEmailSenderRepository EmailSender { get; }

    IEmailTemplateRepository EmailTemplate { get; }

    IEmailMessageRepository EmailMessage { get; }

    IRefreshTokenRepository RefreshToken { get; }

    ITemplateTypeRepository TemplateType { get; }

    /// <summary>
    /// Save database actions.
    /// </summary>
    void Save();

    /// <summary>
    /// Save asynchronous database actions.
    /// </summary>
    /// <returns></returns>
    Task<int> SaveAsync();
  }
}
