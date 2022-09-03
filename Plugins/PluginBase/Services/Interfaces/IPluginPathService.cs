using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.Services.Interfaces
{
  public interface IPluginPathService
  {
    List<string> GetPluginDlls();
    void LoadPlugins(List<string> pluginPaths);
  }
}
