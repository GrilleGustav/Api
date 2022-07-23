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
          Name = "register 1",
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
          Name = "register 2",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one. It is for email confirmation.",
          Content = "<p>Bitte klicken sie auf den unten stehenden Link, um ihre Registrierung zu bestätigen.<br><span class='placeholder'>{RegisterConfirm}</span>&nbsp;</p>",
          Predefined = true,
          Language = Enums.Language.Germany,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 1
        });

      builder.HasData(
        new EmailTemplate
        {
          Id = 3,
          Name = "password reset 1",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one. It is for password reset.",
          Content = "<p>Please click on the link below to reset your password.</p><p><span class='placeholder'>{PasswortReset}</span></p>",
          Predefined = true,
          Language = Enums.Language.Englisch,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 2
        });

      builder.HasData(
        new EmailTemplate
        {
          Id = 4,
          Name = "password reset 1",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one. It is for password reset.",
          Content = "<p>Bitte klicken sie auf den unten stehenden Link, um ihr Passwort zurück zu setzen.</p><p><span class='placeholder'>{PasswortReset}</span></p>",
          Predefined = true,
          Language = Enums.Language.Germany,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 2
        });

      builder.HasData(
        new EmailTemplate
        {
          Id = 5,
          Name = "changeEmail 1",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for changing email.",
          Content = "<p>Click on the link below to change your email:</p><p><span class='placeholder'>{ChangeEmialLink}</span></p>",
          Predefined = true,
          Language = Enums.Language.Englisch,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 3
        });

      builder.HasData(
        new EmailTemplate
        {
          Id = 6,
          Name = "changeEmail 2",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for changing email.",
          Content = "<p>Bitte klicken sie auf den unten stehenden Link, um ihre E-Mail Adresse zu ändern.</p><p><span class='placeholder'>{ChangeEmialLink}</span></p>",
          Predefined = true,
          Language = Enums.Language.Germany,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 3
        });

      builder.HasData(
        new EmailTemplate
        {
          Id = 7,
          Name = "twoStep 1",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for sending TwoStep code for login.",
          Content = "<p>Two factor code:&nbsp;<span class='placeholder'>{TowStepCode}</span></p>",
          Predefined = true,
          Language = Enums.Language.Englisch,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 4
        });

      builder.HasData(
        new EmailTemplate
        {
          Id = 8,
          Name = "twoStep 2",
          Description = "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for sending TwoStep code for login.",
          Content = "<p>Zwei Stufen Code:<span class='placeholder'>{TowStepCode}</span></p>",
          Predefined = true,
          Language = Enums.Language.Germany,
          Default = true,
          EmailSenderId = 1,
          TemplateTypeId = 4
        });
    }
  }
}
