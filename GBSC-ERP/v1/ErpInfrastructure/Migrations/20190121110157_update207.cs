using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update207 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hims_UltraSoundMaster",
                columns: table => new
                {
                    UltraSoundMasterId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ac = table.Column<string>(nullable: true),
                    Afi = table.Column<string>(nullable: true),
                    AmnioticFluid = table.Column<string>(nullable: true),
                    Bpd = table.Column<string>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CFacts = table.Column<string>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ConsultantId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Crl = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Ebw = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    EtDate = table.Column<DateTime>(nullable: false),
                    Fl = table.Column<string>(nullable: true),
                    FoetalHeartBeat = table.Column<string>(nullable: true),
                    FoetalMovement = table.Column<string>(nullable: true),
                    GeatAge = table.Column<string>(nullable: true),
                    Gs = table.Column<string>(nullable: true),
                    Hc = table.Column<string>(nullable: true),
                    LMP = table.Column<DateTime>(nullable: false),
                    LieOfFoetus = table.Column<string>(nullable: true),
                    NoofFoetus = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PlacentalGrade = table.Column<string>(nullable: true),
                    PlacnetalLocallisation = table.Column<string>(nullable: true),
                    Presentation = table.Column<string>(nullable: true),
                    SonologistId = table.Column<long>(nullable: true),
                    UltraSoundMasterDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_UltraSoundMaster", x => x.UltraSoundMasterId);
                    table.ForeignKey(
                        name: "FK_Hims_UltraSoundMaster_Hims_Consultant_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_UltraSoundMaster_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_UltraSoundMaster_Hims_Sonologist_SonologistId",
                        column: x => x.SonologistId,
                        principalTable: "Hims_Sonologist",
                        principalColumn: "SonologistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_UltraSoundMaster_ConsultantId",
                table: "Hims_UltraSoundMaster",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_UltraSoundMaster_PatientId",
                table: "Hims_UltraSoundMaster",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_UltraSoundMaster_SonologistId",
                table: "Hims_UltraSoundMaster",
                column: "SonologistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hims_UltraSoundMaster");
        }
    }
}
