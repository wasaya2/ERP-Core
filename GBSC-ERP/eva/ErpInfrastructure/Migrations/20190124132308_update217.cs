using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update217 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BenefitId",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalaryCalculationTypeId",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_AllowanceDeductionId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "AllowanceDeductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_BenefitId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_SalaryCalculationTypeId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "SalaryCalculationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "AllowanceDeductionId",
                principalTable: "Hr_Payroll_AllowanceDeduction",
                principalColumn: "AllowanceDeductionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_Benefit_BenefitId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "BenefitId",
                principalTable: "Hr_Payroll_Benefit",
                principalColumn: "BenefitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_SalaryCalculationType_SalaryCalculationTypeId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "SalaryCalculationTypeId",
                principalTable: "Hr_Payroll_SalaryCalculationType",
                principalColumn: "SalaryCalculationTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_Benefit_BenefitId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_SalaryCalculationType_SalaryCalculationTypeId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_AllowanceDeductionId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_BenefitId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_SalaryCalculationTypeId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropColumn(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropColumn(
                name: "BenefitId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropColumn(
                name: "SalaryCalculationTypeId",
                table: "Hr_Payroll_MasterPayrollDetails");
        }
    }
}
