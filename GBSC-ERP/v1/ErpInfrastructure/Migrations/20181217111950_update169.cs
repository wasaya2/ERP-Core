using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update169 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EditedBy",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "Inv_Setup_Area",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Inv_Setup_Area",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Inv_Setup_Area",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Inv_Setup_Area",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Inv_Setup_Area",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "Inv_Setup_Area",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EditedBy",
                table: "Inv_Setup_Area",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Inv_Setup_Area");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Inv_Setup_Area");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Inv_Setup_Area");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Inv_Setup_Area");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Inv_Setup_Area");

            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "Inv_Setup_Area");

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "Inv_Setup_Area");
        }
    }
}
