using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PluginBase.Context;
using PluginBase.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Api.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace PluginBase.Services
{
  public class PluginService : IPluginService
  {
    IWebHostEnvironment _webHostEnvironment;
    IServiceCollection _services;
    IConfiguration _configuration;

    public PluginService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
      _webHostEnvironment = webHostEnvironment;
      _configuration = configuration;
    }

    public void Initialize(IServiceCollection services)
    {
      _services = services;
      this.InitializePlugins();
    }

    public void InitializePlugins()
    {
      List<string> pluginPaths = _webHostEnvironment.GetPluginPaths();
      this.LoadPlugins(pluginPaths);
    }

    private void LoadPlugins(List<string> pluginPaths)
    {
      IEnumerable<IPluginBase> plugins = pluginPaths.SelectMany(pluginPath =>
      {
        Assembly pluginAssembly = LoadPlugin(pluginPath);
        AddApplicationParts(pluginAssembly);
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

    private Assembly LoadPlugin(string relativePath)
    {
      Console.WriteLine($"Loading plugin from: {relativePath}");
      PluginLoadContext loadContext = new PluginLoadContext(relativePath);
      return loadContext.LoadFromAssemblyName((AssemblyName.GetAssemblyName(relativePath)));
    }

    private void AddApplicationParts(Assembly pluginAssembly)
    {
      var mvcBuilder = _services.AddMvc();
      var partFactory = ApplicationPartFactory.GetApplicationPartFactory(pluginAssembly);
      foreach (var part in partFactory.GetApplicationParts(pluginAssembly))
      {
        mvcBuilder.PartManager.ApplicationParts.Add(part);
      }

      var relatedAssemblies = RelatedAssemblyAttribute.GetRelatedAssemblies(pluginAssembly, throwOnError: true);
      foreach (var assembly in relatedAssemblies)
      {
        partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);
        foreach (var part in partFactory.GetApplicationParts(assembly))
        {
          mvcBuilder.PartManager.ApplicationParts.Add(part);
        }
      }
    }

    private IEnumerable<IPluginBase> CreatePlugin(Assembly assembly)
    {
      int count = 0;
      foreach (Type type in assembly.GetTypes())
      {
        if (typeof(IPluginBase).IsAssignableFrom(type))
        {
          //var test = type.GetConstructors()[1].GetParameters();
          // var result = (IPluginBase)type.Assembly.CreateInstance(type.FullName, false, BindingFlags.CreateInstance, null, new object[] { _configuration, _services }, null, null);
          IPluginBase result = Activator.CreateInstance(type, new object[] { _services }) as IPluginBase;
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
