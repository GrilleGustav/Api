﻿// <auto-generated />
using System;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Entities.Models.Account.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Entities.Models.Account.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                            ConcurrencyStamp = "0d77443c-e615-41c1-a172-afcbb2405001",
                            Description = "Normal User.",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                            ConcurrencyStamp = "72a8107e-1276-4c2c-8d66-88a0a65cefb8",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                            ConcurrencyStamp = "c36c5ea6-1111-4b2e-90d0-f9e2fe3b6170",
                            Name = "Developper",
                            NormalizedName = "DEVELOPPER"
                        });
                });

            modelBuilder.Entity("Entities.Models.Account.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAccessedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "44517b0f-f6b5-420b-be34-4c1b2be0147d",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sam@web.de",
                            EmailConfirmed = true,
                            Firstname = "Sam",
                            Language = 0,
                            LastAccessedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lastname = "Sampleman",
                            LockoutEnabled = false,
                            NormalizedEmail = "SAM@WEB.DE",
                            NormalizedUserName = "SAM@WEB.DE",
                            PasswordHash = "AQAAAAEAACcQAAAAEP6HLPagAFhZbsN4EoCKVqhhcpV3DnDKBgu0AsxMCTy2DzRK6HaslSzQRDK2w+q1yg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "sam@web.de"
                        });
                });

            modelBuilder.Entity("Entities.Models.Email.EmailMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValueSql("UUID()");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("From")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsSend")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Receiver")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("SendOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("EmailMessages");
                });

            modelBuilder.Entity("Entities.Models.Settings.Email.EmailSender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Sender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("EmailSenders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Sender = "info@web.de"
                        });
                });

            modelBuilder.Entity("Entities.Models.Settings.Email.EmailServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<bool>("Default")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ServerIp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ServerPassword")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ServerPort")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ServerUsername")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("EmailServers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Default = true,
                            Description = "Testbenutzer",
                            ServerIp = "mail.grillegustav.de",
                            ServerPassword = "mobuapXikC",
                            ServerPort = "25",
                            ServerUsername = "developper@grillegustav.de"
                        });
                });

            modelBuilder.Entity("Entities.Models.Settings.Email.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Default")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("EmailSenderId")
                        .HasColumnType("int");

                    b.Property<int>("EmailTemplateType")
                        .HasColumnType("int");

                    b.Property<int>("LanguageCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Predefined")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("EmailSenderId");

                    b.ToTable("EmailTemplates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "<p>Please click on the link below to confirm your registration.</p><p><span class='placeholder'>{ConfirmLink}</span></p>",
                            Default = true,
                            Description = "Predefined template. Is used for the first installation if the administrator does not create one.",
                            EmailSenderId = 1,
                            EmailTemplateType = 0,
                            LanguageCode = 0,
                            Name = "Register 1",
                            Predefined = true
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Administrator",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailServerList",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailServerCreate",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailServerUpdate",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailServerRemove",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailTemplateList",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailTemplateCreate",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailTemplateUpdate",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailTemplateRemove",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "UserList",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "UserUpdate",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "EmailMessagesList",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "UserGroupList",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "UserGroupUpdate",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "UserGroupRemove",
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                            RoleId = new Guid("a0615a54-e885-46a9-9215-ea78faec2084")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.Models.Account.RefreshToken", b =>
                {
                    b.HasOne("Entities.Models.Account.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Settings.Email.EmailTemplate", b =>
                {
                    b.HasOne("Entities.Models.Settings.Email.EmailSender", "EmailSender")
                        .WithMany("EmailTemplates")
                        .HasForeignKey("EmailSenderId");

                    b.Navigation("EmailSender");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Entities.Models.Account.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Entities.Models.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Entities.Models.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Entities.Models.Account.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Entities.Models.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Account.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Entities.Models.Settings.Email.EmailSender", b =>
                {
                    b.Navigation("EmailTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
