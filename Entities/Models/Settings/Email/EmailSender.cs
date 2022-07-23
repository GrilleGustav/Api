// <copyright file="EmailSender.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Attributes;
using System.Collections.Generic;

namespace Entities.Models.Settings.Email
{
  /// <summary>
  /// Settings for Sender.
  /// </summary>
  public class EmailSender
  {
    /// <summary>
    /// Get or set id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set sender.
    /// </summary>
    public string Sender { get; set; }

    // Navigation Properties

    /// <summary>
    /// Navigation Property to EmailTemplate Entity.
    /// </summary>
    public List<EmailTemplate> EmailTemplates { get; set; }
  }
}
