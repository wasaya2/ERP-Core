using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update168 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChequeNumber",
                table: "Finance_Voucher");

            migrationBuilder.AddColumn<string>(
                name: "ChequeNUmber",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hims_DailySemenAnalysis",
                columns: table => new
                {
                    DailySemenAnalysisId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ConsultantId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    Payment = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Timein = table.Column<string>(nullable: true),
                    Timeout = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_DailySemenAnalysis", x => x.DailySemenAnalysisId);
                    table.ForeignKey(
                        name: "FK_Hims_DailySemenAnalysis_Hims_Consultant_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_DailySemenAnalysis_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailySemenAnalysisProcedure",
                columns: table => new
                {
                    ProcedureId = table.Column<long>(nullable: false),
                    DailySemenAnalysisId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySemenAnalysisProcedure", x => new { x.ProcedureId, x.DailySemenAnalysisId });
                    table.ForeignKey(
                        name: "FK_DailySemenAnalysisProcedure_Hims_DailySemenAnalysis_DailySemenAnalysisId",
                        column: x => x.DailySemenAnalysisId,
                        principalTable: "Hims_DailySemenAnalysis",
                        principalColumn: "DailySemenAnalysisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailySemenAnalysisProcedure_Hims_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Hims_Procedure",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailySemenAnalysisProcedure_DailySemenAnalysisId",
                table: "DailySemenAnalysisProcedure",
                column: "DailySemenAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_DailySemenAnalysis_ConsultantId",
                table: "Hims_DailySemenAnalysis",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_DailySemenAnalysis_PatientId",
                table: "Hims_DailySemenAnalysis",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySemenAnalysisProcedure");

            migrationBuilder.DropTable(
                name: "Hims_DailySemenAnalysis");

            migrationBuilder.DropColumn(
                name: "ChequeNUmber",
                table: "Finance_VoucherDetail");

            migrationBuilder.AddColumn<string>(
                name: "ChequeNumber",
                table: "Finance_Voucher",
                nullable: true);
        }
    }
}
