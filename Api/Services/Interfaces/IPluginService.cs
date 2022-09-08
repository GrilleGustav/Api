using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.Services.Interfaces
{
  public interface IPluginService
  {
    void Initialize(IServiceCollection services);
  }
}
