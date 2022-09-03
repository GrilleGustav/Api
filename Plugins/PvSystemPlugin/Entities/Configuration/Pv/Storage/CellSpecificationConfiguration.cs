// <copyright file="CellSpecificationConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PvSystemPlugin.Entities.Models.Pv.Storage;

namespace PvSystemPlugin.Entities.Configuration.Pv.Storage
{
  /// <summary>
  /// Class to configure cellSpecification entity.
  /// </summary>
  public class CellSpecificationConfiguration : IEntityTypeConfiguration<CellSpecification>
  {
    /// <summary>
    /// CellSpecification entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<CellSpecification> builder)
    {
      builder.ToTable("Pv_Storage_" + nameof(CellSpecification));

      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.CellSpecification)
        .HasForeignKey(x => x.CellSpecificationId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

      builder.HasIndex(x => x.Name).IsUnique();

      builder.HasIndex(x => x.Code).IsUnique();

      builder.HasData(
        new CellSpecification
        {
          Id = 1,
          Name = "LF280K",
          Code = "76"
        });
    }
  }
}
