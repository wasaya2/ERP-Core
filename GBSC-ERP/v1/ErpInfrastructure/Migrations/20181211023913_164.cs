using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class _164 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
    name: "FK_Inv_Setup_Area_Sys_City_CityId",
    table: "Inv_Setup_Area",
    column: "CityId",
    principalTable: "Sys_City",
    principalColumn: "CityId",
    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
    name: "FK_Inv_Setup_Area_Sys_City_CityId",
    table: "Inv_Setup_Area");
        }
    }
}
