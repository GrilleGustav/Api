using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class PredefinedTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "52c34345-afb3-4de4-bbc4-d0ac055c4237");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "fdb06c88-e1ec-4274-a5bd-9bad8258091e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "edf3222e-3780-4f27-ba34-c7ec31ef2150");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGreIX8a4E6lBEnEx9TM4W7BzG8UfEeYPW3IWopRya2WyrsqzOtRcQ1K8T/LhhsCEA==");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "register 1");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Description", "Language", "Name", "TemplateTypeId" },
                values: new object[] { "<p>Bitte klicken sie auf den unten stehenden Link, um ihre Registrierung zu bestätigen.<br><span class='placeholder'>{RegisterConfirm}</span>&nbsp;</p>", "Predefined template. Is used for the first installation if the administrator does not create one. It is for email confirmation.", 0, "register 2", 1 });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Content", "Default", "Description", "EmailSenderId", "Language", "Name", "Predefined", "TemplateTypeId" },
                values: new object[,]
                {
                    { 3, "<p>Please click on the link below to reset your password.</p><p><span class='placeholder'>{PasswortReset}</span></p>", true, "Predefined template. Is used for the first installation if the administrator does not create one. It is for password reset.", 1, 1, "password reset 1", true, 2 },
                    { 4, "<p>Bitte klicken sie auf den unten stehenden Link, um ihr Passwort zurück zu setzen.</p><p><span class='placeholder'>{PasswortReset}</span></p>", true, "Predefined template. Is used for the first installation if the administrator does not create one. It is for password reset.", 1, 0, "password reset 1", true, 2 },
                    { 5, "<p>Click on the link below to change your email:</p><p><span class='placeholder'>{ChangeEmialLink}</span></p>", true, "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for changing email.", 1, 1, "changeEmail 1", true, 3 },
                    { 6, "<p>Bitte klicken sie auf den unten stehenden Link, um ihre E-Mail Adresse zu ändern.</p><p><span class='placeholder'>{ChangeEmialLink}</span></p>", true, "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for changing email.", 1, 0, "changeEmail 2", true, 3 }
                });

            migrationBuilder.InsertData(
                table: "TemplateType",
                columns: new[] { "Id", "Name", "PluginName" },
                values: new object[] { 4, "TwoStep", "BaseApplication" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Content", "Default", "Description", "EmailSenderId", "Language", "Name", "Predefined", "TemplateTypeId" },
                values: new object[] { 7, "<p>Two factor code:&nbsp;<span class='placeholder'>{TowStepCode}</span></p>", true, "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for sending TwoStep code for login.", 1, 1, "twoStep 1", true, 4 });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Content", "Default", "Description", "EmailSenderId", "Language", "Name", "Predefined", "TemplateTypeId" },
                values: new object[] { 8, "<p>Zwei Stufen Code:<span class='placeholder'>{TowStepCode}</span></p>", true, "Predefined template. Is used for the first installation if the administrator does not create one. Tamplate for sending TwoStep code for login.", 1, 0, "twoStep 2", true, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TemplateType",
                keyColumn: "Id",
                keyValue: 4);

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
                column: "Name",
                value: "Register 1");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Description", "Language", "Name", "TemplateTypeId" },
                values: new object[] { "<p>Click on the link below to change your email:</p><p><span class='placeholder'>{ChangeEmialLink}</span></p>", "Taplate for changing email.", 1, "changeEmail", 3 });
        }
    }
}
