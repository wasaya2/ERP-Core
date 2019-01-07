using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update185 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PJP",
                table: "Inv_Store");

            migrationBuilder.AddColumn<bool>(
                name: "PJP",
                table: "ETracker_StoreVisit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PJP",
                table: "ETracker_StoreVisit");

            migrationBuilder.AddColumn<bool>(
                name: "PJP",
                table: "Inv_Store",
                nullable: true);
        }
    }
}
