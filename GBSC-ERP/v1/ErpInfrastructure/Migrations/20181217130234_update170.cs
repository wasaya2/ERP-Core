using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update170 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "Finance_Account");

            migrationBuilder.AddColumn<long>(
                name: "PostedVoucherId",
                table: "Finance_Voucher",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnpostedVoucherId",
                table: "Finance_Voucher",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBankAccount",
                table: "Finance_Account",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Finance_Account",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProcessedAccountsLedgerId",
                table: "Finance_Account",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnprocessedAccountsLedgeId",
                table: "Finance_Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Finance_POstedVoucher",
                columns: table => new
                {
                    PostedVoucherId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    FinancialYearId = table.Column<long>(nullable: true),
                    TotalCreditAmount = table.Column<double>(nullable: true),
                    TotalDebitAmount = table.Column<double>(nullable: true),
                    VoucherCode = table.Column<string>(nullable: true),
                    VoucherId = table.Column<long>(nullable: false),
                    VoucherTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance_POstedVoucher", x => x.PostedVoucherId);
                });

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
                name: "Finance_UnpostedVoucher",
                columns: table => new
                {
                    UnpostedVoucherId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    FinancialYearId = table.Column<long>(nullable: true),
                    TotalCreditAmount = table.Column<double>(nullable: true),
                    TotalDebitAmount = table.Column<double>(nullable: true),
                    VoucherCode = table.Column<string>(nullable: true),
                    VoucherId = table.Column<long>(nullable: false),
                    VoucherTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance_UnpostedVoucher", x => x.UnpostedVoucherId);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finance_POstedVoucher");

            migrationBuilder.DropTable(
                name: "Finance_ProcessedAccountsLedger");

            migrationBuilder.DropTable(
                name: "Finance_UnpostedVoucher");

            migrationBuilder.DropTable(
                name: "Finance_UnprocessedAccountsLedger");

            migrationBuilder.DropColumn(
                name: "PostedVoucherId",
                table: "Finance_Voucher");

            migrationBuilder.DropColumn(
                name: "UnpostedVoucherId",
                table: "Finance_Voucher");

            migrationBuilder.DropColumn(
                name: "IsBankAccount",
                table: "Finance_Account");

            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Finance_Account");

            migrationBuilder.DropColumn(
                name: "ProcessedAccountsLedgerId",
                table: "Finance_Account");

            migrationBuilder.DropColumn(
                name: "UnprocessedAccountsLedgeId",
                table: "Finance_Account");

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalance",
                table: "Finance_Account",
                nullable: true);
        }
    }
}
