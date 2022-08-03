// <copyright file="ProductionTypeConfiguration.cs" company="GrilleGustav">
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
  public class ProductionTypeConfiguration : IEntityTypeConfiguration<ProductionType>
  {
    /// <summary>
    /// ProductionType entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<ProductionType> builder)
    {
      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.BatteryCells)
        .WithOne(x => x.ProductionType)
        .HasForeignKey(x => x.ProductionTypeId);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

      builder.HasData(
        new ProductionType
        {
          Id = 1,
          Name = "Cell",
          Code ='C'
        });
    }
  }
}
