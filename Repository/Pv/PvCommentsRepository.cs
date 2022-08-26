// <copyright file="PvCommentsRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts.Pv;
using Entities.Context;
using Entities.Models.Pv;

namespace Repository.Pv
{
  /// <summary>
  /// User for repository initialization.
  /// </summary>
  public class PvCommentsRepository : RepositoryBase<PvComments>, IPvCommentRepository
  {
    private RepositoryContext _repositoryContext;

    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public PvCommentsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
