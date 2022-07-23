using Entities.Configuration;
using Entities.Models.Account;
using Entities.Models.Email;
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
    }

    public DbSet<EmailServer> EmailServers { get; set; }
    public DbSet<EmailSender> EmailSenders { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<EmailMessage> EmailMessages { get; set; }
  }
}
