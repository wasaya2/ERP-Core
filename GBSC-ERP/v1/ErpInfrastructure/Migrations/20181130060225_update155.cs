using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update155 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceRange",
                table: "Hims_BioChemistryTestDetails");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Hims_BioChemistryTest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceRange",
                table: "Hims_BioChemistryTest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Hims_BioChemistryTest");

            migrationBuilder.DropColumn(
                name: "ReferenceRange",
                table: "Hims_BioChemistryTest");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceRange",
                table: "Hims_BioChemistryTestDetails",
                nullable: true);
        }
    }
}
