using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasBalance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_language_resource_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_language_resources_LanguageResourceID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LanguageResourceID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LanguageResourceID",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageResourceID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LanguageResourceID",
                table: "AspNetUsers",
                column: "LanguageResourceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_language_resources_LanguageResourceID",
                table: "AspNetUsers",
                column: "LanguageResourceID",
                principalTable: "language_resources",
                principalColumn: "ID");
        }
    }
}
