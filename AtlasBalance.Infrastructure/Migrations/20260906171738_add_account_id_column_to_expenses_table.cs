using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_account_id_column_to_expenses_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_accounts_AccountID",
                table: "expenses");

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                table: "expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_accounts_AccountID",
                table: "expenses",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_accounts_AccountID",
                table: "expenses");

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                table: "expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_accounts_AccountID",
                table: "expenses",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "ID");
        }
    }
}
