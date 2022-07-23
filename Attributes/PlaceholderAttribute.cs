using System;

namespace Attributes
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property)]
  public class PlaceholderAttribute : Attribute
  {
    public string templateName { get; private set; }
    public PlaceholderAttribute(string name)
    {
      this.templateName = name;
    }
  }
}
