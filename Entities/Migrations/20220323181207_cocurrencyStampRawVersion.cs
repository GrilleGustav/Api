using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class cocurrencyStampRawVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "EmailTemplates",
                type: "longtext CHARACTER SET utf8mb4",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "EmailServers",
                type: "longtext CHARACTER SET utf8mb4",
                rowVersion: true,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "eb8a3f68-a536-4a9e-bac5-d1ca1285e9e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "70c933c1-2ff8-4584-9af7-f37275830c17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "ea00ba3b-19a9-4ef3-a62e-599a8f9584bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1aaef0bb-6dbe-4449-8f62-0a0a23c10f06", "AQAAAAEAACcQAAAAEEtUXxK1K473Q3m4jwfrSjZtyK2JdO9oI2yKKD4/VJfFSt/poM4SCjQVJT2j69Lo0A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "EmailServers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "fc72b4ad-f1e0-4954-b89c-dd9b98873d4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "125bb12c-76b7-43c8-92b5-e33a89963127");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "a731a151-e9f4-49ed-8c75-0f6891489c37");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e1c3bf9-16e0-4dfc-9806-1a3ae58b43e0", "AQAAAAEAACcQAAAAEE0qDXElgGGBIvysXkq3le+1u+mHnoju1gEjHy/riPcG24Qt26O5ReyJ9DEQep+AfA==" });
        }
    }
}
