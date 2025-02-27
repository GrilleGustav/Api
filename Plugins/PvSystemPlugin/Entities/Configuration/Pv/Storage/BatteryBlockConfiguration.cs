﻿// <copyright file="BatteryBlockConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PvSystemPlugin.Entities.Models.Pv.Storage;

namespace PvSystemPlugin.Entities.Configuration.Pv.Storage
{
  /// <summary>
  /// Class to configure battery block entity.
  /// </summary>
  public class BatteryBlockConfiguration : IEntityTypeConfiguration<BatteryBlock>
  {
    /// <summary>
    /// Battery block entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<BatteryBlock> builder)
    {
      builder.ToTable("Pv_Storage_" + nameof(BatteryBlock));

      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.BatteryBlock)
        .HasForeignKey(x => x.BatteryBlockId);

      builder.HasMany(x => x.PvComments)
        .WithOne(x => x.BatteryBlock)
        .HasForeignKey(x => x.BatteryBlockId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
    }
  }
}
