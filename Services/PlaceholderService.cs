using Attributes;
using Contracts;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Services
{
  /// <summary>
  /// Service for replace placeholder in html content.
  /// </summary>
  public class PlaceholderService : IPlaceholderService
  {
    private ILogger<PlaceholderService> _logger;
    private readonly IRepositoryManager _repository;

    public PlaceholderService(ILogger<PlaceholderService> logger, IRepositoryManager repositoryManager)
    {
      _logger = logger;
      _repository = repositoryManager;
      this.InitialAddTemplateTypes();
    }

    /// <summary>
    /// Get or set template types.
    /// </summary>
    private List<string> TemplateType { get; set; } = new List<string>();

    /// <summary>
    /// Set template type.
    /// </summary>
    /// <param name="name">Template type name.</param>
    public void AddTemplateType(string name)
    {
      if (!this.TemplateType.Contains(name))
        this.TemplateType.Add(name);
    }

    /// <summary>
    /// Get placeholders from apllication.
    /// </summary>
    /// <returns>List of placeholders.</returns>
    public List<string> GetPlaceholdersFromApplication(List<string> attributeFilter = null)
    {
      List<string> placeholderNames = new List<string>();
      foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic))
      {
        foreach (Type ty in ass.GetExportedTypes())
        {
          foreach (PropertyInfo prop in ty.GetProperties())
          {
            PlaceholderAttribute[] attrs = prop.GetCustomAttributes(typeof(PlaceholderAttribute), true) as PlaceholderAttribute[];
            foreach (object attr in attrs)
            {
              var test = ((PlaceholderAttribute)attr).templateName;
              if (attributeFilter != null && attributeFilter.Count > 0)
              {
                if (attr != null && attributeFilter.Contains(((PlaceholderAttribute)attr).templateName))
                {
                  placeholderNames.Add(ty.Name + "." + prop.Name);
                  string name = ty.Name;
                }
              }
            }
          }
        }
      }

      return placeholderNames;
    }

    /// <summary>
    /// Replace placeholders with values.
    /// </summary>
    /// <param name="data">Data oject needs to replace placeholders.</param>
    /// <param name="content">Content with placeholders.</param>
    /// <returns></returns>
    public string ReplacePlaceholders(List<object> data, string content)
    {
      List<object> list = new List<object>();
      foreach (object item in data)
      {
        var a = item.GetType().GetProperties();
        foreach (var property in a)
        {
          if (property.GetIndexParameters().Length == 0)
          {
            if (property.GetValue(item) != null)
              content = content.Replace(string.Format("{{{0}.{1}}}", item.GetType().Name, property.Name), property.GetValue(item).ToString());
          }
        }
      }
      return content;
    }

    /// <summary>
    /// Replace placeholders with values.
    /// </summary>
    /// <param name="data">Data oject needs to replace placeholders.</param>
    /// <param name="content">Content with placeholders.</param>
    /// <returns></returns>
    public string ReplacePlaceholders(string content)
    {
      foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic))
      {
        foreach (Type ty in ass.GetExportedTypes())
        {
          foreach (PropertyInfo prop in ty.GetProperties())
          {
            object[] attrs = prop.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
              PlaceholderAttribute placeholderAttribute = attr as PlaceholderAttribute;
              if (placeholderAttribute != null)
              {
                string aedfc = prop.Name;
                string name = ty.Name;

              }
            }
          }
        }
      }
      return content;
    }

    /// <summary>
    /// Initialise templates of base software.
    /// </summary>
    private void InitialAddTemplateTypes()
    {
      this.AddTemplateType("register");
      this.AddTemplateType("passwortReset");
    }
  }
}
