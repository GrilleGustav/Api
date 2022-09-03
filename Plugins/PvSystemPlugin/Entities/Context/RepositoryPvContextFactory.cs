// <copyright file="RepositoryPvContextFactory.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PvSystemPlugin.Entities.Context
{
  /// <summary>
  /// Context factory to create database to development time.
  /// </summary>
  public class RepositoryPvContextFactory : IDesignTimeDbContextFactory<RepositoryPvContext>
  {
    public RepositoryPvContext CreateDbContext(string[] args)
    {
      DbContextOptionsBuilder<RepositoryPvContext> optionsBuilder = new DbContextOptionsBuilder<RepositoryPvContext>();
      optionsBuilder.UseMySql("Server=127.0.0.1;port=3306;database=api;uid=root;pwd=123;charset=latin1", new MySqlServerVersion(new System.Version(10, 5, 8)));
      return new RepositoryPvContext(optionsBuilder.Options);
    }
  }
}
