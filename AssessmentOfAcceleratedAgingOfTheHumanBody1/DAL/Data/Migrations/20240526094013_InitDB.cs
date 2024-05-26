using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccauntIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BodyMassIndex = table.Column<double>(type: "float", nullable: false),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaistCircumference = table.Column<double>(type: "float", nullable: false),
                    HeartRate = table.Column<int>(type: "int", nullable: false),
                    SleepTime = table.Column<int>(type: "int", nullable: false),
                    CircadianRhythms = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfHoursSitting = table.Column<int>(type: "int", nullable: false),
                    NumberOfCigarettesSmokedPerDay = table.Column<int>(type: "int", nullable: false),
                    AmountOfAlcoholDrunkPerDay = table.Column<int>(type: "int", nullable: false),
                    NumberOfMeals = table.Column<int>(type: "int", nullable: false),
                    ResultsOfTheQualityOfLifeQuestionnaire = table.Column<int>(type: "int", nullable: false),
                    ResultsOfThePTSDQuestionnaire = table.Column<int>(type: "int", nullable: false),
                    ResultOfDiagnostic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Accounts_AccauntIdId",
                        column: x => x.AccauntIdId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_AccauntIdId",
                table: "Results",
                column: "AccauntIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
