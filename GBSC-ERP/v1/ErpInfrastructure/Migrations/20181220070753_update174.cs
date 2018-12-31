using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update174 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "ETracker_OrderTaking");

            migrationBuilder.AddColumn<long>(
                name: "InventoryItemId",
                table: "ETracker_OrderTaking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_OrderTaking_InventoryItemId",
                table: "ETracker_OrderTaking",
                column: "InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_OrderTaking_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_OrderTaking",
                column: "InventoryItemId",
                principalTable: "Inv_Setup_InventoryItem",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_OrderTaking_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_OrderTaking");

            migrationBuilder.DropIndex(
                name: "IX_ETracker_OrderTaking_InventoryItemId",
                table: "ETracker_OrderTaking");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "ETracker_OrderTaking");

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "ETracker_OrderTaking",
                nullable: false,
                defaultValue: "");
        }
    }
}
