using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class administratorRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "2ad92974-cb62-4392-8162-e23476b1ad9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "9fb0d918-f84c-4df7-b0b9-d338cd2a2599");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "74abe3bc-6e0e-4576-b6cd-9f85abfafd5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b403966-2a2b-4235-b052-35bbebaa66a2", "AQAAAAEAACcQAAAAEI+8PFdMYYovrUWij69G/tNfzloM1mt6LL2GQl5WZ6CbWVjswCECAiZGO6SMjpdg/Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "d8cff3b2-8af7-4a4a-a03b-6f3e9db89ec3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "4d368bfe-4b93-4c47-b022-9d9b48533ec5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "0fe6a368-795b-4b17-9fbf-3eb2cedcc369");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81a68ef0-354c-4422-a7c3-eba0b9ebeafe", "AQAAAAEAACcQAAAAENIDGw8GjD07uUVN3z1fPyuh2ZDyd1Ib5Vkk7SyJghVmIw3e6hWVsucfe4XYHMSTAw==" });
        }
    }
}
