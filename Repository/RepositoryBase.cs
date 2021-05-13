using Contracts;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
  public class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected RepositoryContext RepositoryContext { get; set; }

    public RepositoryBase(RepositoryContext repositoryContext)
    {
      RepositoryContext = repositoryContext;
    }

    /// <summary>
    /// Get all records from the entity type.
    /// </summary>
    /// <param name="trackChanges">Track changes of found entities.</param>
    /// <returns>Return all found entites.</returns>
    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

    /// <summary>
    /// Get one or more records of a certain condition.
    /// </summary>
    /// <param name="expression">Condition.</param>
    /// <param name="trackChanges">Track changes of found entities.</param>
    /// <returns>Return all found entities.</returns>
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges ?
              RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              RepositoryContext.Set<T>()
                .Where(expression);

    /// <summary>
    /// Create one record.
    /// </summary>
    /// <param name="entity">Entity to create.</param>
    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

    /// <summary>
    /// Create one or more entitys.
    /// </summary>
    /// <param name="entities">Entities to create.</param>
    public void CreateRange(List<T> entities) => RepositoryContext.Set<T>().AddRange(entities);

    /// <summary>
    /// Update one entity.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    /// <summary>
    /// Update one or more entities.
    /// </summary>
    /// <param name="entities">Entities to update.</param>
    public void UpdateRange(List<T> entities) => RepositoryContext.Set<T>().UpdateRange(entities);

    /// <summary>
    /// Delete one entity.
    /// </summary>
    /// <param name="entity">Entity to delete.</param>
    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
  }
}
