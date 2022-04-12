using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ResearchWorks");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "ResearchWorks",
                newName: "ProjectYearStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectYearPublished",
                table: "ResearchWorks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectYearPublished",
                table: "ResearchWorks");

            migrationBuilder.RenameColumn(
                name: "ProjectYearStart",
                table: "ResearchWorks",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ResearchWorks",
                type: "datetime2",
                nullable: true);
        }
    }
}
