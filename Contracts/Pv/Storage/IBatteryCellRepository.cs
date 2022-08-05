// <copyright file="IBatteryCellRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;

namespace Contracts.Pv.Storage
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public interface IBatteryCellRepository : IRepositoryBase<BatteryCell>
  {
  }
}
