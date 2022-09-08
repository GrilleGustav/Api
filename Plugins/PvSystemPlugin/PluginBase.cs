using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PluginBase;
using PvSystemPlugin.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvSystemPlugin
{
  public class PluginBase : IPluginBase
  {
    public IConfiguration _configuration { get; }
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

    public string Name { get => "PvSystem"; }


    public int Initialize()
    {
      //services.AddDbContext<RepositoryPvContext>(opt => opt.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new System.Version(10, 5, 8)), b => b.MigrationsAssembly("Entities")));
      //services.BuildServiceProvider().GetService<RepositoryPvContext>().Database.Migrate();
      Console.WriteLine("PvSystem loaded...");
      return 0;
    }
  }
}
