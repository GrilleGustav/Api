// <copyright file="EmailServerSettingsResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using System.Collections.Generic;

namespace Models.Response.Settings.Email
{
  /// <summary>
  /// Email servers response.
  /// </summary>
  public class EmailServerSettingsResponse : ErrorResponse
  {
    /// <summary>
    /// Email servers response.
    /// </summary>
    public EmailServerSettingsResponse()
    {}

    /// <summary>
    /// Email servers response.
    /// </summary>
    /// <param name="emailServers">Email servers.</param>
    public EmailServerSettingsResponse(List<EmailServer> emailServers)
    {
      this.EmailServers = emailServers;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set email server list.
    /// </summary>
    public List<EmailServer> EmailServers { get; set; }
  }
}
