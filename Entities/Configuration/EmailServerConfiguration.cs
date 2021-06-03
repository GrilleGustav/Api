// <copyright file="EmailServerConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure EmailServer entity.
  /// </summary>
  public class EmailServerConfiguration : IEntityTypeConfiguration<EmailServer>
  {
    /// <summary>
    /// EmailServer entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<EmailServer> builder)
    {
      builder.HasKey(x => x.Id);

      builder.HasData(
        new EmailServer
        {
          Id = 1,
          Default = true,
          ServerIp = "mail.grillegustav.de",
          ServerPort = "25",
          ServerUsername = "developper@grillegustav.de",
          ServerPassword = "mobuapXikC",
          Description = "Testbenutzer"
        });
    }
  }
}
