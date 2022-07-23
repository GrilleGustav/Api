// <copyright file="TemplateTypeRepository.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Entities.Models.Settings.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  /// <summary>
  /// Used for repository initalization.
  /// </summary>
  public class TemplateTypeRepository : RepositoryBase<TemplateType>, ITemplateTypeRepository
  {
    private RepositoryContext _repositoryContext;

    /// <summary>
    /// Used for repository initalization.
    /// </summary>
    /// <param name="repositoryContext">Database context.</param>
    public TemplateTypeRepository(RepositoryContext repositoryContext) :base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }
  }
}
