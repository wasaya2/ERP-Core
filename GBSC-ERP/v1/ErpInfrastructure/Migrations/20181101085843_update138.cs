using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update138 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Finance_Voucher");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Finance_Voucher");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Finance_VoucherDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "Finance_VoucherDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Finance_VoucherDetail");

            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "Finance_VoucherDetail");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Finance_Voucher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Finance_Voucher",
                nullable: true);
        }
    }
}
