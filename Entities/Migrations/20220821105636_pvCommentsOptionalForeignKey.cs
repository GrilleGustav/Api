using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class pvCommentsOptionalForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryBlock_BatteryBlockId",
                table: "Pv_PvComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryCell_BatterCellId",
                table: "Pv_PvComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_PvStorage_PvStorageId",
                table: "Pv_PvComments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "518afbdb-41a7-47d1-b3dd-6d6eb9811206");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "28988ba4-e494-4bc0-af74-61e870d0d67b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "fc560ace-d28b-4aaa-82ad-a154f42bdb3d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBvhMVlV8ajhPodGEAo0iLtiQ4pXm7zZvFlU+ffZYaU1l/y2dv66Mw6cWHBIT3avAQ==");

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryBlock_BatteryBlockId",
                table: "Pv_PvComments",
                column: "BatteryBlockId",
                principalTable: "Pv_Storage_BatteryBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryCell_BatterCellId",
                table: "Pv_PvComments",
                column: "BatterCellId",
                principalTable: "Pv_Storage_BatteryCell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_PvStorage_PvStorageId",
                table: "Pv_PvComments",
                column: "PvStorageId",
                principalTable: "Pv_Storage_PvStorage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryBlock_BatteryBlockId",
                table: "Pv_PvComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryCell_BatterCellId",
                table: "Pv_PvComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_PvStorage_PvStorageId",
                table: "Pv_PvComments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec1457"),
                column: "ConcurrencyStamp",
                value: "9e44f1a3-8eb3-42cf-bce8-527a285b2995");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec2084"),
                column: "ConcurrencyStamp",
                value: "06bb4a7f-82a7-4ac9-a0a1-afce8385a527");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0615a54-e885-46a9-9215-ea78faec9985"),
                column: "ConcurrencyStamp",
                value: "b8e1c3e6-739d-485f-a3b1-cbcad36b6b1e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("493adb36-1365-4cd5-9ecf-93e0078e152b"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIWvzgyaR5QH0B46LMzhhLOvQbLqruvc2l1lIqzHn6ZBsZpXFsIN7wXgG9dLQdk1pg==");

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryBlock_BatteryBlockId",
                table: "Pv_PvComments",
                column: "BatteryBlockId",
                principalTable: "Pv_Storage_BatteryBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_BatteryCell_BatterCellId",
                table: "Pv_PvComments",
                column: "BatterCellId",
                principalTable: "Pv_Storage_BatteryCell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pv_PvComments_Pv_Storage_PvStorage_PvStorageId",
                table: "Pv_PvComments",
                column: "PvStorageId",
                principalTable: "Pv_Storage_PvStorage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
