using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update175 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "ETracker_CompetatorStocks");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ETracker_OrderTaking",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "NoOrderReason",
                table: "ETracker_OrderTaking",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ETracker_CompetatorStocks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "InventoryItemId",
                table: "ETracker_CompetatorStocks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_CompetatorStocks_InventoryItemId",
                table: "ETracker_CompetatorStocks",
                column: "InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ETracker_CompetatorStocks_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_CompetatorStocks",
                column: "InventoryItemId",
                principalTable: "Inv_Setup_InventoryItem",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ETracker_CompetatorStocks_Inv_Setup_InventoryItem_InventoryItemId",
                table: "ETracker_CompetatorStocks");

            migrationBuilder.DropIndex(
                name: "IX_ETracker_CompetatorStocks_InventoryItemId",
                table: "ETracker_CompetatorStocks");

            migrationBuilder.DropColumn(
                name: "NoOrderReason",
                table: "ETracker_OrderTaking");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "ETracker_CompetatorStocks");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ETracker_OrderTaking",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ETracker_CompetatorStocks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "ETracker_CompetatorStocks",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
