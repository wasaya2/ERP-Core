using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_AllowanceDeduction_Hr_Payroll_AllowanceArrear_AllowanceArrearArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_AllowanceRate_Hr_Payroll_Allowance_AllowanceId",
                table: "Hr_Payroll_AllowanceRate");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_AllowanceRate_AllowanceId",
                table: "Hr_Payroll_AllowanceRate");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_AllowanceDeduction_AllowanceArrearArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction");

            migrationBuilder.DropColumn(
                name: "AllowanceId",
                table: "Hr_Payroll_AllowanceRate");

            migrationBuilder.DropColumn(
                name: "AllowanceArrearArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Hr_Payroll_AllowanceDeduction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AllowanceId",
                table: "Hr_Payroll_AllowanceRate",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AllowanceArrearArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Hr_Payroll_AllowanceDeduction",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_AllowanceRate_AllowanceId",
                table: "Hr_Payroll_AllowanceRate",
                column: "AllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_AllowanceDeduction_AllowanceArrearArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction",
                column: "AllowanceArrearArrearAllowanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_AllowanceDeduction_Hr_Payroll_AllowanceArrear_AllowanceArrearArrearAllowanceId",
                table: "Hr_Payroll_AllowanceDeduction",
                column: "AllowanceArrearArrearAllowanceId",
                principalTable: "Hr_Payroll_AllowanceArrear",
                principalColumn: "ArrearAllowanceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_AllowanceRate_Hr_Payroll_Allowance_AllowanceId",
                table: "Hr_Payroll_AllowanceRate",
                column: "AllowanceId",
                principalTable: "Hr_Payroll_Allowance",
                principalColumn: "AllowanceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
