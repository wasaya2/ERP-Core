using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update167 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_FreezePrepration_Hims_Biopsy_BiopsyId",
                table: "Hims_FreezePrepration");

            migrationBuilder.DropIndex(
                name: "IX_Hims_FreezePrepration_BiopsyId",
                table: "Hims_FreezePrepration");

            migrationBuilder.DropColumn(
                name: "BiopsyId",
                table: "Hims_FreezePrepration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BiopsyId",
                table: "Hims_FreezePrepration",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hims_FreezePrepration_BiopsyId",
                table: "Hims_FreezePrepration",
                column: "BiopsyId",
                unique: true,
                filter: "[BiopsyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_FreezePrepration_Hims_Biopsy_BiopsyId",
                table: "Hims_FreezePrepration",
                column: "BiopsyId",
                principalTable: "Hims_Biopsy",
                principalColumn: "BiopsyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
