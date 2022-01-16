using Contracts;
using Entities.Context;
using Entities.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  public class RefreshTokenRepository : RepositoryBase<RefreshToken>, IRefreshTokenRepository
  {
    private RepositoryContext _repositoryContext;
    public RefreshTokenRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
