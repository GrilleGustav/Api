using Entities.Models.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure EmailMessage entity.
  /// </summary>
  public class EmailMessageConfiguration : IEntityTypeConfiguration<EmailMessage>
  {
    /// <summary>
    /// EmailMessage entity configuration.
    /// </summary>
    /// <param name="builder">Configuration builder.</param>
    public void Configure(EntityTypeBuilder<EmailMessage> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id).HasDefaultValueSql("UUID()").ValueGeneratedOnAdd();

      builder.Property(x => x.SendOn).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();

      builder.Ignore(x => x.To);
    }
  }
}
