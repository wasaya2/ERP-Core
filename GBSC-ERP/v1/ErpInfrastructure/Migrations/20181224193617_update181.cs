using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update181 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserLevel",
                table: "Sys_User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Sys_City",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Inv_Setup_Region",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Inv_Setup_Area",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_City_UserId",
                table: "Sys_City",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Territory_UserId",
                table: "Inv_Setup_Territory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Region_UserId",
                table: "Inv_Setup_Region",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Area_UserId",
                table: "Inv_Setup_Area",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Area_Sys_User_UserId",
                table: "Inv_Setup_Area",
                column: "UserId",
                principalTable: "Sys_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Region_Sys_User_UserId",
                table: "Inv_Setup_Region",
                column: "UserId",
                principalTable: "Sys_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Territory_Sys_User_UserId",
                table: "Inv_Setup_Territory",
                column: "UserId",
                principalTable: "Sys_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_City_Sys_User_UserId",
                table: "Sys_City",
                column: "UserId",
                principalTable: "Sys_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Area_Sys_User_UserId",
                table: "Inv_Setup_Area");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Region_Sys_User_UserId",
                table: "Inv_Setup_Region");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Territory_Sys_User_UserId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropForeignKey(
                name: "FK_Sys_City_Sys_User_UserId",
                table: "Sys_City");

            migrationBuilder.DropIndex(
                name: "IX_Sys_City_UserId",
                table: "Sys_City");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_Territory_UserId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_Region_UserId",
                table: "Inv_Setup_Region");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_Area_UserId",
                table: "Inv_Setup_Area");

            migrationBuilder.DropColumn(
                name: "UserLevel",
                table: "Sys_User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sys_City");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inv_Setup_Region");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inv_Setup_Area");
        }
    }
}
