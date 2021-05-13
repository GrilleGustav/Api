using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class newroledevelopper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11e3f7f2-56dc-47c7-b3f4-d6dc5197f821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6891ecc9-666e-4b26-b36c-c2870ba3aa24");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6891ecc9-666e-4b26-b36c-c2870ba3aa24", "8f2997e1-144f-4088-a861-c9c989aefaff", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11e3f7f2-56dc-47c7-b3f4-d6dc5197f821", "964f735c-3ebe-4c25-b107-5cea00025bea", "Administrator", "ADMINISTRATOR" });
        }
    }
}
