using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Settings.Email
{
  /// <summary>
  /// Template type for email templates.
  /// </summary>
  public class TemplateType
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Get or set plugin name.
    /// </summary>
    public string PluginName { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    public DateTime ConcurrencyStamp { get; set; }


    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// Navigation Property to EmailTemplate Entity.
    /// </summary>
    public List<EmailTemplate> EmailTemplates { get; set; }
  }
}
