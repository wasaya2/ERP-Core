using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update225 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCensusDetails",
                table: "ShopCensusDetails");

            migrationBuilder.RenameTable(
                name: "ShopCensusDetails",
                newName: "ETracker_SP_ShopCensusDetail");

            migrationBuilder.AddColumn<bool>(
                name: "IsGeneralBrand",
                table: "Inv_Setup_Brand",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ETracker_SP_ShopCensusDetail",
                table: "ETracker_SP_ShopCensusDetail",
                column: "SerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ETracker_SP_ShopCensusDetail",
                table: "ETracker_SP_ShopCensusDetail");

            migrationBuilder.DropColumn(
                name: "IsGeneralBrand",
                table: "Inv_Setup_Brand");

            migrationBuilder.RenameTable(
                name: "ETracker_SP_ShopCensusDetail",
                newName: "ShopCensusDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCensusDetails",
                table: "ShopCensusDetails",
                column: "SerialNumber");
        }
    }
}
