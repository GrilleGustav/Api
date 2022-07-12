using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class OneToManyTemplates_TemplateTypes_foreignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "d6e5f514-f517-48a0-a2c0-b5118e744f48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "f6185295-11c9-4b36-aabf-dc3ab0e37a54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "bb7db471-2859-4525-b531-b59881d2fa3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2338a451-243e-4c30-936c-2cfc3fe1484d", "AQAAAAEAACcQAAAAEL2dAk43MEGH17brTCCpM76VODH7rtd19PnfZoW3fr+UoV4UdAmlstuWp97fX3k1Ww==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
