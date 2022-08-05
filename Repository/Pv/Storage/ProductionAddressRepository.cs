// <copyright file="VendorRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts.Pv.Storage;
using Entities.Context;
using Entities.Models.Pv.Storage;

namespace Repository.Pv.Storage
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public class ProductionAddressRepository : RepositoryBase<ProductionAddress>,  IProductionAddressRepository
  {
    private RepositoryContext _repositoryContext;

    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public ProductionAddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
