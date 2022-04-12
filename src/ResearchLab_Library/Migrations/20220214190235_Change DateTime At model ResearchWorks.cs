using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class ChangeDateTimeAtmodelResearchWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchWorksByYear_Members_MemberId",
                table: "ResearchWorksByYear");

            migrationBuilder.DropIndex(
                name: "IX_ResearchWorksByYear_MemberId",
                table: "ResearchWorksByYear");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ResearchWorksByYear");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "ResearchWorksByYear");

            migrationBuilder.RenameColumn(
                name: "ProjectYearStart",
                table: "ResearchWorksByYear",
                newName: "MemberName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberName",
                table: "ResearchWorksByYear",
                newName: "ProjectYearStart");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ResearchWorksByYear",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MemberId",
                table: "ResearchWorksByYear",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchWorksByYear_MemberId",
                table: "ResearchWorksByYear",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchWorksByYear_Members_MemberId",
                table: "ResearchWorksByYear",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
