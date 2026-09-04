using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_categoryID_column_to_expenses_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_expenses_CategoryID",
                table: "expenses",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_categories_CategoryID",
                table: "expenses",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_categories_CategoryID",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_CategoryID",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "expenses");
        }
    }
}
