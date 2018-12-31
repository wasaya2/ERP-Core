using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update176 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finance_ProcessedAccountsLedger");

            migrationBuilder.DropTable(
                name: "Finance_UnprocessedAccountsLedger");

            migrationBuilder.RenameColumn(
                name: "UnprocessedAccountsLedgeId",
                table: "Finance_Account",
                newName: "TotalTransactionsAgainstThisAccount");

            migrationBuilder.RenameColumn(
                name: "ProcessedAccountsLedgerId",
                table: "Finance_Account",
                newName: "OldAccountId");

            migrationBuilder.AlterColumn<string>(
                name: "MinimumOverTime",
                table: "Hr_Attendance_Shift",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ClosingBalance",
                table: "Finance_Account",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCredit",
                table: "Finance_Account",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalDebit",
                table: "Finance_Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Finance_TransactionAccount",
                columns: table => new
                {
                    TransactionAccountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountCode = table.Column<string>(nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    AccountLevel = table.Column<long>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CurrentBalance = table.Column<double>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    FinancialYearId = table.Column<long>(nullable: true),
                    OpeningBalance = table.Column<double>(nullable: true),
                    ParentAccountCode = table.Column<string>(nullable: true),
                    TotalCredit = table.Column<double>(nullable: true),
                    TotalDebit = table.Column<double>(nullable: true),
                    TotalTransactionsAgainstThisAccount = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance_TransactionAccount", x => x.TransactionAccountId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finance_TransactionAccount");

            migrationBuilder.DropColumn(
                name: "ClosingBalance",
                table: "Finance_Account");

            migrationBuilder.DropColumn(
                name: "TotalCredit",
                table: "Finance_Account");

            migrationBuilder.DropColumn(
                name: "TotalDebit",
                table: "Finance_Account");

            migrationBuilder.RenameColumn(
                name: "TotalTransactionsAgainstThisAccount",
                table: "Finance_Account",
                newName: "UnprocessedAccountsLedgeId");

            migrationBuilder.RenameColumn(
                name: "OldAccountId",
                table: "Finance_Account",
                newName: "ProcessedAccountsLedgerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MinimumOverTime",
                table: "Hr_Attendance_Shift",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Finance_ProcessedAccountsLedger",
                columns: table => new
                {
                    ProcessedAccountsLedgerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountCode = table.Column<string>(nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    AccountLevel = table.Column<long>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    ClosingBalance = table.Column<double>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    FinancialYearId = table.Column<long>(nullable: true),
                    IsBankAccount = table.Column<bool>(nullable: true),
                    IsGeneralOrDetail = table.Column<bool>(nullable: true),
                    OpeningBalance = table.Column<double>(nullable: true),
                    ParentAccountCode = table.Column<string>(nullable: true),
                    TotalCredit = table.Column<double>(nullable: true),
                    TotalDebit = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance_ProcessedAccountsLedger", x => x.ProcessedAccountsLedgerId);
                });

            migrationBuilder.CreateTable(
                name: "Finance_UnprocessedAccountsLedger",
                columns: table => new
                {
                    UnprocessedAccountsLedgerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountCode = table.Column<string>(nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    AccountLevel = table.Column<long>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CurrentBalance = table.Column<double>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    FinancialYearId = table.Column<long>(nullable: true),
                    IsBankAccount = table.Column<bool>(nullable: true),
                    IsGeneralOrDetail = table.Column<bool>(nullable: true),
                    OpeningBalance = table.Column<double>(nullable: true),
                    ParentAccountCode = table.Column<string>(nullable: true),
                    TotalCredit = table.Column<double>(nullable: true),
                    TotalDebit = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance_UnprocessedAccountsLedger", x => x.UnprocessedAccountsLedgerId);
                });
        }
    }
}
