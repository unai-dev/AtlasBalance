using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_transfers_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MovementDate",
                table: "expenses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "transfers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Addressee = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sender = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpensesGroupID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MovementDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_transfers_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfers_accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfers_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfers_currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfers_expenses_groups_ExpensesGroupID",
                        column: x => x.ExpensesGroupID,
                        principalTable: "expenses_groups",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_transfers_payment_methods_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "payment_methods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_AccountID",
                table: "transfers",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_CategoryID",
                table: "transfers",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_CurrencyID",
                table: "transfers",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_ExpensesGroupID",
                table: "transfers",
                column: "ExpensesGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_PaymentMethodID",
                table: "transfers",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_UserID",
                table: "transfers",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transfers");

            migrationBuilder.DropColumn(
                name: "MovementDate",
                table: "expenses");
        }
    }
}
