using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.RenameColumn(
                name: "InventoryItemId",
                table: "ETracker_InventoryTaking",
                newName: "GeneralSKUId");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTaking_InventoryItemId",
                table: "ETracker_InventoryTaking",
                newName: "IX_ETracker_InventoryTaking_GeneralSKUId");

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Setup_GeneralSKU_GeneralSKUId",
                table: "ETracker_InventoryTaking",
                column: "GeneralSKUId",
                principalTable: "Inv_Setup_GeneralSKU",
                principalColumn: "GeneralSKUId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Setup_GeneralSKU_GeneralSKUId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.RenameColumn(
                name: "GeneralSKUId",
                table: "ETracker_InventoryTaking",
                newName: "InventoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTaking_GeneralSKUId",
                table: "ETracker_InventoryTaking",
                newName: "IX_ETracker_InventoryTaking_InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_InventoryTaking",
                column: "InventoryItemId",
                principalTable: "Inv_Setup_InventoryItem",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
