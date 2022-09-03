// <copyright file="RepositoryPvContext.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using PvSystemPlugin.Entities.Configuration.Pv;
using PvSystemPlugin.Entities.Configuration.Pv.Storage;
using PvSystemPlugin.Entities.Models.Pv;
using PvSystemPlugin.Entities.Models.Pv.Storage;

namespace PvSystemPlugin.Entities.Context
{
  public class RepositoryPvContext : DbContext
  {
    public RepositoryPvContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Pv
      modelBuilder.ApplyConfiguration(new PvCommentsConfiguration());
      // Pv-Storage
      modelBuilder.ApplyConfiguration(new BatteryBlockConfiguration());
      modelBuilder.ApplyConfiguration(new BatteryCellConfiguration());
      modelBuilder.ApplyConfiguration(new CellSpecificationConfiguration());
      modelBuilder.ApplyConfiguration(new CellTypeConfiguration());
      modelBuilder.ApplyConfiguration(new ProductionAddressConfiguration());
      modelBuilder.ApplyConfiguration(new ProductionTypeConfiguration());
      modelBuilder.ApplyConfiguration(new PvStorageConfiguration());
      modelBuilder.ApplyConfiguration(new VendorConfiguration());
    }

    // Pv
    public DbSet<PvComments> PvComments { get; set; }

    // Pv-Storage
    public DbSet<BatteryBlock> BatteryBlocks { get; set; }
    public DbSet<BatteryCell> BatteryCells { get; set; }
    public DbSet<CellSpecification> CellSpecifications { get; set; }
    public DbSet<CellType> CellTypes { get; set; }
    public DbSet<ProductionAddress> ProductionAddresses { get; set; }
    public DbSet<ProductionType> ProductionTypes { get; set; }
    public DbSet<PvStorage> PvStorages { get; set; }
    public DbSet<Vendor> Vendor { get; set; }
  }
}
