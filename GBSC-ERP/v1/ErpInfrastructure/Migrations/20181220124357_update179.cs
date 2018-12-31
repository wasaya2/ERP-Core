using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update179 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTakings_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_InventoryTakings");

            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTakings_Inv_Store_StoreId",
                table: "ETracker_InventoryTakings");

            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTakings_ETracker_StoreVisit_StoreVisitId",
                table: "ETracker_InventoryTakings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ETracker_InventoryTakings",
                table: "ETracker_InventoryTakings");

            migrationBuilder.RenameTable(
                name: "ETracker_InventoryTakings",
                newName: "ETracker_InventoryTaking");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTakings_StoreVisitId",
                table: "ETracker_InventoryTaking",
                newName: "IX_ETracker_InventoryTaking_StoreVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTakings_StoreId",
                table: "ETracker_InventoryTaking",
                newName: "IX_ETracker_InventoryTaking_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTakings_InventoryItemId",
                table: "ETracker_InventoryTaking",
                newName: "IX_ETracker_InventoryTaking_InventoryItemId");

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EditedBy",
                table: "ETracker_InventoryTaking",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ETracker_InventoryTaking",
                table: "ETracker_InventoryTaking",
                column: "InventoryTakingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_InventoryTaking",
                column: "InventoryItemId",
                principalTable: "Inv_Setup_InventoryItem",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Store_StoreId",
                table: "ETracker_InventoryTaking",
                column: "StoreId",
                principalTable: "Inv_Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTaking_ETracker_StoreVisit_StoreVisitId",
                table: "ETracker_InventoryTaking",
                column: "StoreVisitId",
                principalTable: "ETracker_StoreVisit",
                principalColumn: "StoreVisitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTaking_Inv_Store_StoreId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_InventoryTaking_ETracker_StoreVisit_StoreVisitId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ETracker_InventoryTaking",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "ETracker_InventoryTaking");

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "ETracker_InventoryTaking");

            migrationBuilder.RenameTable(
                name: "ETracker_InventoryTaking",
                newName: "ETracker_InventoryTakings");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTaking_StoreVisitId",
                table: "ETracker_InventoryTakings",
                newName: "IX_ETracker_InventoryTakings_StoreVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTaking_StoreId",
                table: "ETracker_InventoryTakings",
                newName: "IX_ETracker_InventoryTakings_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ETracker_InventoryTaking_InventoryItemId",
                table: "ETracker_InventoryTakings",
                newName: "IX_ETracker_InventoryTakings_InventoryItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ETracker_InventoryTakings",
                table: "ETracker_InventoryTakings",
                column: "InventoryTakingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTakings_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_InventoryTakings",
                column: "InventoryItemId",
                principalTable: "Inv_Setup_InventoryItem",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTakings_Inv_Store_StoreId",
                table: "ETracker_InventoryTakings",
                column: "StoreId",
                principalTable: "Inv_Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_InventoryTakings_ETracker_StoreVisit_StoreVisitId",
                table: "ETracker_InventoryTakings",
                column: "StoreVisitId",
                principalTable: "ETracker_StoreVisit",
                principalColumn: "StoreVisitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
