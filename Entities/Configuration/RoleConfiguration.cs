// <copyright file="RoleConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure IdentityRole entity.
  /// </summary>
  public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
  {
    /// <summary>
    /// IdentityRole entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
      builder.HasData(
        new IdentityRole
        {
          Name = "User",
          NormalizedName = "USER"
        },
        new IdentityRole
        {
          Name = "Administrator",
          NormalizedName = "ADMINISTRATOR",
          Id = "a0615a54-e885-46a9-9215-ea78faec2084"
        },
        new IdentityRole
        {
          Name = "Developper",
          NormalizedName = "DEVELOPPER"
        });
    }
  }
}
