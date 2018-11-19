using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update146 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_Patient_Hims_PatientPackage_PatientPackageId",
                table: "Hims_Patient");

            migrationBuilder.DropIndex(
                name: "IX_Hims_Patient_PatientPackageId",
                table: "Hims_Patient");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientPackage_PatientId",
                table: "Hims_PatientPackage",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_PatientPackage_Hims_Patient_PatientId",
                table: "Hims_PatientPackage",
                column: "PatientId",
                principalTable: "Hims_Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_PatientPackage_Hims_Patient_PatientId",
                table: "Hims_PatientPackage");

            migrationBuilder.DropIndex(
                name: "IX_Hims_PatientPackage_PatientId",
                table: "Hims_PatientPackage");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_Patient_PatientPackageId",
                table: "Hims_Patient",
                column: "PatientPackageId",
                unique: true,
                filter: "[PatientPackageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_Patient_Hims_PatientPackage_PatientPackageId",
                table: "Hims_Patient",
                column: "PatientPackageId",
                principalTable: "Hims_PatientPackage",
                principalColumn: "PatientPackageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
