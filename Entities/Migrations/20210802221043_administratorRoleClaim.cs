using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class administratorRoleClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Aminitrator", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 15, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserGroupRemove", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 14, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserGroupUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 13, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserGroupList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 12, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailMessagesList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 11, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateRemove", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 10, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 7, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateCreate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerRemove", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerCreate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "e3f3ebda-7a32-418b-a006-e09bdeffe445");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "0760eef1-7500-48a9-83cd-192785f76b9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "b88e5682-2850-49c1-911d-9da7a39b8f82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "405321ed-6df6-40d9-a25e-3d08d3c08f96", "AQAAAAEAACcQAAAAEOpinMczTy92BhEvmYMZCqjR3cInnlec+8we00zFGdheRucL7yAdpJGEL5GVT8Qz7Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

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
    }
}
