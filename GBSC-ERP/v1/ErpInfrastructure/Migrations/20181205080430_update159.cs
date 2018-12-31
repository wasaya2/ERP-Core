using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update159 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ReportedMotileCount",
                table: "Hims_SemenAnalysis",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ReportedMotileCount",
                table: "Hims_PatientInsemenation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportedMotileCount",
                table: "Hims_SemenAnalysis");

            migrationBuilder.DropColumn(
                name: "ReportedMotileCount",
                table: "Hims_PatientInsemenation");
        }
    }
}
