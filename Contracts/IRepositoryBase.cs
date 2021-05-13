// <copyright file="IRepositoryBase.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
  public interface IRepositoryBase<T>
  {
    /// <summary>
    /// Get all records from the entity type.
    /// </summary>
    /// <param name="trackChanges">Track changes of found entities.</param>
    /// <returns>Return all found entites.</returns>
    IQueryable<T> FindAll(bool trackChanges);

    /// <summary>
    /// Get one or more records of a certain condition.
    /// </summary>
    /// <param name="expression">Condition.</param>
    /// <param name="trackChanges">Track changes of found entities.</param>
    /// <returns>Return all found entities.</returns>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    /// <summary>
    /// Create one record.
    /// </summary>
    /// <param name="entity">Entity to create.</param>
    void Create(T entity);

    /// <summary>
    /// Create one or more entitys.
    /// </summary>
    /// <param name="entities">Entities to create.</param>
    void CreateRange(List<T> entities);

    /// <summary>
    /// Update one entity.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Update one or more entities.
    /// </summary>
    /// <param name="entities">Entities to update.</param>
    void UpdateRange(List<T> entities);

    /// <summary>
    /// Delete one entity.
    /// </summary>
    /// <param name="entity">Entity to delete.</param>
    void Delete(T entity);
  }
}
