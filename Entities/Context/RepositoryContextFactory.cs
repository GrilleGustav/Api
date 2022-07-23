// <copyright file="RepositoryContextFactory.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Entities.Context
{
  /// <summary>
  /// Context factory to create database to development time.
  /// </summary>
  public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
  {
    public RepositoryContext CreateDbContext(string[] args)
    {
      DbContextOptionsBuilder<RepositoryContext> optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
      optionsBuilder.UseMySql("Server=127.0.0.1;port=3306;database=api;uid=root;pwd=123;charset=latin1", new MySqlServerVersion(new System.Version(10, 5, 8)));
      return new RepositoryContext(optionsBuilder.Options);
    }
  }
}
