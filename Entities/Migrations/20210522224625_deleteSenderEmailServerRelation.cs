using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class deleteSenderEmailServerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailSenders_EmailServers_EmailServerId",
                table: "EmailSenders");

            migrationBuilder.DropIndex(
                name: "IX_EmailSenders_EmailServerId",
                table: "EmailSenders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "359a85da-4401-4926-b0b7-217a5055ffd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4310debc-4fac-4ee6-aa32-2163c0d59c45");

            migrationBuilder.DropColumn(
                name: "EmailServerId",
                table: "EmailSenders");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1684de3e-3ff6-47fd-9f0c-a6b8658b4354");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ee44866-65bd-469f-a63d-97f3632c88a8");

            migrationBuilder.AddColumn<int>(
                name: "EmailServerId",
                table: "EmailSenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0615a54-e885-46a9-9215-ea78faec2084",
                column: "ConcurrencyStamp",
                value: "8b66ee00-2090-405e-bef6-736232902c7b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4310debc-4fac-4ee6-aa32-2163c0d59c45", "9019c398-de17-4ea1-9395-4d853cc2693e", "User", "USER" },
                    { "359a85da-4401-4926-b0b7-217a5055ffd7", "10bc7a56-6da5-4f41-9ba2-62d91526d091", "Developper", "DEVELOPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "493adb36-1365-4cd5-9ecf-93e0078e152b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efd366ea-d7fb-425c-ae77-00f09a36eeb7", "AQAAAAEAACcQAAAAEKjuj5YpqcUWSAkHD5T3duCVit4mnBzBxq21bf3KJldNm4AFxTJnLoj0fOZS4NWqcQ==", "2547d0a3-cba6-427f-b9f0-4cef4ce25577" });

            migrationBuilder.UpdateData(
                table: "EmailSenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmailServerId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_EmailSenders_EmailServerId",
                table: "EmailSenders",
                column: "EmailServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailSenders_EmailServers_EmailServerId",
                table: "EmailSenders",
                column: "EmailServerId",
                principalTable: "EmailServers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
