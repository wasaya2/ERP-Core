using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoanStop",
                table: "Hr_Loan_UserLoan",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanStopFrom",
                table: "Hr_Loan_UserLoan",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanStopTill",
                table: "Hr_Loan_UserLoan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoanStop",
                table: "Hr_Loan_UserLoan");

            migrationBuilder.DropColumn(
                name: "LoanStopFrom",
                table: "Hr_Loan_UserLoan");

            migrationBuilder.DropColumn(
                name: "LoanStopTill",
                table: "Hr_Loan_UserLoan");
        }
    }
}
