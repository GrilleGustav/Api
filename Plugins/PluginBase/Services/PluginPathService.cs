using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PluginBase.Context;
using PluginBase.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.Services
{
  public class PluginPathService : IPluginPathService
  {
    IHostingEnvironment _hostingEnvironment;

    public PluginPathService(IHostingEnvironment hostingEnvironment)
    {
      _hostingEnvironment = hostingEnvironment;
    }

    public List<string> GetPluginDlls()
    {
      var rootDirectory = new DirectoryInfo(_hostingEnvironment.ContentRootPath).Parent;
      DirectoryInfo pluginsBasePath = new DirectoryInfo(Path.Combine(rootDirectory.ToString(), "Plugins"));
      return pluginsBasePath.GetFileSystemInfos("*.dll", SearchOption.AllDirectories)
        .Where(p => p.Name.Contains("Plugin") && p.FullName.Contains("bin") && p.FullName.Contains("Api") && !p.FullName.Contains("PluginBase") && !p.FullName.Contains("release") && !p.FullName.Contains("refs")).Select(pa => pa.FullName).ToList();
    }

    public void LoadPlugins(List<string> pluginPaths)
    {
      IEnumerable<IPluginBase> plugins = pluginPaths.SelectMany(pluginPath =>
      {
        Assembly pluginAssembly = LoadPlugin(pluginPath);
        return this.CreatePlugin(pluginAssembly);
      }).ToList();

      if (plugins != null)
      {
        plugins.First().Initialize();
      }
      Console.WriteLine();
    }

    public Assembly LoadPlugin(string relativePath)
    {
      Console.WriteLine($"Loading plugin from: {relativePath}");
      PluginLoadContext loadContext = new PluginLoadContext(relativePath);
      return loadContext.LoadFromAssemblyName((AssemblyName.GetAssemblyName(relativePath)));
    }

    private IEnumerable<IPluginBase> CreatePlugin(Assembly assembly)
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
  }
}
