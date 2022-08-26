using Entities.Configuration;
using Entities.Configuration.Pv;
using Entities.Configuration.Pv.Storage;
using Entities.Models.Account;
using Entities.Models.Email;
using Entities.Models.Pv;
using Entities.Models.Pv.Storage;
using Entities.Models.Settings.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Context
{
  public class RepositoryContext : IdentityDbContext<User, Role, Guid>
  {
    public RepositoryContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new RoleConfiguration());
      modelBuilder.ApplyConfiguration(new EmailServerConfiguration());
      modelBuilder.ApplyConfiguration(new EmailSenderConfiguration());
      modelBuilder.ApplyConfiguration(new EmailTemplateConfiguration());
      modelBuilder.ApplyConfiguration(new UserConfiguration());
      modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
      modelBuilder.ApplyConfiguration(new EmailMessageConfiguration());
      modelBuilder.ApplyConfiguration(new RoleClaimsConfiguration());
      modelBuilder.ApplyConfiguration(new TemplateTypeConfiguration());

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

    public DbSet<EmailServer> EmailServers { get; set; }
    public DbSet<EmailSender> EmailSenders { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<EmailMessage> EmailMessages { get; set; }

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
