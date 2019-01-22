using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update198 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MuInPu",
                table: "Inv_Setup_InventoryItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuInRu",
                table: "Inv_Setup_InventoryItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuInSu",
                table: "Inv_Setup_InventoryItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PackageUnitId",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RegularDiscount",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_InventoryItem_PackageUnitId",
                table: "Inv_Setup_InventoryItem",
                column: "PackageUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_PackageUnitId",
                table: "Inv_Setup_InventoryItem",
                column: "PackageUnitId",
                principalTable: "Inv_Setup_Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_PackageUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_InventoryItem_PackageUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "MuInPu",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "MuInRu",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "MuInSu",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "PackageUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "RegularDiscount",
                table: "Inv_Setup_InventoryItem");
        }
    }
}
