using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
  /// <summary>
  /// Service for replace placeholder in html content.
  /// </summary>
  public interface IPlaceholderService
  {
    /// <summary>
    /// Get placeholders from apllication.
    /// </summary>
    /// <returns>List of placeholders.</returns>
    List<string> GetPlaceholdersFromApplication(List<string> attributeFilter = null);

    /// <summary>
    /// Replace placeholders with values.
    /// </summary>
    /// <param name="data">Data oject needs to replace placeholders.</param>
    /// <param name="content">Content with placeholders.</param>
    /// <returns></returns>
    string ReplacePlaceholders(List<object> data, string content);
  }
}
