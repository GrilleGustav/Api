// <copyright file="ICellSpecificationRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using PvSystemPlugin.Entities.Models.Pv.Storage;

namespace Contracts.Pv.Storage
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public interface ICellSpecificationRepository : IRepositoryPvBase<CellSpecification>
  {
  }
}
