using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_relation_to_many_expenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payment_methods_payment_methods_PaymentMethodID",
                table: "payment_methods");

            migrationBuilder.DropIndex(
                name: "IX_payment_methods_PaymentMethodID",
                table: "payment_methods");

            migrationBuilder.DropColumn(
                name: "PaymentMethodID",
                table: "payment_methods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodID",
                table: "payment_methods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payment_methods_PaymentMethodID",
                table: "payment_methods",
                column: "PaymentMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_payment_methods_payment_methods_PaymentMethodID",
                table: "payment_methods",
                column: "PaymentMethodID",
                principalTable: "payment_methods",
                principalColumn: "ID");
        }
    }
}
