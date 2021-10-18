using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccinationCampaignUI.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coutry = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Hous = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Flat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDis = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionVacc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Dose = table.Column<double>(type: "float", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccines_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Appeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recommendation = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Doctor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appeals_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMedInst = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AdressMedInst = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    AppealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_Appeals_AppealId",
                        column: x => x.AppealId,
                        principalTable: "Appeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameVaccine = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NamberDose = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    MedicalInsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Institution_MedicalInsId",
                        column: x => x.MedicalInsId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_PatientId",
                table: "Appeals",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_AppealId",
                table: "Institution",
                column: "AppealId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_MedicalInsId",
                table: "Vaccinations",
                column: "MedicalInsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_PatientId",
                table: "Vaccinations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_DiseaseId",
                table: "Vaccines",
                column: "DiseaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Appeals");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
