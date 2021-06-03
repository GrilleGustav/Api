using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class defaultEmailServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1684de3e-3ff6-47fd-9f0c-a6b8658b4354");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ee44866-65bd-469f-a63d-97f3632c88a8");

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
                table: "EmailServers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ServerIp", "ServerPassword", "ServerUsername" },
                values: new object[] { "Testbenutzer", "mail.grillegustav.de", "mobuapXikC", "developper@grillegustav.de" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Description", "Name" },
                values: new object[] { "<p>Please click on the link below to confirm your registration.</p><p><span class='placeholder'>{ConfirmLink}</span></p>", "Predefined template. Is used for the first installation if the administrator does not create one.", "Register 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb70271f-d5a4-441d-b59e-bdd5cf4e0ef2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfecd490-b98d-4edc-96be-35db1d7856d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0615a54-e885-46a9-9215-ea78faec2084",
                column: "ConcurrencyStamp",
                value: "7eee849c-0c18-476c-8e94-6c23775af00d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1684de3e-3ff6-47fd-9f0c-a6b8658b4354", "98cdd4be-0d5d-408b-95b5-678be3b9cf50", "User", "USER" },
                    { "1ee44866-65bd-469f-a63d-97f3632c88a8", "c59b2a1a-5f3f-4b18-a774-bcae749192de", "Developper", "DEVELOPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "493adb36-1365-4cd5-9ecf-93e0078e152b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93cfb952-4656-45d8-a40f-c6f192402950", "AQAAAAEAACcQAAAAEFpt3KAX5Y8lZdEaG2w6rT6/RBsM+AIgYni5nIwfgNhKO4D5qaJC3M3ECK9VcDuUZQ==", "575fddbe-5ae3-4f11-897b-e89c65a91b4d" });

            migrationBuilder.UpdateData(
                table: "EmailServers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ServerIp", "ServerPassword", "ServerUsername" },
                values: new object[] { "Testdatensatz", "192.168.21.4", "123", "admin@web.de" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Description", "Name" },
                values: new object[] { "<h1>Developper Email for testing</h1>", "Developper template for testing.", "developper" });
        }
    }
}
