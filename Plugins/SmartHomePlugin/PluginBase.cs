
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomePlugin
{
  public class PluginBase : IPluginBase
  {
    public IConfiguration _configuration;
    public IServiceCollection _services;

    public PluginBase(IServiceCollection services)
    {
      _services = services;
    }

    public PluginBase(IConfiguration configuration, IServiceCollection services)
    {
      _configuration = configuration;
      _services = services;
    }

    public string Name { get => "SmartHome"; }

    public int Initialize()
    {
      Console.WriteLine("SmartHome loaded...");
      return 0;
    }
  }
}
