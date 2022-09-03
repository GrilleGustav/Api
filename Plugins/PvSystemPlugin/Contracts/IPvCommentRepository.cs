// <copyright file="IPvCommentRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts.Pv.Storage;
using PvSystemPlugin.Entities.Models.Pv;

namespace Contracts.Pv
{
  /// <summary>
  /// User for repository initalization.
  /// </summary>
  public interface IPvCommentRepository : IRepositoryPvBase<PvComments>
  {
  }
}
