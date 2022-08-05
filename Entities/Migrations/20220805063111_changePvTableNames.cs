using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class changePvTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatteryBlocks_PvStorages_PvStorageId",
                table: "BatteryBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCells_BatteryBlocks_BatteryBlockId",
                table: "BatteryCells");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCells_CellSpecifications_CellSpecificationId",
                table: "BatteryCells");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCells_CellTypes_VendorId",
                table: "BatteryCells");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCells_ProductionAddresses_ProductionAddressId",
                table: "BatteryCells");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCells_ProductionTypes_ProductionTypeId",
                table: "BatteryCells");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCells_Vendor_VendorId",
                table: "BatteryCells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PvStorages",
                table: "PvStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionTypes",
                table: "ProductionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionAddresses",
                table: "ProductionAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CellTypes",
                table: "CellTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CellSpecifications",
                table: "CellSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatteryCells",
                table: "BatteryCells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatteryBlocks",
                table: "BatteryBlocks");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Pv_Storage_Vendor");

            migrationBuilder.RenameTable(
                name: "PvStorages",
                newName: "Pv_Storage_PvStorage");

            migrationBuilder.RenameTable(
                name: "ProductionTypes",
                newName: "Pv_Storage_ProductionType");

            migrationBuilder.RenameTable(
                name: "ProductionAddresses",
                newName: "Pv_Storage_ProductionAddress");

            migrationBuilder.RenameTable(
                name: "CellTypes",
                newName: "Pv_Storage_CellType");

            migrationBuilder.RenameTable(
                name: "CellSpecifications",
                newName: "Pv_Storage_CellSpecification");

            migrationBuilder.RenameTable(
                name: "BatteryCells",
                newName: "Pv_Storage_BatteryCell");

            migrationBuilder.RenameTable(
                name: "BatteryBlocks",
                newName: "Pv_Storage_BatteryBlock");

            migrationBuilder.RenameIndex(
                name: "IX_Vendor_Name",
                table: "Pv_Storage_Vendor",
                newName: "IX_Pv_Storage_Vendor_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Vendor_Code",
                table: "Pv_Storage_Vendor",
                newName: "IX_Pv_Storage_Vendor_Code");

            migrationBuilder.RenameIndex(
                name: "IX_BatteryCells_VendorId",
                table: "Pv_Storage_BatteryCell",
                newName: "IX_Pv_Storage_BatteryCell_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_BatteryCells_ProductionTypeId",
                table: "Pv_Storage_BatteryCell",
                newName: "IX_Pv_Storage_BatteryCell_ProductionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BatteryCells_ProductionAddressId",
                table: "Pv_Storage_BatteryCell",
                newName: "IX_Pv_Storage_BatteryCell_ProductionAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_BatteryCells_CellSpecificationId",
                table: "Pv_Storage_BatteryCell",
                newName: "IX_Pv_Storage_BatteryCell_CellSpecificationId");

            migrationBuilder.RenameIndex(
                name: "IX_BatteryCells_BatteryBlockId",
                table: "Pv_Storage_BatteryCell",
                newName: "IX_Pv_Storage_BatteryCell_BatteryBlockId");

            migrationBuilder.RenameIndex(
                name: "IX_BatteryBlocks_PvStorageId",
                table: "Pv_Storage_BatteryBlock",
                newName: "IX_Pv_Storage_BatteryBlock_PvStorageId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pv_Storage_ProductionType",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pv_Storage_ProductionAddress",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Pv_Storage_ProductionAddress",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pv_Storage_CellType",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pv_Storage_CellSpecification",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Pv_Storage_CellSpecification",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_Vendor",
                table: "Pv_Storage_Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_PvStorage",
                table: "Pv_Storage_PvStorage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_ProductionType",
                table: "Pv_Storage_ProductionType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_ProductionAddress",
                table: "Pv_Storage_ProductionAddress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_CellType",
                table: "Pv_Storage_CellType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_CellSpecification",
                table: "Pv_Storage_CellSpecification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_BatteryCell",
                table: "Pv_Storage_BatteryCell",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pv_Storage_BatteryBlock",
                table: "Pv_Storage_BatteryBlock",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "cdfcfaca-b1bf-4e34-b5b8-95e31eb4fc05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "1a7772dd-5c70-4d99-9678-d2aa019b63ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "7d60029d-6750-4adc-a606-8533fe7b70ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKJVDsCYodfoeb0gbFLOmKIieKk0jYWPfLYhEEttj1e903P3BEFOt3LG3D2ks9GHhA==");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_ProductionType_Code",
                table: "Pv_Storage_ProductionType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_ProductionType_Name",
                table: "Pv_Storage_ProductionType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_ProductionAddress_Code",
                table: "Pv_Storage_ProductionAddress",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_ProductionAddress_Name",
                table: "Pv_Storage_ProductionAddress",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_CellType_Code",
                table: "Pv_Storage_CellType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_CellType_Name",
                table: "Pv_Storage_CellType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_CellSpecification_Code",
                table: "Pv_Storage_CellSpecification",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_CellSpecification_Name",
                table: "Pv_Storage_CellSpecification",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_Storage_BatteryBlock_Pv_Storage_PvStorage_PvStorageId",
                table: "Pv_Storage_BatteryBlock",
                column: "PvStorageId",
                principalTable: "Pv_Storage_PvStorage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_BatteryBlock_BatteryBlockId",
                table: "Pv_Storage_BatteryCell",
                column: "BatteryBlockId",
                principalTable: "Pv_Storage_BatteryBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_CellSpecification_CellSpec~",
                table: "Pv_Storage_BatteryCell",
                column: "CellSpecificationId",
                principalTable: "Pv_Storage_CellSpecification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_CellType_VendorId",
                table: "Pv_Storage_BatteryCell",
                column: "VendorId",
                principalTable: "Pv_Storage_CellType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_ProductionAddress_Producti~",
                table: "Pv_Storage_BatteryCell",
                column: "ProductionAddressId",
                principalTable: "Pv_Storage_ProductionAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_ProductionType_ProductionT~",
                table: "Pv_Storage_BatteryCell",
                column: "ProductionTypeId",
                principalTable: "Pv_Storage_ProductionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_Vendor_VendorId",
                table: "Pv_Storage_BatteryCell",
                column: "VendorId",
                principalTable: "Pv_Storage_Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pv_Storage_BatteryBlock_Pv_Storage_PvStorage_PvStorageId",
                table: "Pv_Storage_BatteryBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_BatteryBlock_BatteryBlockId",
                table: "Pv_Storage_BatteryCell");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_CellSpecification_CellSpec~",
                table: "Pv_Storage_BatteryCell");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_CellType_VendorId",
                table: "Pv_Storage_BatteryCell");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_ProductionAddress_Producti~",
                table: "Pv_Storage_BatteryCell");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_ProductionType_ProductionT~",
                table: "Pv_Storage_BatteryCell");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_Storage_BatteryCell_Pv_Storage_Vendor_VendorId",
                table: "Pv_Storage_BatteryCell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_Vendor",
                table: "Pv_Storage_Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_PvStorage",
                table: "Pv_Storage_PvStorage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_ProductionType",
                table: "Pv_Storage_ProductionType");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_ProductionType_Code",
                table: "Pv_Storage_ProductionType");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_ProductionType_Name",
                table: "Pv_Storage_ProductionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_ProductionAddress",
                table: "Pv_Storage_ProductionAddress");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_ProductionAddress_Code",
                table: "Pv_Storage_ProductionAddress");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_ProductionAddress_Name",
                table: "Pv_Storage_ProductionAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_CellType",
                table: "Pv_Storage_CellType");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_CellType_Code",
                table: "Pv_Storage_CellType");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_CellType_Name",
                table: "Pv_Storage_CellType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_CellSpecification",
                table: "Pv_Storage_CellSpecification");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_CellSpecification_Code",
                table: "Pv_Storage_CellSpecification");

            migrationBuilder.DropIndex(
                name: "IX_Pv_Storage_CellSpecification_Name",
                table: "Pv_Storage_CellSpecification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_BatteryCell",
                table: "Pv_Storage_BatteryCell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pv_Storage_BatteryBlock",
                table: "Pv_Storage_BatteryBlock");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_Vendor",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_PvStorage",
                newName: "PvStorages");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_ProductionType",
                newName: "ProductionTypes");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_ProductionAddress",
                newName: "ProductionAddresses");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_CellType",
                newName: "CellTypes");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_CellSpecification",
                newName: "CellSpecifications");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_BatteryCell",
                newName: "BatteryCells");

            migrationBuilder.RenameTable(
                name: "Pv_Storage_BatteryBlock",
                newName: "BatteryBlocks");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_Vendor_Name",
                table: "Vendor",
                newName: "IX_Vendor_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_Vendor_Code",
                table: "Vendor",
                newName: "IX_Vendor_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_BatteryCell_VendorId",
                table: "BatteryCells",
                newName: "IX_BatteryCells_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_BatteryCell_ProductionTypeId",
                table: "BatteryCells",
                newName: "IX_BatteryCells_ProductionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_BatteryCell_ProductionAddressId",
                table: "BatteryCells",
                newName: "IX_BatteryCells_ProductionAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_BatteryCell_CellSpecificationId",
                table: "BatteryCells",
                newName: "IX_BatteryCells_CellSpecificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_BatteryCell_BatteryBlockId",
                table: "BatteryCells",
                newName: "IX_BatteryCells_BatteryBlockId");

            migrationBuilder.RenameIndex(
                name: "IX_Pv_Storage_BatteryBlock_PvStorageId",
                table: "BatteryBlocks",
                newName: "IX_BatteryBlocks_PvStorageId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductionTypes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductionAddresses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProductionAddresses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CellTypes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CellSpecifications",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CellSpecifications",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PvStorages",
                table: "PvStorages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionTypes",
                table: "ProductionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionAddresses",
                table: "ProductionAddresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CellTypes",
                table: "CellTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CellSpecifications",
                table: "CellSpecifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatteryCells",
                table: "BatteryCells",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatteryBlocks",
                table: "BatteryBlocks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "3e9f021d-7e55-4491-a711-7f78a1d72acc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "15087136-dac7-4a59-b0a1-542a879d028f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "b8be168b-b5dd-471c-823e-4d3d5e306f29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJrgHHH5slcO5fj4kUNomLSniC7AhmRUX1AC4SzVK/GhmMU6GbN1MmQ1o/zfeUlwJQ==");

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryBlocks_PvStorages_PvStorageId",
                table: "BatteryBlocks",
                column: "PvStorageId",
                principalTable: "PvStorages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCells_BatteryBlocks_BatteryBlockId",
                table: "BatteryCells",
                column: "BatteryBlockId",
                principalTable: "BatteryBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCells_CellSpecifications_CellSpecificationId",
                table: "BatteryCells",
                column: "CellSpecificationId",
                principalTable: "CellSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCells_CellTypes_VendorId",
                table: "BatteryCells",
                column: "VendorId",
                principalTable: "CellTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCells_ProductionAddresses_ProductionAddressId",
                table: "BatteryCells",
                column: "ProductionAddressId",
                principalTable: "ProductionAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCells_ProductionTypes_ProductionTypeId",
                table: "BatteryCells",
                column: "ProductionTypeId",
                principalTable: "ProductionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCells_Vendor_VendorId",
                table: "BatteryCells",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
