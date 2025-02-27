﻿// <copyright file="EmailTemplatesResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Models.View.Settings.Email;
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
    public EmailTemplatesResponse(IList<EmailTemplateViewModel> emailTemplates)
    {
      this.EmailTemplates = emailTemplates;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set email template list.
    /// </summary>
    public IList<EmailTemplateViewModel> EmailTemplates { get; set; }
  }
}
