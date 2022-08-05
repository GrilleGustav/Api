// <copyright file="BatteryCellConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class to configure battery cell entity.
/// </summary>
namespace Entities.Configuration.Pv.Storage
{
  public class BatteryCellConfiguration : IEntityTypeConfiguration<BatteryCell>
  {
    /// <summary>
    /// Battery cell entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<BatteryCell> builder)
    {
      builder.ToTable("Pv_Storage_" + nameof(BatteryCell));

      builder.HasKey(x => x.Id);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
    }
  }
}
