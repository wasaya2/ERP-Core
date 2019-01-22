using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hims_Sonologist",
                columns: table => new
                {
                    SonologistId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_Sonologist", x => x.SonologistId);
                });

            migrationBuilder.CreateTable(
                name: "Hims_UltraSoundPelvis",
                columns: table => new
                {
                    UltraSoundPelvisId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AP = table.Column<string>(nullable: true),
                    AreaScanned = table.Column<string>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ConsultantId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CycleDay = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Endometrium = table.Column<string>(nullable: true),
                    EtOn = table.Column<DateTime>(nullable: false),
                    Findings = table.Column<string>(nullable: true),
                    FluidAbdomen = table.Column<string>(nullable: true),
                    FluidPelvis = table.Column<string>(nullable: true),
                    FocalMassesInUterus = table.Column<string>(nullable: true),
                    LMP = table.Column<DateTime>(nullable: false),
                    LS = table.Column<string>(nullable: true),
                    LargeSizeLeftOvary = table.Column<string>(nullable: true),
                    LargeSizeRightOvary = table.Column<string>(nullable: true),
                    LeftOvary = table.Column<string>(nullable: true),
                    LeftOvaryGrading = table.Column<string>(nullable: true),
                    NoOfFolliciesLeftOvary = table.Column<string>(nullable: true),
                    NoOfFolliciesRightOvary = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    RightOvary = table.Column<string>(nullable: true),
                    RightOvaryGrading = table.Column<string>(nullable: true),
                    SonologistId = table.Column<long>(nullable: true),
                    TS = table.Column<string>(nullable: true),
                    TreatmentDay = table.Column<string>(nullable: true),
                    TreatmentTypeId = table.Column<long>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UltrasoundDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_UltraSoundPelvis", x => x.UltraSoundPelvisId);
                    table.ForeignKey(
                        name: "FK_Hims_UltraSoundPelvis_Hims_Consultant_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_UltraSoundPelvis_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_UltraSoundPelvis_Hims_Sonologist_SonologistId",
                        column: x => x.SonologistId,
                        principalTable: "Hims_Sonologist",
                        principalColumn: "SonologistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_UltraSoundPelvis_Hims_TreatmentType_TreatmentTypeId",
                        column: x => x.TreatmentTypeId,
                        principalTable: "Hims_TreatmentType",
                        principalColumn: "TreatmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_UltraSoundPelvis_ConsultantId",
                table: "Hims_UltraSoundPelvis",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_UltraSoundPelvis_PatientId",
                table: "Hims_UltraSoundPelvis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_UltraSoundPelvis_SonologistId",
                table: "Hims_UltraSoundPelvis",
                column: "SonologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_UltraSoundPelvis_TreatmentTypeId",
                table: "Hims_UltraSoundPelvis",
                column: "TreatmentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hims_UltraSoundPelvis");

            migrationBuilder.DropTable(
                name: "Hims_Sonologist");
        }
    }
}
