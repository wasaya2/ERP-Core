using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update216 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_Allowance_AllowanceId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_AllowanceId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropColumn(
                name: "AllowanceId",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Formula",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Formula",
                table: "Hr_Payroll_MasterPayrollDetails");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AllowanceId",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Hr_Payroll_MasterPayrollDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_MasterPayrollDetails_AllowanceId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "AllowanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_MasterPayrollDetails_Hr_Payroll_Allowance_AllowanceId",
                table: "Hr_Payroll_MasterPayrollDetails",
                column: "AllowanceId",
                principalTable: "Hr_Payroll_Allowance",
                principalColumn: "AllowanceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
