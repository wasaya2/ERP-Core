using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update187 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ItemDiscountAmount",
                table: "Inv_SalesIndentItem",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ItemGrossAmount",
                table: "Inv_SalesIndentItem",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ItemNetAmount",
                table: "Inv_SalesIndentItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderTakingId",
                table: "Inv_SalesIndentItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DistributorId",
                table: "Inv_SalesIndent",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Inv_SalesIndent",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StoreVisitId",
                table: "Inv_SalesIndent",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Inv_SalesIndent_DistributorId",
                table: "Inv_SalesIndent",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_SalesIndent_Inv_Setup_Distributor_DistributorId",
                table: "Inv_SalesIndent",
                column: "DistributorId",
                principalTable: "Inv_Setup_Distributor",
                principalColumn: "DistributorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_SalesIndent_Inv_Setup_Distributor_DistributorId",
                table: "Inv_SalesIndent");

            migrationBuilder.DropIndex(
                name: "IX_Inv_SalesIndent_DistributorId",
                table: "Inv_SalesIndent");

            migrationBuilder.DropColumn(
                name: "ItemDiscountAmount",
                table: "Inv_SalesIndentItem");

            migrationBuilder.DropColumn(
                name: "ItemGrossAmount",
                table: "Inv_SalesIndentItem");

            migrationBuilder.DropColumn(
                name: "ItemNetAmount",
                table: "Inv_SalesIndentItem");

            migrationBuilder.DropColumn(
                name: "OrderTakingId",
                table: "Inv_SalesIndentItem");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Inv_SalesIndent");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Inv_SalesIndent");

            migrationBuilder.DropColumn(
                name: "StoreVisitId",
                table: "Inv_SalesIndent");
        }
    }
}
