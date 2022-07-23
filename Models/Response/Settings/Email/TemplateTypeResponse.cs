using Models.View.Settings.Email;
using System.Collections.Generic;

namespace Models.Response.Settings.Email
{
  /// <summary>
  /// Template type response.
  /// </summary>
  public class TemplateTypeResponse : ErrorResponse
  {

    /// <summary>
    /// Template type reponse.
    /// </summary>
    public TemplateTypeResponse()
    { }

    /// <summary>
    /// Template type response.
    /// </summary>
    /// <param name="templateType">Template types.</param>
    public TemplateTypeResponse(TemplateTypeViewModel templateType)
    {
      this.templateType = templateType;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set template type.
    /// </summary>
    TemplateTypeViewModel templateType { get; set; }
  }
}