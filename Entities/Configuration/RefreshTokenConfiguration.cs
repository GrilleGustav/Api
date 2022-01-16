using Entities.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
  public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
  {
    /// <summary>
    /// RefreshToken entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
      builder.HasKey(x => x.Id);

      builder.HasOne(x => x.User)
        .WithMany(x => x.RefreshTokens)
        .HasForeignKey(x => x.UserId);
    }
  }
}
