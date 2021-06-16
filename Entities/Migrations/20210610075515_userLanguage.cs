using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class userLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0004aebe-4274-4e3b-a90c-8c5c062f7be8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83290d38-af8f-409f-9d8c-782f2674e141");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "ConcurrencyStamp", "Firstname", "Language", "Lastname", "PasswordHash", "SecurityStamp" },
                values: new object[] { "baec5ac6-2122-47d2-9218-f06bf2e84e7f", "Sam", 1, "Sampleman", "AQAAAAEAACcQAAAAEKrUUulWDjG+c/Z6xlZAEUyH3MHYubzr48j/heGW4fHMsBazj9j3t+5mllqSmimPJA==", "5bcee591-c8da-49eb-ace7-bd35c75d9b0b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74248b1e-5cea-43dd-a37d-5f7a32bad36c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abaecc0c-3463-4809-b402-a2ade833c669");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "Firstname", "Lastname", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ff16e52-3ed0-467e-aa3b-f95bc15aef2c", null, null, "AQAAAAEAACcQAAAAENPVpxRqu8ZbSq4CVf80avbSNUC5mGl2qE4rvz0ga2M0dqM6msQ7ISTJA3ogIn0BKQ==", "db77492f-ae24-46ee-878b-600d7beafbc0" });
        }
    }
}
