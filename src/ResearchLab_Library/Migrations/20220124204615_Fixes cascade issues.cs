using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class Fixescascadeissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembersPublications_Members_MemberID",
                table: "MembersPublications");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersPublications_Publications_PublicationID",
                table: "MembersPublications");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersPublications_Members_MemberID",
                table: "MembersPublications",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersPublications_Publications_PublicationID",
                table: "MembersPublications",
                column: "PublicationID",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembersPublications_Members_MemberID",
                table: "MembersPublications");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersPublications_Publications_PublicationID",
                table: "MembersPublications");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersPublications_Members_MemberID",
                table: "MembersPublications",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersPublications_Publications_PublicationID",
                table: "MembersPublications",
                column: "PublicationID",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
