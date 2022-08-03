// <copyright file="PvStorageConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration.Pv.Storage
{
  /// <summary>
  /// Class to configure pvStorage entity.
  /// </summary>
  public class PvStorageConfiguration : IEntityTypeConfiguration<PvStorage>
  {
    /// <summary>
    /// PvStorage entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<PvStorage> builder)
    {
      builder.HasKey(x => x.Id);
      builder.HasMany(x => x.BatteryBlocks)
        .WithOne(x => x.PvStorage)
        .HasForeignKey(x => x.PvStorageId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
    }
  }
}
