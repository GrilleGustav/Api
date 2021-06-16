using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class ChangeEmailTemplateTypeLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74248b1e-5cea-43dd-a37d-5f7a32bad36c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abaecc0c-3463-4809-b402-a2ade833c669");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageCode",
                table: "EmailTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0615a54-e885-46a9-9215-ea78faec2084",
                column: "ConcurrencyStamp",
                value: "2a14a41f-2a5c-4d0b-9434-a76e6faac428");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "988db999-a7dc-4206-8bd4-1be6ac00f0f1", "9232626d-d6c5-486c-b87e-d8f8da22cf54", "User", "USER" },
                    { "a52a8d1b-8426-4444-bed3-28c7a6aaa34d", "b0895b0f-491c-4d2e-8c39-074819113893", "Developper", "DEVELOPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "493adb36-1365-4cd5-9ecf-93e0078e152b",
                columns: new[] { "ConcurrencyStamp", "Language", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab3f1ea7-b7d0-4242-a797-8b53a0814850", 0, "AQAAAAEAACcQAAAAEN5CudG72fwZR99sk0e5o/3cOYQ2Ez/TBoBklzuLjxP93Ij17AYRJq2H32CQM48SMg==", "ddc51584-147d-40ab-a195-6cb937a8a09f" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "LanguageCode",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "988db999-a7dc-4206-8bd4-1be6ac00f0f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a52a8d1b-8426-4444-bed3-28c7a6aaa34d");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                table: "EmailTemplates",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0615a54-e885-46a9-9215-ea78faec2084",
                column: "ConcurrencyStamp",
                value: "38db4eca-9451-4876-8b71-4690c9f8594d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abaecc0c-3463-4809-b402-a2ade833c669", "28d05d61-88ca-45c0-a7d2-551d9690927c", "User", "USER" },
                    { "74248b1e-5cea-43dd-a37d-5f7a32bad36c", "167782ca-97b9-49b6-a983-e390908548b7", "Developper", "DEVELOPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "493adb36-1365-4cd5-9ecf-93e0078e152b",
                columns: new[] { "ConcurrencyStamp", "Language", "PasswordHash", "SecurityStamp" },
                values: new object[] { "baec5ac6-2122-47d2-9218-f06bf2e84e7f", 1, "AQAAAAEAACcQAAAAEKrUUulWDjG+c/Z6xlZAEUyH3MHYubzr48j/heGW4fHMsBazj9j3t+5mllqSmimPJA==", "5bcee591-c8da-49eb-ace7-bd35c75d9b0b" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "LanguageCode",
                value: "de");
        }
    }
}
