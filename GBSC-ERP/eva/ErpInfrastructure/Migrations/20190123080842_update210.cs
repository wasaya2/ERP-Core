using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update210 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VendorBillNumber",
                table: "Inv_GRN",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_SalaryStructureDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_SalaryStructureDetail_AllowanceDeductionId",
                table: "Hr_Payroll_SalaryStructureDetail",
                column: "AllowanceDeductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_SalaryStructureDetail_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_SalaryStructureDetail",
                column: "AllowanceDeductionId",
                principalTable: "Hr_Payroll_AllowanceDeduction",
                principalColumn: "AllowanceDeductionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_SalaryStructureDetail_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_SalaryStructureDetail");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_SalaryStructureDetail_AllowanceDeductionId",
                table: "Hr_Payroll_SalaryStructureDetail");

            migrationBuilder.DropColumn(
                name: "VendorBillNumber",
                table: "Inv_GRN");

            migrationBuilder.DropColumn(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_SalaryStructureDetail");
        }
    }
}
