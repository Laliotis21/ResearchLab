using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class Cat123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Categories_CategoryID",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Members",
                newName: "CategoryName");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CategoryID",
                table: "Members",
                newName: "IX_Members_CategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Categories_CategoryName",
                table: "Members",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Categories_CategoryName",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Members",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CategoryName",
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
    }
}
