using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_validation_rules_to_transfers_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "transfers",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 91, DateTimeKind.Utc).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 90, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 90, DateTimeKind.Utc).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 90, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 90, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 102, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 102, DateTimeKind.Utc).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 92, DateTimeKind.Utc).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 92, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 92, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 10, 20, 57, 92, DateTimeKind.Utc).AddTicks(8675));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "transfers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8505));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 59, 5, DateTimeKind.Utc).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 59, 5, DateTimeKind.Utc).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7404));
        }
    }
}
