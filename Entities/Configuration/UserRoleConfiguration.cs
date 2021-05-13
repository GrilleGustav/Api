// <copyright file="UserRoleConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to configure IdentityUserRole entity.
  /// </summary>
  public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
  {
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
      builder.HasData(
        new IdentityUserRole<string>
        {
          RoleId = "a0615a54-e885-46a9-9215-ea78faec2084",
          UserId = "493adb36-1365-4cd5-9ecf-93e0078e152b"
        });
    }
  }
}
