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
using PluginBase.Context;
using Repository;
using Services;
using Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using PluginBase;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

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

    public static void InitializePlugins(this IServiceCollection services, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
      List<string> pluginPaths = webHostEnvironment.GetPluginPaths();
      services.LoadPlugins(pluginPaths, configuration);

      services.AddControllers();
    }

    private static void LoadPlugins(this IServiceCollection services, List<string> pluginPaths, IConfiguration configuration)
    {
      IEnumerable<IPluginBase> plugins = pluginPaths.SelectMany(pluginPath =>
      {
        Assembly pluginAssembly = LoadPlugin(pluginPath);
        // AssemblyPart part = new AssemblyPart(pluginAssembly);
        //services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(pluginAssembly));
        //services.AddMvc().AddApplicationPart(pluginAssembly).AddControllersAsServices();
        
        return CreatePlugin(pluginAssembly);
      }).ToList();

      if (plugins != null || plugins.Count() != 0)
      {
        foreach (IPluginBase plugin in plugins)
        {
          plugin.Initialize();
        }
      }
      Console.WriteLine();
    }

    private static Assembly LoadPlugin(string relativePath)
    {
      Console.WriteLine($"Loading plugin from: {relativePath}");
      PluginLoadContext loadContext = new PluginLoadContext(relativePath);
      return loadContext.LoadFromAssemblyName((AssemblyName.GetAssemblyName(relativePath)));
    }

    private static IEnumerable<IPluginBase> CreatePlugin(Assembly assembly)
    {
      int count = 0;
      foreach (Type type in assembly.GetTypes())
      {
        if (typeof(IPluginBase).IsAssignableFrom(type))
        {
          IPluginBase result = Activator.CreateInstance(type) as IPluginBase;
          if (result != null)
          {
            count++;
            yield return result;
          }
        }
      }

      if (count == 0)
      {
        string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
        throw new ApplicationException(
            $"Can't find any type which implements IPluginBase in {assembly} from {assembly.Location}.\n" +
            $"Available types: {availableTypes}");
      }
    }

    ///// <summary>
    ///// Connfigure PV-Services.
    ///// </summary>
    ///// <param name="services">Service collection to register services.</param>
    //public static void ConfigurePvServices(this IServiceCollection services)
    //{
    //  services.AddScoped<IBatteryBlockService, BatteryBlockService>();
    //  services.AddScoped<IBatteryCellService, BatteryCellService>();
    //  services.AddScoped<ICellSpecificationService, CellSpecificationService>();
    //  services.AddScoped<ICellTypeService, CellTypeService>();
    //  services.AddScoped<IProductionAddressService, ProductionAddressService>();
    //  services.AddScoped<IProductionTypeService, ProductionTypeService>();
    //  services.AddScoped<IPvStorageService, PvStorageService>();
    //  services.AddScoped<IVendorService, VendorService>();
    //}
  }
}
