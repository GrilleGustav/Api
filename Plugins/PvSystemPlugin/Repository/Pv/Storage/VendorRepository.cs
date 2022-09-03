// <copyright file="VendorRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts.Pv.Storage;
using PvSystemPlugin.Entities.Context;
using PvSystemPlugin.Entities.Models.Pv.Storage;

namespace PvSystemPlugin.Repository.Pv.Storage
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public class VendorRepository : RepositoryPvBase<Vendor>, IVendorRepository
  {
    private RepositoryPvContext _repositoryContext;

    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public VendorRepository(RepositoryPvContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
