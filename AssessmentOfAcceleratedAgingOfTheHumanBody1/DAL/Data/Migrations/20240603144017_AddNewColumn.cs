using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data.Migrations
{
    public partial class AddNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Results");
        }
    }
}
