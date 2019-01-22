using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update196 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EditedBy",
                table: "Finance_VoucherDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "Finance_VoucherDetail");
        }
    }
}
