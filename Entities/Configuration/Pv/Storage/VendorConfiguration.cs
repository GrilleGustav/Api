// <copyright file="VendorConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration.Pv.Storage
{
  /// <summary>
  /// Class to configure vendor entity.
  /// </summary>
  public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
  {
    /// <summary>
    /// Vendor entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.Vendor)
        .HasForeignKey(x => x.VendorId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

      builder.HasData(
        new Vendor
        {
          Id = 1,
          Name = "EVE",
          Code = "04Q"
        });
    }
  }
}
