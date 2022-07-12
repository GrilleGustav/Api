using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.View.Settings.Email
{
  /// <summary>
  /// Template type for templates.
  /// </summary>
  public class TemplateTypeViewModel
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set plugin name.
    /// </summary>
    [Required]
    public string PluginName { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a entity is persisted to the store.
    /// </summary>
    public DateTime ConcurrencyStamp { get; set; }


    /// <summary>
    /// A DateTime value that should change whenever a entity is persisted to the store.
    /// </summary>
    public DateTime UpdatedOn { get; set; }
  }
}
