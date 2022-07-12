using Entities.Models.Settings.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure template type configuration.
  /// </summary>
  public class TemplateTypeConfiguration : IEntityTypeConfiguration<TemplateType>
  {
    /// <summary>
    /// Template type configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<TemplateType> builder)
    {
      TemplateType register = new TemplateType()
      {
        Id = 1,
        Name = "Register",
        PluginName = "BaseApplication"
      };
      TemplateType passwordReset = new TemplateType()
      {
        Id = 2,
        Name = "PasswordReset",
        PluginName = "BaseApplication"
      };

      builder.HasData(register);
      builder.HasData(passwordReset);

      builder.HasIndex(x => x.Name).IsUnique();

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();
    }
  }
}
