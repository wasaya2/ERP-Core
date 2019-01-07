using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update189 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssestsAccountId",
                table: "Sys_Company",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EquityAccountId",
                table: "Sys_Company",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ExpenseAccountId",
                table: "Sys_Company",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LiabilitiesAccountId",
                table: "Sys_Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NTN",
                table: "Sys_Company",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RevenueAccountId",
                table: "Sys_Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssestsAccountId",
                table: "Sys_Company");

            migrationBuilder.DropColumn(
                name: "EquityAccountId",
                table: "Sys_Company");

            migrationBuilder.DropColumn(
                name: "ExpenseAccountId",
                table: "Sys_Company");

            migrationBuilder.DropColumn(
                name: "LiabilitiesAccountId",
                table: "Sys_Company");

            migrationBuilder.DropColumn(
                name: "NTN",
                table: "Sys_Company");

            migrationBuilder.DropColumn(
                name: "RevenueAccountId",
                table: "Sys_Company");
        }
    }
}
