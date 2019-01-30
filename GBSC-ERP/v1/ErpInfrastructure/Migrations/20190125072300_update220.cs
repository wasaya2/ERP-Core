using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update220 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anesthetic",
                table: "Hims_LaproscopySp",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LMPDate",
                table: "Hims_LaproscopySp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anesthetic",
                table: "Hims_LaproscopySp");

            migrationBuilder.DropColumn(
                name: "LMPDate",
                table: "Hims_LaproscopySp");
        }
    }
}
