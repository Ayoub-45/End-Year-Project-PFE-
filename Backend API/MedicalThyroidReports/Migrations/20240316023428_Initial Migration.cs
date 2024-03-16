using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalThyroidReports.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodePatient = table.Column<int>(type: "int", nullable: false),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientMidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonePatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SexPatient = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Studys",
                columns: table => new
                {
                    IdStudy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRadiologist = table.Column<int>(type: "int", nullable: false),
                    TypeOfStudy = table.Column<int>(type: "int", nullable: false),
                    DateStudy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientIdPatient = table.Column<int>(type: "int", nullable: true),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vascularization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Echogenicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LymphNodeUltra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThyroglossalTrackStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studys", x => x.IdStudy);
                    table.ForeignKey(
                        name: "FK_Studys_Patients_PatientIdPatient",
                        column: x => x.PatientIdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.CreateTable(
                name: "Nodules",
                columns: table => new
                {
                    IdNodule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Composition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Echogenecity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Evolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScoreTIRADS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThyroidStudyIdStudy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodules", x => x.IdNodule);
                    table.ForeignKey(
                        name: "FK_Nodules_Studys_ThyroidStudyIdStudy",
                        column: x => x.ThyroidStudyIdStudy,
                        principalTable: "Studys",
                        principalColumn: "IdStudy");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nodules_ThyroidStudyIdStudy",
                table: "Nodules",
                column: "ThyroidStudyIdStudy");

            migrationBuilder.CreateIndex(
                name: "IX_Studys_PatientIdPatient",
                table: "Studys",
                column: "PatientIdPatient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodules");

            migrationBuilder.DropTable(
                name: "Studys");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
