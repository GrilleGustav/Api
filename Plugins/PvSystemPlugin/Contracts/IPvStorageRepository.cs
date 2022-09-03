// <copyright file="IPvStorageRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using PvSystemPlugin.Entities.Models.Pv.Storage;

namespace Contracts.Pv.Storage
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public interface IPvStorageRepository : IRepositoryPvBase<PvStorage>
  {
  }
}
