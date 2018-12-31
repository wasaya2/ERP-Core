using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update171 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Distributor_Inv_Setup_Territory_TerritoryId",
                table: "Inv_Setup_Distributor");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_Distributor_TerritoryId",
                table: "Inv_Setup_Distributor");

            migrationBuilder.DropColumn(
                name: "TerritoryId",
                table: "Inv_Setup_Distributor");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Territory_DistributorId",
                table: "Inv_Setup_Territory",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Territory_Inv_Setup_Distributor_DistributorId",
                table: "Inv_Setup_Territory",
                column: "DistributorId",
                principalTable: "Inv_Setup_Distributor",
                principalColumn: "DistributorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Territory_Inv_Setup_Distributor_DistributorId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_Territory_DistributorId",
                table: "Inv_Setup_Territory");

            migrationBuilder.AddColumn<long>(
                name: "TerritoryId",
                table: "Inv_Setup_Distributor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Distributor_TerritoryId",
                table: "Inv_Setup_Distributor",
                column: "TerritoryId",
                unique: true,
                filter: "[TerritoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Distributor_Inv_Setup_Territory_TerritoryId",
                table: "Inv_Setup_Distributor",
                column: "TerritoryId",
                principalTable: "Inv_Setup_Territory",
                principalColumn: "TerritoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
