using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvSystemPlugin
{
  public class PvSystemPlugin : IPluginBase
  {
    public string Name { get => "PvSystem"; }

    public int Initialize()
    {
      Console.WriteLine("PvSystem loaded...");
      return 0;
    }
  }
}
