// <copyright file="IRefreshTokenRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Account;

namespace Contracts
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public interface IRefreshTokenRepository : IRepositoryPvBase<RefreshToken>
  {
  }
}
