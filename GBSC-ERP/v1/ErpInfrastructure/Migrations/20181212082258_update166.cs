using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update166 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BiopsyId",
                table: "Hims_FreezePrepration",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Finance_Account",
                columns: table => new
                {
                    AccountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountCode = table.Column<string>(nullable: true),
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
                    IsGeneralOrDetail = table.Column<bool>(nullable: true),
                    OpeningBalance = table.Column<double>(nullable: true),
                    ParentAccountCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Finance_Account_Finance_Setup_FinancialYear_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalTable: "Finance_Setup_FinancialYear",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_FreezePrepration_BiopsyId",
                table: "Hims_FreezePrepration",
                column: "BiopsyId",
                unique: true,
                filter: "[BiopsyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Finance_VoucherDetail_AccountId",
                table: "Finance_VoucherDetail",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Finance_Account_FinancialYearId",
                table: "Finance_Account",
                column: "FinancialYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finance_VoucherDetail_Finance_Account_AccountId",
                table: "Finance_VoucherDetail",
                column: "AccountId",
                principalTable: "Finance_Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_FreezePrepration_Hims_Biopsy_BiopsyId",
                table: "Hims_FreezePrepration",
                column: "BiopsyId",
                principalTable: "Hims_Biopsy",
                principalColumn: "BiopsyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finance_VoucherDetail_Finance_Account_AccountId",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Hims_FreezePrepration_Hims_Biopsy_BiopsyId",
                table: "Hims_FreezePrepration");

            migrationBuilder.DropTable(
                name: "Finance_Account");

            migrationBuilder.DropIndex(
                name: "IX_Hims_FreezePrepration_BiopsyId",
                table: "Hims_FreezePrepration");

            migrationBuilder.DropIndex(
                name: "IX_Finance_VoucherDetail_AccountId",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "BiopsyId",
                table: "Hims_FreezePrepration");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Finance_VoucherDetail");
        }
    }
}
