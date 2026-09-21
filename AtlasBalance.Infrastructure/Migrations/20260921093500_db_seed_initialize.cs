using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class db_seed_initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8479), "Food", null },
                    { 2, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8494), "Transport", null },
                    { 3, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8497), "Utilities", null },
                    { 4, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8500), "Entertainment", null },
                    { 5, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8502), "Health", null },
                    { 6, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8505), "Education", null },
                    { 7, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8507), "Shopping", null },
                    { 8, new DateTime(2026, 9, 21, 9, 34, 58, 993, DateTimeKind.Utc).AddTicks(8510), "Others", null }
                });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "ID", "CodeISO", "CreatedAt", "Name", "Symbol", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "USD", new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(906), "US Dollar", "$", null },
                    { 2, "EUR", new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(1452), "Euro", "€", null },
                    { 3, "GBP", new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(1456), "Pound Sterling", "£", null },
                    { 4, "JPY", new DateTime(2026, 9, 21, 9, 34, 58, 992, DateTimeKind.Utc).AddTicks(1459), "Japanese Yen", "¥", null }
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "ID", "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "en", new DateTime(2026, 9, 21, 9, 34, 59, 5, DateTimeKind.Utc).AddTicks(3423), "English", null },
                    { 2, "es", new DateTime(2026, 9, 21, 9, 34, 59, 5, DateTimeKind.Utc).AddTicks(3439), "Español", null }
                });

            migrationBuilder.InsertData(
                table: "payment_methods",
                columns: new[] { "ID", "CreatedAt", "MethodType", "ProviderName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7383), "Cash", "General", null },
                    { 2, new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7398), "Card", "Visa", null },
                    { 3, new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7401), "Card", "Mastercard", null },
                    { 4, new DateTime(2026, 9, 21, 9, 34, 58, 994, DateTimeKind.Utc).AddTicks(7404), "BankTransfer", "SEPA", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "payment_methods",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
