using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    Firstname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Lastname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastAccessedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()"),
                    SendOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Receiver = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    From = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Subject = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsSend = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sender = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailServers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServerIp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ServerPort = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ServerUsername = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ServerPassword = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Default = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailServers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    PluginName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Value = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByIp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RevokedByIp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Default = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    EmailTemplateType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Predefined = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmailSenderId = table.Column<int>(type: "int", nullable: true),
                    ConcurrencyStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_EmailSenders_EmailSenderId",
                        column: x => x.EmailSenderId,
                        principalTable: "EmailSenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a0615a54-e885-46a9-9215-ea78faec1457"), "45ac7bc2-a9dc-4cfa-906e-50074513d94f", "Normal User.", "User", "USER" },
                    { new Guid("a0615a54-e885-46a9-9215-ea78faec2084"), "522bb984-4f46-4bc2-826e-72685adc8cf4", null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("a0615a54-e885-46a9-9215-ea78faec9985"), "94645a5e-b097-460c-b889-5d538ccdf44a", null, "Developper", "DEVELOPPER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Language", "LastAccessedOn", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"), 0, "5f375fbe-4e9b-4488-8766-4e7748ab7127", "sam@web.de", true, "Sam", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sampleman", false, null, "SAM@WEB.DE", "SAM@WEB.DE", "AQAAAAEAACcQAAAAEGEG4gY8csfVGOpWhFKSE1HtKgvU6bOR7Bs03pCUxcsArzoEHUh52wt5i1xuoQN2mA==", null, false, null, false, "sam@web.de" });

            migrationBuilder.InsertData(
                table: "EmailSenders",
                columns: new[] { "Id", "Sender" },
                values: new object[] { 1, "info@web.de" });

            migrationBuilder.InsertData(
                table: "EmailServers",
                columns: new[] { "Id", "Default", "Description", "ServerIp", "ServerPassword", "ServerPort", "ServerUsername" },
                values: new object[] { 1, true, "Testbenutzer", "mail.grillegustav.de", "mobuapXikC", "25", "developper@grillegustav.de" });

            migrationBuilder.InsertData(
                table: "TemplateType",
                columns: new[] { "Id", "Name", "PluginName" },
                values: new object[,]
                {
                    { 1, "Register", "BaseApplication" },
                    { 2, "PasswordReset", "BaseApplication" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Administrator", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 15, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserGroupRemove", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 14, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserGroupUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 13, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserGroupList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 12, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailMessagesList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 11, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 10, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "UserList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateRemove", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 7, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateCreate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerRemove", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerCreate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailServerList", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "EmailTemplateUpdate", new Guid("a0615a54-e885-46a9-9215-ea78faec2084") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a0615a54-e885-46a9-9215-ea78faec2084"), new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b") });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Content", "Default", "Description", "EmailSenderId", "EmailTemplateType", "Language", "Name", "Predefined" },
                values: new object[] { 1, "<p>Please click on the link below to confirm your registration.</p><p><span class='placeholder'>{ConfirmLink}</span></p>", true, "Predefined template. Is used for the first installation if the administrator does not create one.", 1, "register", 0, "Register 1", true });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_EmailSenderId",
                table: "EmailTemplates",
                column: "EmailSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateType_Name",
                table: "TemplateType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmailMessages");

            migrationBuilder.DropTable(
                name: "EmailServers");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "TemplateType");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EmailSenders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
