using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update223 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Hr_Payroll_MonthlyUserSalary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopStatusSummary",
                table: "ETracker_NonproductiveVisitReason",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_MonthlyUserSalary_UserId",
                table: "Hr_Payroll_MonthlyUserSalary",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_MonthlyUserSalary_Sys_User_UserId",
                table: "Hr_Payroll_MonthlyUserSalary",
                column: "UserId",
                principalTable: "Sys_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_MonthlyUserSalary_Sys_User_UserId",
                table: "Hr_Payroll_MonthlyUserSalary");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_MonthlyUserSalary_UserId",
                table: "Hr_Payroll_MonthlyUserSalary");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hr_Payroll_MonthlyUserSalary");

            migrationBuilder.DropColumn(
                name: "ShopStatusSummary",
                table: "ETracker_NonproductiveVisitReason");
        }
    }
}
