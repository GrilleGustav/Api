// <copyright file="CellSpecificationConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration.Pv.Storage
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
      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.CellSpecification)
        .HasForeignKey(x => x.CellSpecificationId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

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
