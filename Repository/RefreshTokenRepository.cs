using Contracts;
using Entities.Context;
using Entities.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public class RefreshTokenRepository : RepositoryBase<RefreshToken>, IRefreshTokenRepository
  {
    private RepositoryContext _repositoryContext;

    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public RefreshTokenRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
