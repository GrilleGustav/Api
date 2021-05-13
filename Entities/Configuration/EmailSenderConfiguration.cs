// <copyright file="EmailSenderConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure EmailSender entity.
  /// </summary>
  public class EmailSenderConfiguration : IEntityTypeConfiguration<EmailSender>
  {
    /// <summary>
    /// EmailSender entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<EmailSender> builder)
    {
      builder.HasKey(x => x.Id);
      builder.HasOne(x => x.EmailServer)
        .WithMany(x => x.EmailSender)
        .HasForeignKey(x => x.EmailServerId);

      builder.HasData(
        new EmailSender
        {
          Id = 1,
          EmailServerId = 1,
          Sender = "info@web.de"
        });
    }
  }
}
