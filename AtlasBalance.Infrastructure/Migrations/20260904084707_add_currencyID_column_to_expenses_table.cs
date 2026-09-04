using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_currencyID_column_to_expenses_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyID",
                table: "expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses",
                column: "CurrencyID",
                principalTable: "currencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyID",
                table: "expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses",
                column: "CurrencyID",
                principalTable: "currencies",
                principalColumn: "ID");
        }
    }
}
