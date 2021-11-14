// <copyright file="RoleClaimsConfiguration.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Entities.Configuration
{
  /// <summary>
  /// Class to cofigure IdentityRoleClaims entity.
  /// </summary>
  public class RoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
  {
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
      builder.HasData(
        new IdentityRoleClaim<Guid>
        {
          Id = 1,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "Administrator"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 2,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailServerList"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 3,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailServerCreate"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 4,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailServerUpdate"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 5,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailServerRemove"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 6,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailTemplateList"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 7,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailTemplateCreate"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 8,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailTemplateUpdate",
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 9,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailTemplateRemove"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 10,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "UserList"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 11,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "UserUpdate"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 12,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "EmailMessagesList"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 13,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "UserGroupList"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 14,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "UserGroupUpdate"
        },
        new IdentityRoleClaim<Guid>
        {
          Id = 15,
          RoleId = Guid.Parse("a0615a54-e885-46a9-9215-ea78faec2084"),
          ClaimType = ClaimTypes.Role,
          ClaimValue = "UserGroupRemove"
        }
        );
    }
  }
}
