// <copyright file="EmailTemplatesResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using System.Collections.Generic;

namespace Models.Response.Settings.Email
{
  public class EmailTemplatesResponse : ErrorResponse
  {
    /// <summary>
    /// Email templates response.
    /// </summary>
    public EmailTemplatesResponse()
    {}

    /// <summary>
    /// Email templates response.
    /// </summary>
    /// <param name="emailTemplates">Email templates.</param>
    public EmailTemplatesResponse(List<EmailTemplate> emailTemplates)
    {
      this.EmailTemplates = emailTemplates;
    }

    /// <summary>
    /// Email templates response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    public EmailTemplatesResponse(string errorCode)
    {
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Email termplates response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    /// <param name="errorMessage">Error message.</param>
    public EmailTemplatesResponse(string errorCode, string errorMessage)
    {
      this.ErrorCode = errorCode;
      this.ErrorMessage = errorMessage;
    }
    /// <summary>
    /// Get or set email template list.
    /// </summary>
    public List<EmailTemplate> EmailTemplates { get; set; }
  }
}
