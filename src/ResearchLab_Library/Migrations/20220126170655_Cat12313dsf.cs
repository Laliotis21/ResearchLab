using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class Cat12313dsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Categories_CategoryName",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Members",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CategoryName",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Categories_CategoryId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Members",
                newName: "CategoryName");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CategoryId",
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
    }
}
