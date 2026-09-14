using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_expenses_groups_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpensesGroupID",
                table: "expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "expenses_groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses_groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_expenses_groups_AspNetUsers_GuestID",
                        column: x => x.GuestID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_expenses_groups_AspNetUsers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_expenses_groups_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_ExpensesGroupID",
                table: "expenses",
                column: "ExpensesGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_groups_CategoryID",
                table: "expenses_groups",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_groups_GuestID",
                table: "expenses_groups",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_groups_OwnerID",
                table: "expenses_groups",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_expenses_groups_ExpensesGroupID",
                table: "expenses",
                column: "ExpensesGroupID",
                principalTable: "expenses_groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_expenses_groups_ExpensesGroupID",
                table: "expenses");

            migrationBuilder.DropTable(
                name: "expenses_groups");

            migrationBuilder.DropIndex(
                name: "IX_expenses_ExpensesGroupID",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "ExpensesGroupID",
                table: "expenses");
        }
    }
}
