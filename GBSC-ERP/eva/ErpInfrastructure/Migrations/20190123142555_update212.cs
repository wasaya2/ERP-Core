using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_AllowanceRate",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_AllowanceRate_AllowanceDeductionId",
                table: "Hr_Payroll_AllowanceRate",
                column: "AllowanceDeductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_AllowanceDeduction_ArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction",
                column: "ArrearAllowanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_AllowanceDeduction_Hr_Payroll_AllowanceArrear_ArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction",
                column: "ArrearAllowanceId",
                principalTable: "Hr_Payroll_AllowanceArrear",
                principalColumn: "ArrearAllowanceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_AllowanceRate_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_AllowanceRate",
                column: "AllowanceDeductionId",
                principalTable: "Hr_Payroll_AllowanceDeduction",
                principalColumn: "AllowanceDeductionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_AllowanceDeduction_Hr_Payroll_AllowanceArrear_ArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_AllowanceRate_Hr_Payroll_AllowanceDeduction_AllowanceDeductionId",
                table: "Hr_Payroll_AllowanceRate");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_AllowanceRate_AllowanceDeductionId",
                table: "Hr_Payroll_AllowanceRate");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_AllowanceDeduction_ArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction");

            migrationBuilder.DropColumn(
                name: "AllowanceDeductionId",
                table: "Hr_Payroll_AllowanceRate");

            migrationBuilder.DropColumn(
                name: "ArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction");
        }
    }
}
