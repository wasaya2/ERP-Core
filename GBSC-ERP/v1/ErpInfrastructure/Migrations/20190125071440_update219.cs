using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update219 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OtProcedureId",
                table: "Hims_OtPatientCase",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hims_OtPatientCase_OtProcedureId",
                table: "Hims_OtPatientCase",
                column: "OtProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_OtPatientCase_Hims_OtProcedure_OtProcedureId",
                table: "Hims_OtPatientCase",
                column: "OtProcedureId",
                principalTable: "Hims_OtProcedure",
                principalColumn: "OtProcedureId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_OtPatientCase_Hims_OtProcedure_OtProcedureId",
                table: "Hims_OtPatientCase");

            migrationBuilder.DropIndex(
                name: "IX_Hims_OtPatientCase_OtProcedureId",
                table: "Hims_OtPatientCase");

            migrationBuilder.DropColumn(
                name: "OtProcedureId",
                table: "Hims_OtPatientCase");
        }
    }
}
