using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update154 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Hims_EmbryoFreezeUnthawed",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Hims_EmbryoFreezeThawed",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Hims_EmbryoFreezeUnthawed_PatientId",
                table: "Hims_EmbryoFreezeUnthawed",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_EmbryoFreezeThawed_PatientId",
                table: "Hims_EmbryoFreezeThawed",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_EmbryoFreezeThawed_Hims_Patient_PatientId",
                table: "Hims_EmbryoFreezeThawed",
                column: "PatientId",
                principalTable: "Hims_Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_EmbryoFreezeUnthawed_Hims_Patient_PatientId",
                table: "Hims_EmbryoFreezeUnthawed",
                column: "PatientId",
                principalTable: "Hims_Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_EmbryoFreezeThawed_Hims_Patient_PatientId",
                table: "Hims_EmbryoFreezeThawed");

            migrationBuilder.DropForeignKey(
                name: "FK_Hims_EmbryoFreezeUnthawed_Hims_Patient_PatientId",
                table: "Hims_EmbryoFreezeUnthawed");

            migrationBuilder.DropIndex(
                name: "IX_Hims_EmbryoFreezeUnthawed_PatientId",
                table: "Hims_EmbryoFreezeUnthawed");

            migrationBuilder.DropIndex(
                name: "IX_Hims_EmbryoFreezeThawed_PatientId",
                table: "Hims_EmbryoFreezeThawed");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Hims_EmbryoFreezeUnthawed");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Hims_EmbryoFreezeThawed");
        }
    }
}
