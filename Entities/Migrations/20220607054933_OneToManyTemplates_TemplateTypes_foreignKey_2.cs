using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class OneToManyTemplates_TemplateTypes_foreignKey_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailTemplateType",
                table: "EmailTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "f0c5e459-7589-4ee2-ab86-ffa7d902f316");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "2ea497dd-c46a-4ae2-a92a-1efa597f1292");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "10bd9b36-ea11-45df-9aa4-8a4c9fbee338");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ab4d7a0-7d20-4cc7-a7d6-d66fb4d7b45b", "AQAAAAEAACcQAAAAEPvdm7g/1Z5EmDDtyS1CzV/bkxl+fPKCJenhAIOe8Mbw3ZYI/vs3QJEChhX0iz0UQg==" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "TemplateTypeId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailTemplateType",
                table: "EmailTemplates",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "d6e5f514-f517-48a0-a2c0-b5118e744f48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "f6185295-11c9-4b36-aabf-dc3ab0e37a54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "bb7db471-2859-4525-b531-b59881d2fa3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2338a451-243e-4c30-936c-2cfc3fe1484d", "AQAAAAEAACcQAAAAEL2dAk43MEGH17brTCCpM76VODH7rtd19PnfZoW3fr+UoV4UdAmlstuWp97fX3k1Ww==" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailTemplateType", "TemplateTypeId" },
                values: new object[] { "register", null });
        }
    }
}
