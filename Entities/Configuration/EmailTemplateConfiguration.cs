// <copyright file="EmailTemplateConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure EmailServer Entity.
  /// </summary>
  public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
  {
    /// <summary>
    /// IdentityRole entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<EmailTemplate> builder)
    {
      builder.HasKey(x => x.Id);

      builder.HasOne(x => x.EmailSender)
        .WithMany(x => x.EmailTemplates)
        .HasForeignKey(x => x.EmailSenderId);

      builder.HasData(
        new EmailTemplate
        {
          Id = 1,
          Name = "Register 1",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one.",
          Content = "<p>Please click on the link below to confirm your registration.</p><p><span class='placeholder'>{ConfirmLink}</span></p>",
          EmailTemplateType = Enums.EmailTemplateType.Register,
          Predefined = true,
          EmailSenderId = 1
        });
    }
  }
}
