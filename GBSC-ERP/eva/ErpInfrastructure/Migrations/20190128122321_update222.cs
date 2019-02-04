using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hims_Hystroscopy",
                columns: table => new
                {
                    HystroscopyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anesthetic = table.Column<string>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ConsultantId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Findings = table.Column<string>(nullable: true),
                    HystroscopyDate = table.Column<DateTime>(nullable: false),
                    Indications = table.Column<string>(nullable: true),
                    LmpDate = table.Column<DateTime>(nullable: false),
                    OperationsNote1 = table.Column<string>(nullable: true),
                    OperationsNote2 = table.Column<string>(nullable: true),
                    OperationsNote3 = table.Column<string>(nullable: true),
                    OperationsNote4 = table.Column<string>(nullable: true),
                    OperationsNote5 = table.Column<string>(nullable: true),
                    OperationsNote6 = table.Column<string>(nullable: true),
                    OtProcedureId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_Hystroscopy", x => x.HystroscopyId);
                    table.ForeignKey(
                        name: "FK_Hims_Hystroscopy_Hims_Consultant_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_Hystroscopy_Hims_OtProcedure_OtProcedureId",
                        column: x => x.OtProcedureId,
                        principalTable: "Hims_OtProcedure",
                        principalColumn: "OtProcedureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_Hystroscopy_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_Hystroscopy_ConsultantId",
                table: "Hims_Hystroscopy",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_Hystroscopy_OtProcedureId",
                table: "Hims_Hystroscopy",
                column: "OtProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_Hystroscopy_PatientId",
                table: "Hims_Hystroscopy",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hims_Hystroscopy");
        }
    }
}
