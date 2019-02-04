using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update218 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_LaproscopyFS_Hims_Procedure_ProcedureId",
                table: "Hims_LaproscopyFS");

            migrationBuilder.DropForeignKey(
                name: "FK_Hims_LaproscopySp_Hims_Procedure_ProcedureId",
                table: "Hims_LaproscopySp");

            migrationBuilder.DropForeignKey(
                name: "FK_Hims_OtPatientCase_Hims_Procedure_ProcedureId",
                table: "Hims_OtPatientCase");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Inventory_InventoryItemId",
                table: "Inv_Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Hims_OtPatientCase_ProcedureId",
                table: "Hims_OtPatientCase");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "Hims_OtPatientCase");

            migrationBuilder.RenameColumn(
                name: "ProcedureId",
                table: "Hims_LaproscopySp",
                newName: "OtProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_Hims_LaproscopySp_ProcedureId",
                table: "Hims_LaproscopySp",
                newName: "IX_Hims_LaproscopySp_OtProcedureId");

            migrationBuilder.RenameColumn(
                name: "ProcedureId",
                table: "Hims_LaproscopyFS",
                newName: "OtProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_Hims_LaproscopyFS_ProcedureId",
                table: "Hims_LaproscopyFS",
                newName: "IX_Hims_LaproscopyFS_OtProcedureId");

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "Hims_OtTerminology",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "Hims_OtProcedure",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "Hims_OtEquipment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "Hims_MedicineRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Inventory_InventoryItemId",
                table: "Inv_Inventory",
                column: "InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_LaproscopyFS_Hims_OtProcedure_OtProcedureId",
                table: "Hims_LaproscopyFS",
                column: "OtProcedureId",
                principalTable: "Hims_OtProcedure",
                principalColumn: "OtProcedureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_LaproscopySp_Hims_OtProcedure_OtProcedureId",
                table: "Hims_LaproscopySp",
                column: "OtProcedureId",
                principalTable: "Hims_OtProcedure",
                principalColumn: "OtProcedureId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_LaproscopyFS_Hims_OtProcedure_OtProcedureId",
                table: "Hims_LaproscopyFS");

            migrationBuilder.DropForeignKey(
                name: "FK_Hims_LaproscopySp_Hims_OtProcedure_OtProcedureId",
                table: "Hims_LaproscopySp");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Inventory_InventoryItemId",
                table: "Inv_Inventory");

            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "Hims_OtTerminology");

            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "Hims_OtProcedure");

            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "Hims_OtEquipment");

            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "Hims_MedicineRequest");

            migrationBuilder.RenameColumn(
                name: "OtProcedureId",
                table: "Hims_LaproscopySp",
                newName: "ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_Hims_LaproscopySp_OtProcedureId",
                table: "Hims_LaproscopySp",
                newName: "IX_Hims_LaproscopySp_ProcedureId");

            migrationBuilder.RenameColumn(
                name: "OtProcedureId",
                table: "Hims_LaproscopyFS",
                newName: "ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_Hims_LaproscopyFS_OtProcedureId",
                table: "Hims_LaproscopyFS",
                newName: "IX_Hims_LaproscopyFS_ProcedureId");

            migrationBuilder.AddColumn<long>(
                name: "InventoryId",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProcedureId",
                table: "Hims_OtPatientCase",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Inventory_InventoryItemId",
                table: "Inv_Inventory",
                column: "InventoryItemId",
                unique: true,
                filter: "[InventoryItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_OtPatientCase_ProcedureId",
                table: "Hims_OtPatientCase",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_LaproscopyFS_Hims_Procedure_ProcedureId",
                table: "Hims_LaproscopyFS",
                column: "ProcedureId",
                principalTable: "Hims_Procedure",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_LaproscopySp_Hims_Procedure_ProcedureId",
                table: "Hims_LaproscopySp",
                column: "ProcedureId",
                principalTable: "Hims_Procedure",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_OtPatientCase_Hims_Procedure_ProcedureId",
                table: "Hims_OtPatientCase",
                column: "ProcedureId",
                principalTable: "Hims_Procedure",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
