using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class OneToManyTemplates_TemplateTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemplateTypeId",
                table: "EmailTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "928deff2-1537-4d69-b7a4-6db4f9844787");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "687beb9f-0d82-4e6a-8db6-1d8f25618924");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "763fa2d6-9a71-4c9f-9577-b49e23860094");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d77f3910-e51b-4c18-8f5a-a9c22455a391", "AQAAAAEAACcQAAAAELwW1+Hbl3NWCZD5vCokbvZ4ZP9+hOiqK90wozlznFGMYDevOke8s9qhaI9xYitRfA==" });

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_TemplateTypeId",
                table: "EmailTemplates",
                column: "TemplateTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplates_TemplateType_TemplateTypeId",
                table: "EmailTemplates",
                column: "TemplateTypeId",
                principalTable: "TemplateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplates_TemplateType_TemplateTypeId",
                table: "EmailTemplates");

            migrationBuilder.DropIndex(
                name: "IX_EmailTemplates_TemplateTypeId",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "TemplateTypeId",
                table: "EmailTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "7bb75231-df0c-482b-aad1-c8bfc9a12e84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "b4f6a4a1-6531-485b-be70-988cb498d18c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "118bb77d-b81a-472f-af45-47a14d163554");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "46c76fec-a982-4d54-ac19-0a08b44ca055", "AQAAAAEAACcQAAAAEFzT87PZV4QSeYc93DOgJAtyIOBab0PADPhchT7fAx4jLB2CwUNsidkJsECtX7HGCw==" });
        }
    }
}
