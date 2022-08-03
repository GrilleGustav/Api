// <copyright file="ProductionAddressConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration.Pv.Storage
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
      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.ProductionAddress)
        .HasForeignKey(x => x.ProductionAddressId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

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
