﻿// <copyright file="UserConfiguration.cs" company="GrilleGustav">
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
  /// Class to configure User entity.
  /// </summary>
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    /// <summary>
    /// IdentitUser entity configuration.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
      User user = new User()
      {
        Id = Guid.Parse("493adb36-1365-4cd5-9ecf-93e0078e152b"),
        UserName = "sam@web.de",
        Firstname = "Sam",
        Lastname = "Sampleman",
        NormalizedUserName = "SAM@WEB.DE",
        Email = "sam@web.de",
        NormalizedEmail = "SAM@WEB.DE",
        EmailConfirmed = true,
        Language = Enums.Language.Germany,
        ConcurrencyStamp = "9b7d341b-d91d-4dec-a439-41df3f2a0d78",
        SecurityStamp = "9b7d341b-d91d-4dec-a439-41df3f2a0d79"
      };

      PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
      user.PasswordHash = passwordHasher.HashPassword(user, "Test123456!");

      builder.HasData(user);

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();
    }
  }
}
