// <copyright file="HostingExtensions.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Api.Extensions
{
  public static class HostingExtension
  {
    /// <summary>
    /// Get plugin paths.
    /// </summary>
    /// <param name="webHostEnvironment">Provides information about the hosting environment an application is running in.</param>
    /// <returns></returns>
    public static List<string> GetPluginPaths(this IWebHostEnvironment webHostEnvironment)
    {
      var rootDirectory = new DirectoryInfo(webHostEnvironment.ContentRootPath).Parent;
      DirectoryInfo pluginsBasePath = new DirectoryInfo(Path.Combine(rootDirectory.ToString(), "Plugins"));
      return pluginsBasePath.GetFileSystemInfos("*.dll", SearchOption.AllDirectories)
        .Where(p => p.Name.Contains("Plugin") && p.FullName.Contains("bin") && p.FullName.Contains("Api") && !p.FullName.Contains("PluginBase") && !p.FullName.Contains("release") && !p.FullName.Contains("refs")).Select(pa => pa.FullName).ToList();
    }
  }
}
