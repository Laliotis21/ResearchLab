using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class ChangeDateTimeAtmodelResearchWorksse1q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "YearTaught",
                table: "LabClasses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YearTaught",
                table: "LabClasses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
