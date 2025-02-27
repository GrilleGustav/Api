﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PvSystemPlugin.Entities.Context;

namespace PvSystemPlugin.Migrations
{
    [DbContext(typeof(RepositoryPvContext))]
    [Migration("20220905014924_Initial-Pv")]
    partial class InitialPv
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.PvComments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BatterCellId")
                        .HasColumnType("int");

                    b.Property<int?>("BatteryBlockId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PvStorageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BatterCellId");

                    b.HasIndex("BatteryBlockId");

                    b.HasIndex("PvStorageId");

                    b.ToTable("Pv_PvComments");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("PvStorageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PvStorageId");

                    b.ToTable("Pv_Storage_BatteryBlock");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryCell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BatteryBlockId")
                        .HasColumnType("int");

                    b.Property<int>("CellSpecificationId")
                        .HasColumnType("int");

                    b.Property<int>("CellTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<double>("InternalResistance")
                        .HasColumnType("double");

                    b.Property<int>("ProductionAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("TraceabillityCode")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.Property<double>("VoltageInputMeasurement")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("BatteryBlockId");

                    b.HasIndex("CellSpecificationId");

                    b.HasIndex("ProductionAddressId");

                    b.HasIndex("ProductionTypeId");

                    b.HasIndex("VendorId");

                    b.ToTable("Pv_Storage_BatteryCell");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.CellSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pv_Storage_CellSpecification");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "76",
                            ConcurrencyStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "LF280K",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.CellType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pv_Storage_CellType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "B",
                            ConcurrencyStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "LifePo4",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.ProductionAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pv_Storage_ProductionAddress");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "J",
                            ConcurrencyStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jingmen",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Code = "H",
                            ConcurrencyStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Huizhou",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.ProductionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pv_Storage_ProductionType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "C",
                            ConcurrencyStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cell",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.PvStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("BatteryVoltage")
                        .HasColumnType("double");

                    b.Property<double>("Capacity")
                        .HasColumnType("double");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<double>("UsableCapacity")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Pv_Storage_PvStorage");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pv_Storage_Vendor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "04Q",
                            ConcurrencyStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "EVE",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.PvComments", b =>
                {
                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryCell", "BatteryCell")
                        .WithMany("PvComments")
                        .HasForeignKey("BatterCellId");

                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryBlock", "BatteryBlock")
                        .WithMany("PvComments")
                        .HasForeignKey("BatteryBlockId");

                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.PvStorage", "PvStorage")
                        .WithMany("PvComments")
                        .HasForeignKey("PvStorageId");

                    b.Navigation("BatteryBlock");

                    b.Navigation("BatteryCell");

                    b.Navigation("PvStorage");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryBlock", b =>
                {
                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.PvStorage", "PvStorage")
                        .WithMany("BatteryBlocks")
                        .HasForeignKey("PvStorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PvStorage");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryCell", b =>
                {
                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryBlock", "BatteryBlock")
                        .WithMany("BatteryCells")
                        .HasForeignKey("BatteryBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.CellSpecification", "CellSpecification")
                        .WithMany("BatteryCells")
                        .HasForeignKey("CellSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.ProductionAddress", "ProductionAddress")
                        .WithMany("BatteryCells")
                        .HasForeignKey("ProductionAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.ProductionType", "ProductionType")
                        .WithMany("BatteryCells")
                        .HasForeignKey("ProductionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.CellType", "CellType")
                        .WithMany("BatteryCells")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PvSystemPlugin.Entities.Models.Pv.Storage.Vendor", "Vendor")
                        .WithMany("BatteryCells")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BatteryBlock");

                    b.Navigation("CellSpecification");

                    b.Navigation("CellType");

                    b.Navigation("ProductionAddress");

                    b.Navigation("ProductionType");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryBlock", b =>
                {
                    b.Navigation("BatteryCells");

                    b.Navigation("PvComments");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.BatteryCell", b =>
                {
                    b.Navigation("PvComments");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.CellSpecification", b =>
                {
                    b.Navigation("BatteryCells");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.CellType", b =>
                {
                    b.Navigation("BatteryCells");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.ProductionAddress", b =>
                {
                    b.Navigation("BatteryCells");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.ProductionType", b =>
                {
                    b.Navigation("BatteryCells");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.PvStorage", b =>
                {
                    b.Navigation("BatteryBlocks");

                    b.Navigation("PvComments");
                });

            modelBuilder.Entity("PvSystemPlugin.Entities.Models.Pv.Storage.Vendor", b =>
                {
                    b.Navigation("BatteryCells");
                });
#pragma warning restore 612, 618
        }
    }
}
