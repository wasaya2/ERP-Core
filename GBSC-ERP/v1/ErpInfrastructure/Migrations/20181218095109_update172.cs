using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update172 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Finance_POstedVoucher",
                table: "Finance_POstedVoucher");

            migrationBuilder.RenameTable(
                name: "Finance_POstedVoucher",
                newName: "Finance_PostedVoucher");

            migrationBuilder.AddColumn<double>(
                name: "AccountBalanceAmountAfterPosting",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AccountBalanceAmountBeforePosting",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finance_PostedVoucher",
                table: "Finance_PostedVoucher",
                column: "PostedVoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Finance_PostedVoucher",
                table: "Finance_PostedVoucher");

            migrationBuilder.DropColumn(
                name: "AccountBalanceAmountAfterPosting",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "AccountBalanceAmountBeforePosting",
                table: "Finance_VoucherDetail");

            migrationBuilder.RenameTable(
                name: "Finance_PostedVoucher",
                newName: "Finance_POstedVoucher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finance_POstedVoucher",
                table: "Finance_POstedVoucher",
                column: "PostedVoucherId");
        }
    }
}
