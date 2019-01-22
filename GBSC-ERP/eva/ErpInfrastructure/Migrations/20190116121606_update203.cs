using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hims_FWBInitial",
                columns: table => new
                {
                    FwbInitialId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmnioticFluid = table.Column<string>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CFacts = table.Column<string>(nullable: true),
                    CRL = table.Column<string>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ConsultantId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CycleNo = table.Column<long>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    ETDate = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    FoetalHeartBeat = table.Column<string>(nullable: true),
                    FoetalMovement = table.Column<string>(nullable: true),
                    FwbInitialDate = table.Column<DateTime>(nullable: false),
                    GSac = table.Column<string>(nullable: true),
                    GestAge = table.Column<string>(nullable: true),
                    LMPDate = table.Column<DateTime>(nullable: false),
                    NoofFoetus = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PlacnetalLocallisation = table.Column<string>(nullable: true),
                    SonologistId = table.Column<long>(nullable: true),
                    TreatmentNo = table.Column<long>(nullable: false),
                    TreatmentTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_FWBInitial", x => x.FwbInitialId);
                    table.ForeignKey(
                        name: "FK_Hims_FWBInitial_Hims_Consultant_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_FWBInitial_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_FWBInitial_Hims_Sonologist_SonologistId",
                        column: x => x.SonologistId,
                        principalTable: "Hims_Sonologist",
                        principalColumn: "SonologistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_FWBInitial_Hims_TreatmentType_TreatmentTypeId",
                        column: x => x.TreatmentTypeId,
                        principalTable: "Hims_TreatmentType",
                        principalColumn: "TreatmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_FWBInitial_ConsultantId",
                table: "Hims_FWBInitial",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_FWBInitial_PatientId",
                table: "Hims_FWBInitial",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_FWBInitial_SonologistId",
                table: "Hims_FWBInitial",
                column: "SonologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_FWBInitial_TreatmentTypeId",
                table: "Hims_FWBInitial",
                column: "TreatmentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hims_FWBInitial");
        }
    }
}
