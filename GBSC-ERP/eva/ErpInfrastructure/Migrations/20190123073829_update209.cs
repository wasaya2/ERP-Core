using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update209 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_Allowance_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_Allowance");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_SalaryStructureDetail_Hr_Payroll_Allowance_AllowanceId",
                table: "Hr_Payroll_SalaryStructureDetail");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_SalaryStructureDetail_AllowanceId",
                table: "Hr_Payroll_SalaryStructureDetail");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_Allowance_AllowanceDeductionId",
                table: "Hr_Payroll_Allowance");

            migrationBuilder.DropColumn(
                name: "AllowanceId",
                table: "Hr_Payroll_SalaryStructureDetail");

            migrationBuilder.DropColumn(
                name: "BaseSalary",
                table: "Hr_Payroll_SalaryStructureDetail");

            migrationBuilder.DropColumn(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_Allowance");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Hr_Payroll_AllowanceDeduction",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultAllowance",
                table: "Hr_Payroll_AllowanceDeduction",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hims_OtPatientCase",
                columns: table => new
                {
                    OtPatientCaseId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anestetic = table.Column<string>(nullable: true),
                    AnesthesiaType = table.Column<string>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DateNature = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DoneById = table.Column<long>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Nurse = table.Column<string>(nullable: true),
                    OtAssistant = table.Column<string>(nullable: true),
                    OtPatientCaseDate = table.Column<DateTime>(nullable: false),
                    Other = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    ProcedureId = table.Column<long>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ScrubAssistant = table.Column<string>(nullable: true),
                    SurgeonId = table.Column<long>(nullable: true),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_OtPatientCase", x => x.OtPatientCaseId);
                    table.ForeignKey(
                        name: "FK_Hims_OtPatientCase_Hims_Consultant_DoneById",
                        column: x => x.DoneById,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_OtPatientCase_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_OtPatientCase_Hims_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Hims_Procedure",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_OtPatientCase_Hims_Consultant_SurgeonId",
                        column: x => x.SurgeonId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_OtPatientCase_DoneById",
                table: "Hims_OtPatientCase",
                column: "DoneById");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_OtPatientCase_PatientId",
                table: "Hims_OtPatientCase",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_OtPatientCase_ProcedureId",
                table: "Hims_OtPatientCase",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_OtPatientCase_SurgeonId",
                table: "Hims_OtPatientCase",
                column: "SurgeonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hims_OtPatientCase");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Hr_Payroll_AllowanceDeduction");

            migrationBuilder.DropColumn(
                name: "IsDefaultAllowance",
                table: "Hr_Payroll_AllowanceDeduction");

            migrationBuilder.AddColumn<long>(
                name: "AllowanceId",
                table: "Hr_Payroll_SalaryStructureDetail",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BaseSalary",
                table: "Hr_Payroll_SalaryStructureDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_Allowance",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_SalaryStructureDetail_AllowanceId",
                table: "Hr_Payroll_SalaryStructureDetail",
                column: "AllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_Allowance_AllowanceDeductionId",
                table: "Hr_Payroll_Allowance",
                column: "AllowanceDeductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_Allowance_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_Allowance",
                column: "AllowanceDeductionId",
                principalTable: "Hr_Payroll_AllowanceDeduction",
                principalColumn: "AllowanceDeductionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_SalaryStructureDetail_Hr_Payroll_Allowance_AllowanceId",
                table: "Hr_Payroll_SalaryStructureDetail",
                column: "AllowanceId",
                principalTable: "Hr_Payroll_Allowance",
                principalColumn: "AllowanceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
