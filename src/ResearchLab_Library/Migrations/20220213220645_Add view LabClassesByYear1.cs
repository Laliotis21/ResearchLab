using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    public partial class AddviewLabClassesByYear1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "LabClasses");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "LabClasses",
                newName: "YearTaught");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearTaught",
                table: "LabClasses",
                newName: "StartDate");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "LabClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
