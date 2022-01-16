// <copyright file="RoleConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure IdentityRole entity.
  /// </summary>
  public class RoleConfiguration : IEntityTypeConfiguration<Role>
  {
    /// <summary>
    /// IdentityRole entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.HasData(
        new Role
        {
          Id = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec1457"),
          Name = "User",
          NormalizedName = "USER",
          Description = "Normal User."
        },
        new Role
        {
          Name = "Administrator",
          NormalizedName = "ADMINISTRATOR",
          Id = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084")
        },
        new Role
        {
          Id = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec9985"),
          Name = "Developper",
          NormalizedName = "DEVELOPPER",
        }); ;
    }
  }
}
