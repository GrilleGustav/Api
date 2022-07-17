// <copyright file="EmailTemplateConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.HasData(
        new EmailTemplate
        {
          Id = 1,
          Name = "Register 1",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one.",
          Content = "<p>Please click on the link below to confirm your registration.</p><p><span class='placeholder'>{ConfirmLink}</span></p>",
          Predefined = true,
          Language = Enums.Language.Englisch,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 1
        });

      builder.HasData(
        new EmailTemplate
        {
          Id = 2,
          Name = "changeEmail",
          Description = "Taplate for changing email.",
          Content = "<p>Click on the link below to change your email:</p><p><span class='placeholder'>{ChangeEmialLink}</span></p>",
          Predefined = true,
          Language = Enums.Language.Englisch,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 3
  });
    }
  }
}
