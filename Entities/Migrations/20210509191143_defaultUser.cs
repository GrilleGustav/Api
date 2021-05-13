using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class defaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplates_EmailSenders_EmailSenderId",
                table: "EmailTemplates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36944e24-dafb-4f1b-9d1e-53825f499157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4052462c-83b9-4c40-abfc-be993b0060b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f16fe0b-dfb8-4b90-bb22-ce73f77d3665");

            migrationBuilder.AlterColumn<int>(
                name: "EmailSenderId",
                table: "EmailTemplates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4310debc-4fac-4ee6-aa32-2163c0d59c45", "9019c398-de17-4ea1-9395-4d853cc2693e", "User", "USER" },
                    { "a0615a54-e885-46a9-9215-ea78faec2084", "8b66ee00-2090-405e-bef6-736232902c7b", "Administrator", "ADMINISTRATOR" },
                    { "359a85da-4401-4926-b0b7-217a5055ffd7", "10bc7a56-6da5-4f41-9ba2-62d91526d091", "Developper", "DEVELOPPER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "Firstname", "LastAccessedOn", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "493adb36-1365-4cd5-9ecf-93e0078e152b", 0, "efd366ea-d7fb-425c-ae77-00f09a36eeb7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sam@web.de", true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SAM@WEB.DE", "SAM@WEB.DE", "AQAAAAEAACcQAAAAEKjuj5YpqcUWSAkHD5T3duCVit4mnBzBxq21bf3KJldNm4AFxTJnLoj0fOZS4NWqcQ==", null, false, "2547d0a3-cba6-427f-b9f0-4cef4ce25577", false, "sam@web.de" });

            migrationBuilder.InsertData(
                table: "EmailServers",
                columns: new[] { "Id", "Default", "Description", "ServerIp", "ServerPassword", "ServerPort", "ServerUsername" },
                values: new object[] { 1, true, "Testdatensatz", "192.168.21.4", "123", "25", "admin@web.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a0615a54-e885-46a9-9215-ea78faec2084", "493adb36-1365-4cd5-9ecf-93e0078e152b" });

            migrationBuilder.InsertData(
                table: "EmailSenders",
                columns: new[] { "Id", "EmailServerId", "Sender" },
                values: new object[] { 1, 1, "info@web.de" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Content", "Default", "Description", "EmailSenderId", "EmailTemplateType", "Name", "Predefined" },
                values: new object[] { 1, "<h1>Developper Email for testing</h1>", false, "Developper template for testing.", 1, 0, "developper", true });

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplates_EmailSenders_EmailSenderId",
                table: "EmailTemplates",
                column: "EmailSenderId",
                principalTable: "EmailSenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplates_EmailSenders_EmailSenderId",
                table: "EmailTemplates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "359a85da-4401-4926-b0b7-217a5055ffd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4310debc-4fac-4ee6-aa32-2163c0d59c45");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a0615a54-e885-46a9-9215-ea78faec2084", "493adb36-1365-4cd5-9ecf-93e0078e152b" });

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0615a54-e885-46a9-9215-ea78faec2084");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "493adb36-1365-4cd5-9ecf-93e0078e152b");

            migrationBuilder.DeleteData(
                table: "EmailSenders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmailServers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "EmailSenderId",
                table: "EmailTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36944e24-dafb-4f1b-9d1e-53825f499157", "45db4733-4cd6-491d-bc53-b001ddf83854", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f16fe0b-dfb8-4b90-bb22-ce73f77d3665", "aee3205c-d7b9-4ec2-a16c-cba418a2a4ed", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4052462c-83b9-4c40-abfc-be993b0060b0", "641da446-604b-41da-82e3-45bcb2d44186", "Developper", "DEVELOPPER" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplates_EmailSenders_EmailSenderId",
                table: "EmailTemplates",
                column: "EmailSenderId",
                principalTable: "EmailSenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
