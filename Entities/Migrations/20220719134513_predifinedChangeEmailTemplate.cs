using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class predifinedChangeEmailTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "5b544b99-3572-4c78-a1e6-21fd038ab2ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "9c544b76-87f1-4351-9da8-6aea8da1589a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "e3a6c63d-65e4-4568-a70b-5480970b9311");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFIhf5+Q/b3rd+InILwOdXEgBZDuxHAo/OoSkOJGRBxYdrCqhWb8shdz/7ZPJYRrAw==");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.InsertData(
                table: "TemplateType",
                columns: new[] { "Id", "Name", "PluginName" },
                values: new object[] { 3, "ChangeEmail", "BaseApplication" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Content", "Default", "Description", "EmailSenderId", "Language", "Name", "Predefined", "TemplateTypeId" },
                values: new object[] { 2, "<p>Click on the link below to change your email:</p><p><span class='placeholder'>{ChangeEmialLink}</span></p>", true, "Taplate for changing email.", 1, 1, "changeEmail", true, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TemplateType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "449b4304-f28a-4a88-b1dc-7b02e54d487d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "0c8cf9f8-075a-44b4-9b37-29bb8aaaca78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "e425cca5-ebbf-4a19-bd3a-c1773e03c9f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDi1LXW4Ayt/KH4sQqfEPtm4nZ3cJHKSq69RsEN9eLSGeR/07oBnH0JBl8cqVeKx8w==");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);
        }
    }
}
