using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update182 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sys_User_Inv_Setup_Distributor_DistributorId",
                table: "Sys_User");

            migrationBuilder.DropIndex(
                name: "IX_Sys_User_DistributorId",
                table: "Sys_User");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Sys_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DistributorId",
                table: "Sys_User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_DistributorId",
                table: "Sys_User",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_User_Inv_Setup_Distributor_DistributorId",
                table: "Sys_User",
                column: "DistributorId",
                principalTable: "Inv_Setup_Distributor",
                principalColumn: "DistributorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
