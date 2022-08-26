using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class pvComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pv_PvComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PvStorageId = table.Column<int>(type: "int", nullable: false),
                    BatteryBlockId = table.Column<int>(type: "int", nullable: false),
                    BatterCellId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pv_PvComments_Pv_Storage_BatteryCell_BatterCellId",
                        column: x => x.BatterCellId,
                        principalTable: "Pv_Storage_BatteryCell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pv_PvComments_Pv_Storage_PvStorage_PvStorageId",
                        column: x => x.PvStorageId,
                        principalTable: "Pv_Storage_PvStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "9e44f1a3-8eb3-42cf-bce8-527a285b2995");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "06bb4a7f-82a7-4ac9-a0a1-afce8385a527");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "b8e1c3e6-739d-485f-a3b1-cbcad36b6b1e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIWvzgyaR5QH0B46LMzhhLOvQbLqruvc2l1lIqzHn6ZBsZpXFsIN7wXgG9dLQdk1pg==");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pv_PvComments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "47282158-08b9-4b75-926d-c2f27e670e82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "1e409b9e-18eb-457f-9795-a75feab31696");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "c6b899be-baf1-403b-938a-c2e209598d8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGka+jGFGnGi4YhmUmTnAVev0jHqsjDkjD+9S9okQmlA8CvDeZ/iRVB6Usdg5dbA1Q==");
        }
    }
}
