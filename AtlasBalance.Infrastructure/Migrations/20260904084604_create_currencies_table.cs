using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_currencies_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyID",
                table: "expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeISO = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Symbol = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_CurrencyID",
                table: "expenses",
                column: "CurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses",
                column: "CurrencyID",
                principalTable: "currencies",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropIndex(
                name: "IX_expenses_CurrencyID",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "CurrencyID",
                table: "expenses");
        }
    }
}
