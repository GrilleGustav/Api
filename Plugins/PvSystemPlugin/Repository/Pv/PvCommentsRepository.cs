// <copyright file="PvCommentsRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Contracts.Pv;
using PvSystemPlugin.Entities.Context;
using PvSystemPlugin.Entities.Models.Pv;

namespace PvSystemPlugin.Repository.Pv
{
  /// <summary>
  /// User for repository initialization.
  /// </summary>
  public class PvCommentsRepository : RepositoryPvBase<PvComments>, IPvCommentRepository
  {
    private RepositoryPvContext _repositoryContext;

    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public PvCommentsRepository(RepositoryPvContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
