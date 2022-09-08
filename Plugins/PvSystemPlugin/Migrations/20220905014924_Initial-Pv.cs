using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PvSystemPlugin.Migrations
{
    public partial class InitialPv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_CellSpecification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pv_Storage_CellSpecification", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_CellType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pv_Storage_CellType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_ProductionAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pv_Storage_ProductionAddress", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_ProductionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pv_Storage_ProductionType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_PvStorage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsableCapacity = table.Column<double>(type: "double", nullable: false),
                    Capacity = table.Column<double>(type: "double", nullable: false),
                    BatteryVoltage = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pv_Storage_PvStorage", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pv_Storage_Vendor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_BatteryBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    table.PrimaryKey("PK_Pv_Storage_BatteryBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pv_Storage_BatteryBlock_Pv_Storage_PvStorage_PvStorageId",
                        column: x => x.PvStorageId,
                        principalTable: "Pv_Storage_PvStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_Storage_BatteryCell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VoltageInputMeasurement = table.Column<double>(type: "double", nullable: false),
                    InternalResistance = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TraceabillityCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerialNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    table.PrimaryKey("PK_Pv_Storage_BatteryCell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pv_Storage_BatteryCell_Pv_Storage_BatteryBlock_BatteryBlockId",
                        column: x => x.BatteryBlockId,
                        principalTable: "Pv_Storage_BatteryBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pv_Storage_BatteryCell_Pv_Storage_CellSpecification_CellSpec~",
                        column: x => x.CellSpecificationId,
                        principalTable: "Pv_Storage_CellSpecification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pv_Storage_BatteryCell_Pv_Storage_CellType_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Pv_Storage_CellType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pv_Storage_BatteryCell_Pv_Storage_ProductionAddress_Producti~",
                        column: x => x.ProductionAddressId,
                        principalTable: "Pv_Storage_ProductionAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pv_Storage_BatteryCell_Pv_Storage_ProductionType_ProductionT~",
                        column: x => x.ProductionTypeId,
                        principalTable: "Pv_Storage_ProductionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pv_Storage_BatteryCell_Pv_Storage_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Pv_Storage_Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pv_PvComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PvStorageId = table.Column<int>(type: "int", nullable: true),
                    BatteryBlockId = table.Column<int>(type: "int", nullable: true),
                    BatterCellId = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pv_PvComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pv_PvComments_Pv_Storage_BatteryBlock_BatteryBlockId",
                        column: x => x.BatteryBlockId,
                        principalTable: "Pv_Storage_BatteryBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pv_PvComments_Pv_Storage_BatteryCell_BatterCellId",
                        column: x => x.BatterCellId,
                        principalTable: "Pv_Storage_BatteryCell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pv_PvComments_Pv_Storage_PvStorage_PvStorageId",
                        column: x => x.PvStorageId,
                        principalTable: "Pv_Storage_PvStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Pv_Storage_CellSpecification",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "76", null, "LF280K" });

            migrationBuilder.InsertData(
                table: "Pv_Storage_CellType",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "B", null, "LifePo4" });

            migrationBuilder.InsertData(
                table: "Pv_Storage_ProductionAddress",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "J", null, "Jingmen" },
                    { 2, "H", null, "Huizhou" }
                });

            migrationBuilder.InsertData(
                table: "Pv_Storage_ProductionType",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "C", null, "Cell" });

            migrationBuilder.InsertData(
                table: "Pv_Storage_Vendor",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { 1, "04Q", null, "EVE" });

            migrationBuilder.CreateIndex(
                name: "IX_Pv_PvComments_BatterCellId",
                table: "Pv_PvComments",
                column: "BatterCellId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_PvComments_BatteryBlockId",
                table: "Pv_PvComments",
                column: "BatteryBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_PvComments_PvStorageId",
                table: "Pv_PvComments",
                column: "PvStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_BatteryBlock_PvStorageId",
                table: "Pv_Storage_BatteryBlock",
                column: "PvStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_BatteryCell_BatteryBlockId",
                table: "Pv_Storage_BatteryCell",
                column: "BatteryBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_BatteryCell_CellSpecificationId",
                table: "Pv_Storage_BatteryCell",
                column: "CellSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_BatteryCell_ProductionAddressId",
                table: "Pv_Storage_BatteryCell",
                column: "ProductionAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_BatteryCell_ProductionTypeId",
                table: "Pv_Storage_BatteryCell",
                column: "ProductionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_BatteryCell_VendorId",
                table: "Pv_Storage_BatteryCell",
                column: "VendorId");

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
                name: "IX_Pv_Storage_Vendor_Code",
                table: "Pv_Storage_Vendor",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pv_Storage_Vendor_Name",
                table: "Pv_Storage_Vendor",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pv_PvComments");

            migrationBuilder.DropTable(
                name: "Pv_Storage_BatteryCell");

            migrationBuilder.DropTable(
                name: "Pv_Storage_BatteryBlock");

            migrationBuilder.DropTable(
                name: "Pv_Storage_CellSpecification");

            migrationBuilder.DropTable(
                name: "Pv_Storage_CellType");

            migrationBuilder.DropTable(
                name: "Pv_Storage_ProductionAddress");

            migrationBuilder.DropTable(
                name: "Pv_Storage_ProductionType");

            migrationBuilder.DropTable(
                name: "Pv_Storage_Vendor");

            migrationBuilder.DropTable(
                name: "Pv_Storage_PvStorage");
        }
    }
}
