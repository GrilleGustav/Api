// <copyright file="ServiceExtensions.cs" company="GrilleGustav">
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
using Services;
using Services.Interfaces;
using Services.Interfaces.Pv.Storage;
using Services.Pv.Storage;
using System;

namespace Api.Extensions
{
  public static class ServiceExtensions
  {

    public static void ConfigureCors(this IServiceCollection services) =>
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("http://localhost:4200", "http://127.0.0.1:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
      });

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            { });

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<RepositoryContext>(opt =>
      opt.UseMySql("Server=127.0.0.1;port=3306;database=api;uid=root;pwd=123;charset=latin1",
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

    public static void ConfigureApplicationClaimsService(this IServiceCollection services)
    {
      services.AddSingleton<IApplicationClaimsService, ApplicationClaimsService>();
    }

    public static void ConfigurePvServices(this IServiceCollection services)
    {
      services.AddScoped<IVendorService, VendorService>();
    }
  }
}
