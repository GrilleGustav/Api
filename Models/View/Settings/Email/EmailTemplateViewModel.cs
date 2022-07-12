using Entities.Models.Settings.Email;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Settings.Email
{
  /// <summary>
  /// Email template view data.
  /// </summary>
  public class EmailTemplateViewModel
  {
    /// <summary>
    /// Get or set Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Get or set Description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Get or set Content.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Get or set Default template.
    /// </summary>
    public bool Default { get; set; }

    /// <summary>
    /// Get or set LanguageCode.
    /// </summary>
    public Language Language { get; set; }

    /// <summary>
    /// Get or set email type. Is used to provide the correct variables.
    /// </summary>
    public string EmailTemplateType { get; set; }

    /// <summary>
    /// Get or set predifined Template. Can't remove by user.
    /// </summary>
    public bool Predefined { get; set; }

    /// <summary>
    /// Foreign Key EmailSender.
    /// </summary>
    public int? EmailSenderId { get; set; }

    /// <summary>
    /// Foreign Key TemplateType.
    /// </summary>
    public int? TemplateTypeId { get; set; }

    /// <summary>
    /// A random value that should change whenever a entity is persisted to the store.
    /// </summary>
    public DateTime ConcurrencyStamp { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a entity is persisted to the store.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// Navigation property to EmailSender.
    /// </summary>
    public EmailSender EmailSender { get; set; }

    /// <summary>
    /// Navigation property to TemplateType.
    /// </summary>
    public TemplateType TemplateType { get; set; }
  }
}
