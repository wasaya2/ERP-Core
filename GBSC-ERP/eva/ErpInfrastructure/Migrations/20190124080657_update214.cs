using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update214 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "Inv_SalesOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Inv_SalesOrder",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInternalOrder",
                table: "Inv_SalesOrder",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "Inv_SalesOrder");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Inv_SalesOrder");

            migrationBuilder.DropColumn(
                name: "IsInternalOrder",
                table: "Inv_SalesOrder");
        }
    }
}
