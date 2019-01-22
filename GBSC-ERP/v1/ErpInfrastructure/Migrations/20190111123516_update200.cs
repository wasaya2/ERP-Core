using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "From",
                table: "Hr_Payroll_TaxSchedule",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "To",
                table: "Hr_Payroll_TaxSchedule",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "From",
                table: "Hr_Payroll_TaxRelief",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "To",
                table: "Hr_Payroll_TaxRelief",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Hr_Payroll_TaxSchedule");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Hr_Payroll_TaxSchedule");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Hr_Payroll_TaxRelief");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Hr_Payroll_TaxRelief");
        }
    }
}
