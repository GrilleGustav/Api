﻿// <copyright file="ServiceExtensions.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Entities.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Repository;

namespace Api.Extensions
{
  public static class ServiceExtensions
  {

    public static void ConfigureCors(this IServiceCollection services) =>
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
      });

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            { });

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<RepositoryContext>(opt =>
      opt.UseMySql("Server=127.0.0.1;port=3306;database=api;uid=fabian;pwd=1234;charset=latin1",
        new MySqlServerVersion(new System.Version(10, 5, 8)), b => b.MigrationsAssembly("Entities")));

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
      services.AddScoped<IRepositoryManager, RepositoryManager>();

    /// <summary>
    /// Add logging.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureLoggerService(this IServiceCollection services) =>
      services.AddLogging(l =>
      {
        l.ClearProviders();
        l.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
        l.AddNLog();
      });
  }
}
