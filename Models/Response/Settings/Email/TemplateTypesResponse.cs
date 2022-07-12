using Models.View.Settings.Email;
using System.Collections.Generic;

namespace Models.Response.Settings.Email
{
  /// <summary>
  /// Template types response.
  /// </summary>
  public class TemplateTypesResponse : ErrorResponse
  {

    /// <summary>
    /// Template types reponse.
    /// </summary>
    public TemplateTypesResponse()
    { }

    /// <summary>
    /// Template types response.
    /// </summary>
    /// <param name="templateTypes">Template types.</param>
    public TemplateTypesResponse(IList<TemplateTypeViewModel> templateTypes)
    {
      this.templateTypes = templateTypes;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set template types list.
    /// </summary>
    public IList<TemplateTypeViewModel> templateTypes { get; set; }
  }
}
