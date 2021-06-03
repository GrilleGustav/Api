// <copyright file="EmailTemplateResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;

namespace Models.Response.Settings.Email
{
  public class EmailTemplateResponse : ErrorResponse
  {
    /// <summary>
    /// Email template response.
    /// </summary>
    public EmailTemplateResponse()
    { }

    /// <summary>
    /// Email template response.
    /// </summary>
    /// <param name="emailTemplate">Email templates.</param>
    public EmailTemplateResponse(EmailTemplate emailTemplate)
    {
      this.EmailTemplate = emailTemplate;
    }

    /// <summary>
    /// Email template response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    public EmailTemplateResponse(string errorCode)
    {
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Email termplate response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    /// <param name="errorMessage">Error message.</param>
    public EmailTemplateResponse(string errorCode, string errorMessage)
    {
      this.ErrorCode = errorCode;
      this.ErrorMessage = errorMessage;
    }
    /// <summary>
    /// Get or set email template.
    /// </summary>
    public EmailTemplate EmailTemplate { get; set; }
  }
}
