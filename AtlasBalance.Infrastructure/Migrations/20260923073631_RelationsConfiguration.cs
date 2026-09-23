using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationsConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_accounts_AspNetUsers_UserID",
                table: "asp_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_AspNetUsers_UserID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_asp_Categories_CategoryID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_LanguageResources_asp_Languages_LanguageID",
                table: "asp_LanguageResources");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_AspNetUsers_UserID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_asp_Categories_CategoryID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_accounts_AspNetUsers_UserID",
                table: "asp_accounts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Expenses_AspNetUsers_UserID",
                table: "asp_Expenses",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Expenses_asp_Categories_CategoryID",
                table: "asp_Expenses",
                column: "CategoryID",
                principalTable: "asp_Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Expenses_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Expenses",
                column: "PaymentMethodID",
                principalTable: "asp_PaymentMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_LanguageResources_asp_Languages_LanguageID",
                table: "asp_LanguageResources",
                column: "LanguageID",
                principalTable: "asp_Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_AspNetUsers_UserID",
                table: "asp_Transfers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_asp_Categories_CategoryID",
                table: "asp_Transfers",
                column: "CategoryID",
                principalTable: "asp_Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Transfers",
                column: "PaymentMethodID",
                principalTable: "asp_PaymentMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_accounts_AspNetUsers_UserID",
                table: "asp_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_AspNetUsers_UserID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_asp_Categories_CategoryID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_LanguageResources_asp_Languages_LanguageID",
                table: "asp_LanguageResources");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_AspNetUsers_UserID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_asp_Categories_CategoryID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_accounts_AspNetUsers_UserID",
                table: "asp_accounts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Expenses_AspNetUsers_UserID",
                table: "asp_Expenses",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Expenses_asp_Categories_CategoryID",
                table: "asp_Expenses",
                column: "CategoryID",
                principalTable: "asp_Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Expenses_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Expenses",
                column: "PaymentMethodID",
                principalTable: "asp_PaymentMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_LanguageResources_asp_Languages_LanguageID",
                table: "asp_LanguageResources",
                column: "LanguageID",
                principalTable: "asp_Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_AspNetUsers_UserID",
                table: "asp_Transfers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_asp_Categories_CategoryID",
                table: "asp_Transfers",
                column: "CategoryID",
                principalTable: "asp_Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Transfers",
                column: "PaymentMethodID",
                principalTable: "asp_PaymentMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
