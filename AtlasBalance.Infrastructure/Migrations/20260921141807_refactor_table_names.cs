using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactor_table_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_AspNetUsers_UserID",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_languages_LanguageID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_AspNetUsers_UserID",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_accounts_AccountID",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_categories_CategoryID",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_expenses_groups_ExpensesGroupID",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_payment_methods_PaymentMethodID",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_groups_AspNetUsers_GuestID",
                table: "expenses_groups");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_groups_AspNetUsers_OwnerID",
                table: "expenses_groups");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_groups_categories_CategoryID",
                table: "expenses_groups");

            migrationBuilder.DropForeignKey(
                name: "FK_language_resources_languages_LanguageID",
                table: "language_resources");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_AspNetUsers_UserID",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_accounts_AccountID",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_categories_CategoryID",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_currencies_CurrencyID",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_expenses_groups_ExpensesGroupID",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_payment_methods_PaymentMethodID",
                table: "transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transfers",
                table: "transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payment_methods",
                table: "payment_methods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_languages",
                table: "languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_language_resources",
                table: "language_resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenses_groups",
                table: "expenses_groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenses",
                table: "expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_currencies",
                table: "currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.RenameTable(
                name: "transfers",
                newName: "asp_Transfers");

            migrationBuilder.RenameTable(
                name: "payment_methods",
                newName: "asp_PaymentMethods");

            migrationBuilder.RenameTable(
                name: "languages",
                newName: "asp_Languages");

            migrationBuilder.RenameTable(
                name: "language_resources",
                newName: "asp_LanguageResources");

            migrationBuilder.RenameTable(
                name: "expenses_groups",
                newName: "asp_ExpensesGroups");

            migrationBuilder.RenameTable(
                name: "expenses",
                newName: "asp_Expenses");

            migrationBuilder.RenameTable(
                name: "currencies",
                newName: "asp_Currencies");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "asp_Categories");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "asp_accounts");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_UserID",
                table: "asp_Transfers",
                newName: "IX_asp_Transfers_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_PaymentMethodID",
                table: "asp_Transfers",
                newName: "IX_asp_Transfers_PaymentMethodID");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_ExpensesGroupID",
                table: "asp_Transfers",
                newName: "IX_asp_Transfers_ExpensesGroupID");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_CurrencyID",
                table: "asp_Transfers",
                newName: "IX_asp_Transfers_CurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_CategoryID",
                table: "asp_Transfers",
                newName: "IX_asp_Transfers_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_AccountID",
                table: "asp_Transfers",
                newName: "IX_asp_Transfers_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_language_resources_LanguageID",
                table: "asp_LanguageResources",
                newName: "IX_asp_LanguageResources_LanguageID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_groups_OwnerID",
                table: "asp_ExpensesGroups",
                newName: "IX_asp_ExpensesGroups_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_groups_GuestID",
                table: "asp_ExpensesGroups",
                newName: "IX_asp_ExpensesGroups_GuestID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_groups_CategoryID",
                table: "asp_ExpensesGroups",
                newName: "IX_asp_ExpensesGroups_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_UserID",
                table: "asp_Expenses",
                newName: "IX_asp_Expenses_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_PaymentMethodID",
                table: "asp_Expenses",
                newName: "IX_asp_Expenses_PaymentMethodID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_ExpensesGroupID",
                table: "asp_Expenses",
                newName: "IX_asp_Expenses_ExpensesGroupID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_CurrencyID",
                table: "asp_Expenses",
                newName: "IX_asp_Expenses_CurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_CategoryID",
                table: "asp_Expenses",
                newName: "IX_asp_Expenses_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_AccountID",
                table: "asp_Expenses",
                newName: "IX_asp_Expenses_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_UserID",
                table: "asp_accounts",
                newName: "IX_asp_accounts_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_Transfers",
                table: "asp_Transfers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_PaymentMethods",
                table: "asp_PaymentMethods",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_Languages",
                table: "asp_Languages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_LanguageResources",
                table: "asp_LanguageResources",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_ExpensesGroups",
                table: "asp_ExpensesGroups",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_Expenses",
                table: "asp_Expenses",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_Currencies",
                table: "asp_Currencies",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_Categories",
                table: "asp_Categories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_accounts",
                table: "asp_accounts",
                column: "ID");

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
                name: "FK_asp_Expenses_asp_Currencies_CurrencyID",
                table: "asp_Expenses",
                column: "CurrencyID",
                principalTable: "asp_Currencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Expenses_asp_ExpensesGroups_ExpensesGroupID",
                table: "asp_Expenses",
                column: "ExpensesGroupID",
                principalTable: "asp_ExpensesGroups",
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
                name: "FK_asp_Expenses_asp_accounts_AccountID",
                table: "asp_Expenses",
                column: "AccountID",
                principalTable: "asp_accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_ExpensesGroups_AspNetUsers_GuestID",
                table: "asp_ExpensesGroups",
                column: "GuestID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_ExpensesGroups_AspNetUsers_OwnerID",
                table: "asp_ExpensesGroups",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_ExpensesGroups_asp_Categories_CategoryID",
                table: "asp_ExpensesGroups",
                column: "CategoryID",
                principalTable: "asp_Categories",
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
                name: "FK_asp_Transfers_asp_Currencies_CurrencyID",
                table: "asp_Transfers",
                column: "CurrencyID",
                principalTable: "asp_Currencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_asp_ExpensesGroups_ExpensesGroupID",
                table: "asp_Transfers",
                column: "ExpensesGroupID",
                principalTable: "asp_ExpensesGroups",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Transfers",
                column: "PaymentMethodID",
                principalTable: "asp_PaymentMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Transfers_asp_accounts_AccountID",
                table: "asp_Transfers",
                column: "AccountID",
                principalTable: "asp_accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_asp_Languages_LanguageID",
                table: "AspNetUsers",
                column: "LanguageID",
                principalTable: "asp_Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_asp_Expenses_asp_Currencies_CurrencyID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_asp_ExpensesGroups_ExpensesGroupID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Expenses_asp_accounts_AccountID",
                table: "asp_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_ExpensesGroups_AspNetUsers_GuestID",
                table: "asp_ExpensesGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_ExpensesGroups_AspNetUsers_OwnerID",
                table: "asp_ExpensesGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_ExpensesGroups_asp_Categories_CategoryID",
                table: "asp_ExpensesGroups");

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
                name: "FK_asp_Transfers_asp_Currencies_CurrencyID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_asp_ExpensesGroups_ExpensesGroupID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_asp_PaymentMethods_PaymentMethodID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Transfers_asp_accounts_AccountID",
                table: "asp_Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_asp_Languages_LanguageID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_Transfers",
                table: "asp_Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_PaymentMethods",
                table: "asp_PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_Languages",
                table: "asp_Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_LanguageResources",
                table: "asp_LanguageResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_ExpensesGroups",
                table: "asp_ExpensesGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_Expenses",
                table: "asp_Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_Currencies",
                table: "asp_Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_Categories",
                table: "asp_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_accounts",
                table: "asp_accounts");

            migrationBuilder.RenameTable(
                name: "asp_Transfers",
                newName: "transfers");

            migrationBuilder.RenameTable(
                name: "asp_PaymentMethods",
                newName: "payment_methods");

            migrationBuilder.RenameTable(
                name: "asp_Languages",
                newName: "languages");

            migrationBuilder.RenameTable(
                name: "asp_LanguageResources",
                newName: "language_resources");

            migrationBuilder.RenameTable(
                name: "asp_ExpensesGroups",
                newName: "expenses_groups");

            migrationBuilder.RenameTable(
                name: "asp_Expenses",
                newName: "expenses");

            migrationBuilder.RenameTable(
                name: "asp_Currencies",
                newName: "currencies");

            migrationBuilder.RenameTable(
                name: "asp_Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "asp_accounts",
                newName: "accounts");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Transfers_UserID",
                table: "transfers",
                newName: "IX_transfers_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Transfers_PaymentMethodID",
                table: "transfers",
                newName: "IX_transfers_PaymentMethodID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Transfers_ExpensesGroupID",
                table: "transfers",
                newName: "IX_transfers_ExpensesGroupID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Transfers_CurrencyID",
                table: "transfers",
                newName: "IX_transfers_CurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Transfers_CategoryID",
                table: "transfers",
                newName: "IX_transfers_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Transfers_AccountID",
                table: "transfers",
                newName: "IX_transfers_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_LanguageResources_LanguageID",
                table: "language_resources",
                newName: "IX_language_resources_LanguageID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_ExpensesGroups_OwnerID",
                table: "expenses_groups",
                newName: "IX_expenses_groups_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_ExpensesGroups_GuestID",
                table: "expenses_groups",
                newName: "IX_expenses_groups_GuestID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_ExpensesGroups_CategoryID",
                table: "expenses_groups",
                newName: "IX_expenses_groups_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Expenses_UserID",
                table: "expenses",
                newName: "IX_expenses_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Expenses_PaymentMethodID",
                table: "expenses",
                newName: "IX_expenses_PaymentMethodID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Expenses_ExpensesGroupID",
                table: "expenses",
                newName: "IX_expenses_ExpensesGroupID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Expenses_CurrencyID",
                table: "expenses",
                newName: "IX_expenses_CurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Expenses_CategoryID",
                table: "expenses",
                newName: "IX_expenses_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_Expenses_AccountID",
                table: "expenses",
                newName: "IX_expenses_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_asp_accounts_UserID",
                table: "accounts",
                newName: "IX_accounts_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transfers",
                table: "transfers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payment_methods",
                table: "payment_methods",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_languages",
                table: "languages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_language_resources",
                table: "language_resources",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenses_groups",
                table: "expenses_groups",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenses",
                table: "expenses",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_currencies",
                table: "currencies",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_AspNetUsers_UserID",
                table: "accounts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_languages_LanguageID",
                table: "AspNetUsers",
                column: "LanguageID",
                principalTable: "languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_AspNetUsers_UserID",
                table: "expenses",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_accounts_AccountID",
                table: "expenses",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_categories_CategoryID",
                table: "expenses",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_currencies_CurrencyID",
                table: "expenses",
                column: "CurrencyID",
                principalTable: "currencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_expenses_groups_ExpensesGroupID",
                table: "expenses",
                column: "ExpensesGroupID",
                principalTable: "expenses_groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_payment_methods_PaymentMethodID",
                table: "expenses",
                column: "PaymentMethodID",
                principalTable: "payment_methods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_groups_AspNetUsers_GuestID",
                table: "expenses_groups",
                column: "GuestID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_groups_AspNetUsers_OwnerID",
                table: "expenses_groups",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_groups_categories_CategoryID",
                table: "expenses_groups",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_language_resources_languages_LanguageID",
                table: "language_resources",
                column: "LanguageID",
                principalTable: "languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_AspNetUsers_UserID",
                table: "transfers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_accounts_AccountID",
                table: "transfers",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_categories_CategoryID",
                table: "transfers",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_currencies_CurrencyID",
                table: "transfers",
                column: "CurrencyID",
                principalTable: "currencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_expenses_groups_ExpensesGroupID",
                table: "transfers",
                column: "ExpensesGroupID",
                principalTable: "expenses_groups",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_payment_methods_PaymentMethodID",
                table: "transfers",
                column: "PaymentMethodID",
                principalTable: "payment_methods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
