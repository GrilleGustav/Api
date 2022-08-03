using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class pvStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CellSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Code = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellSpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CellTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Code = table.Column<string>(type: "varchar(1) CHARACTER SET utf8mb4", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Code = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Code = table.Column<string>(type: "varchar(1) CHARACTER SET utf8mb4", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PvStorages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UsableCapacity = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PvStorages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Code = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatteryBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PvStorageId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryBlocks_PvStorages_PvStorageId",
                        column: x => x.PvStorageId,
                        principalTable: "PvStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatteryCells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VoltageInputMeasurement = table.Column<double>(type: "double", nullable: false),
                    InternalResistance = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TraceabillityCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SerialNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CellTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductionTypeId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    CellSpecificationId = table.Column<int>(type: "int", nullable: false),
                    BatteryBlockId = table.Column<int>(type: "int", nullable: false),
                    ProductionAddressId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryCells_BatteryBlocks_BatteryBlockId",
                        column: x => x.BatteryBlockId,
                        principalTable: "BatteryBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatteryCells_CellSpecifications_CellSpecificationId",
                        column: x => x.CellSpecificationId,
                        principalTable: "CellSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatteryCells_CellTypes_VendorId",
                        column: x => x.VendorId,
                        principalTable: "CellTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatteryCells_ProductionAddresses_ProductionAddressId",
                        column: x => x.ProductionAddressId,
                        principalTable: "ProductionAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatteryCells_ProductionTypes_ProductionTypeId",
                        column: x => x.ProductionTypeId,
                        principalTable: "ProductionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatteryCells_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "3924d0c6-ecd2-47c7-a2e9-4219ddb41b3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "de6372bc-9d00-4b5b-8d5a-1e6bb4c595d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "d721047c-6eff-459e-8386-fcfb8265b770");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEE5OmroTWKmPdSgAx0c3NULa9FdRluCVzzUPvM+pgIxPShOvn6ZrHYgi+1BeahLjPw==");

            migrationBuilder.InsertData(
                table: "CellSpecifications",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "76", null, "LF280K" });

            migrationBuilder.InsertData(
                table: "CellTypes",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "B", null, "LifePo4" });

            migrationBuilder.InsertData(
                table: "ProductionAddresses",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "J", null, "Jingmen" },
                    { 2, "H", null, "Huizhou" }
                });

            migrationBuilder.InsertData(
                table: "ProductionTypes",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "C", null, "Cell" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "04Q", null, "EVE" });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryBlocks_PvStorageId",
                table: "BatteryBlocks",
                column: "PvStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCells_BatteryBlockId",
                table: "BatteryCells",
                column: "BatteryBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCells_CellSpecificationId",
                table: "BatteryCells",
                column: "CellSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCells_ProductionAddressId",
                table: "BatteryCells",
                column: "ProductionAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCells_ProductionTypeId",
                table: "BatteryCells",
                column: "ProductionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCells_VendorId",
                table: "BatteryCells",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryCells");

            migrationBuilder.DropTable(
                name: "BatteryBlocks");

            migrationBuilder.DropTable(
                name: "CellSpecifications");

            migrationBuilder.DropTable(
                name: "CellTypes");

            migrationBuilder.DropTable(
                name: "ProductionAddresses");

            migrationBuilder.DropTable(
                name: "ProductionTypes");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "PvStorages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "52c34345-afb3-4de4-bbc4-d0ac055c4237");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "fdb06c88-e1ec-4274-a5bd-9bad8258091e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "edf3222e-3780-4f27-ba34-c7ec31ef2150");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGreIX8a4E6lBEnEx9TM4W7BzG8UfEeYPW3IWopRya2WyrsqzOtRcQ1K8T/LhhsCEA==");
        }
    }
}
