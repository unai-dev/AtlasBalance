using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_payment_method_id_column_to_expenses_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodID",
                table: "expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_expenses_PaymentMethodID",
                table: "expenses",
                column: "PaymentMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_payment_methods_PaymentMethodID",
                table: "expenses",
                column: "PaymentMethodID",
                principalTable: "payment_methods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_payment_methods_PaymentMethodID",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_PaymentMethodID",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "PaymentMethodID",
                table: "expenses");
        }
    }
}
