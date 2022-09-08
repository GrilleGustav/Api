using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase
{
  public interface IPluginBase
  {
    public string Name { get; }
    //int Initialize(IServiceCollection services, IConfiguration configuration);
    int Initialize();
  }
}
