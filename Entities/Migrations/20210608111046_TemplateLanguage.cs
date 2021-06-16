using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class TemplateLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb70271f-d5a4-441d-b59e-bdd5cf4e0ef2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfecd490-b98d-4edc-96be-35db1d7856d4");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "EmailTemplates",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0615a54-e885-46a9-9215-ea78faec2084",
                column: "ConcurrencyStamp",
                value: "35853c44-4f4e-4770-a770-dbee828d3859");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0004aebe-4274-4e3b-a90c-8c5c062f7be8", "5a637b64-3c8f-4470-b741-15b4fecaab2c", "User", "USER" },
                    { "83290d38-af8f-409f-9d8c-782f2674e141", "286cd765-a327-45a9-81bd-1db954d58711", "Developper", "DEVELOPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "493adb36-1365-4cd5-9ecf-93e0078e152b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ff16e52-3ed0-467e-aa3b-f95bc15aef2c", "AQAAAAEAACcQAAAAENPVpxRqu8ZbSq4CVf80avbSNUC5mGl2qE4rvz0ga2M0dqM6msQ7ISTJA3ogIn0BKQ==", "db77492f-ae24-46ee-878b-600d7beafbc0" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Default", "LanguageCode" },
                values: new object[] { true, "de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0004aebe-4274-4e3b-a90c-8c5c062f7be8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83290d38-af8f-409f-9d8c-782f2674e141");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "EmailTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0615a54-e885-46a9-9215-ea78faec2084",
                column: "ConcurrencyStamp",
                value: "35733f8b-d62d-4a17-99cf-f97273caff27");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cb70271f-d5a4-441d-b59e-bdd5cf4e0ef2", "5a16f7c0-8d4c-48f7-8836-d2bbb8256e64", "User", "USER" },
                    { "cfecd490-b98d-4edc-96be-35db1d7856d4", "b93d8a4c-2c52-4c24-9836-2e195d5b7c9d", "Developper", "DEVELOPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "493adb36-1365-4cd5-9ecf-93e0078e152b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d0502a3-c142-452e-9685-029d87bbbcee", "AQAAAAEAACcQAAAAEGCtYByGL7fmy/K1R9JD2kx7O4dgZRGr5ERc7EgEOKFvZVxXSaT32rvl8pLYjJ2Giw==", "8fe4fd33-cbd8-43fc-916d-d3d5851ea90b" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: false);
        }
    }
}
