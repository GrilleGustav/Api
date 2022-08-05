// <copyright file="CellTypeConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration.Pv.Storage
{
  /// <summary>
  /// Class to configure celltype entity.
  /// </summary>
  public class CellTypeConfiguration : IEntityTypeConfiguration<CellType>
  {
    /// <summary>
    /// Celltype entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<CellType> builder)
    {
      builder.ToTable("Pv_Storage_" + nameof(CellType));

      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.CellType)
        .HasForeignKey(x => x.VendorId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

      builder.HasIndex(x => x.Name).IsUnique();

      builder.HasIndex(x => x.Code).IsUnique();

      builder.HasData(
        new CellType
        {
          Id = 1,
          Name = "LifePo4",
          Code = 'B'
        });
    }
  }
}
