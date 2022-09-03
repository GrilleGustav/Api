// <copyright file="ProductionAddressConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PvSystemPlugin.Entities.Models.Pv.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace PvSystemPlugin.Entities.Configuration.Pv.Storage
{
  /// <summary>
  /// Class to configure production address entity.
  /// </summary>
  public class ProductionAddressConfiguration : IEntityTypeConfiguration<ProductionAddress>
  {
    /// <summary>
    /// Vendor entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<ProductionAddress> builder)
    {
      builder.ToTable("Pv_Storage_" + nameof(ProductionAddress));

      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.ProductionAddress)
        .HasForeignKey(x => x.ProductionAddressId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

      builder.HasIndex(x => x.Name).IsUnique();

      builder.HasIndex(x => x.Code).IsUnique();

      builder.HasData(
        new ProductionAddress
        {
          Id = 1,
          Name = "Jingmen",
          Code = "J"
        });

      builder.HasData(
        new ProductionAddress
        {
          Id = 2,
          Name = "Huizhou",
          Code = "H"
        });
    }
  }
}
