using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Categories_CategoryId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Members",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CategoryId",
                table: "Members",
                newName: "IX_Members_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Categories_CategoryID",
                table: "Members",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Categories_CategoryID",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Members",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CategoryID",
                table: "Members",
                newName: "IX_Members_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Categories_CategoryId",
                table: "Members",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
