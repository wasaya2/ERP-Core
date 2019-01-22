using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update197 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_UnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Sys_User_Hr_Payroll_MasterPayroll_MasterPayrollId",
                table: "Sys_User");

            migrationBuilder.DropIndex(
                name: "IX_Sys_User_MasterPayrollId",
                table: "Sys_User");

            migrationBuilder.DropColumn(
                name: "MasterPayrollId",
                table: "Sys_User");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Inv_Setup_ProductType",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Inv_Setup_PackageType",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Inv_Setup_InventoryItem",
                newName: "SalesUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Setup_InventoryItem_UnitId",
                table: "Inv_Setup_InventoryItem",
                newName: "IX_Inv_Setup_InventoryItem_SalesUnitId");

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Inv_Setup_Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Inv_Setup_PackType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Inv_Setup_PackSize",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCp",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MeasurementUnitId",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentProductId",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RateUnitId",
                table: "Inv_Setup_InventoryItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Inv_Setup_Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Inv_Setup_Brand",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Hr_Payroll_MasterPayroll",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_InventoryItem_MeasurementUnitId",
                table: "Inv_Setup_InventoryItem",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_InventoryItem_ParentProductId",
                table: "Inv_Setup_InventoryItem",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_InventoryItem_RateUnitId",
                table: "Inv_Setup_InventoryItem",
                column: "RateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Payroll_MasterPayroll_UserId",
                table: "Hr_Payroll_MasterPayroll",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Payroll_MasterPayroll_Sys_User_UserId",
                table: "Hr_Payroll_MasterPayroll",
                column: "UserId",
                principalTable: "Sys_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_MeasurementUnitId",
                table: "Inv_Setup_InventoryItem",
                column: "MeasurementUnitId",
                principalTable: "Inv_Setup_Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_InventoryItem_ParentProductId",
                table: "Inv_Setup_InventoryItem",
                column: "ParentProductId",
                principalTable: "Inv_Setup_InventoryItem",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_RateUnitId",
                table: "Inv_Setup_InventoryItem",
                column: "RateUnitId",
                principalTable: "Inv_Setup_Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_SalesUnitId",
                table: "Inv_Setup_InventoryItem",
                column: "SalesUnitId",
                principalTable: "Inv_Setup_Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Payroll_MasterPayroll_Sys_User_UserId",
                table: "Hr_Payroll_MasterPayroll");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_MeasurementUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_InventoryItem_ParentProductId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_RateUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_SalesUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_InventoryItem_MeasurementUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_InventoryItem_ParentProductId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_InventoryItem_RateUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Payroll_MasterPayroll_UserId",
                table: "Hr_Payroll_MasterPayroll");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Inv_Setup_Units");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Inv_Setup_PackType");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Inv_Setup_PackSize");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "IsCp",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "ParentProductId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "RateUnitId",
                table: "Inv_Setup_InventoryItem");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Inv_Setup_Category");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Inv_Setup_Brand");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hr_Payroll_MasterPayroll");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Inv_Setup_ProductType",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Inv_Setup_PackageType",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "SalesUnitId",
                table: "Inv_Setup_InventoryItem",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Setup_InventoryItem_SalesUnitId",
                table: "Inv_Setup_InventoryItem",
                newName: "IX_Inv_Setup_InventoryItem_UnitId");

            migrationBuilder.AddColumn<long>(
                name: "MasterPayrollId",
                table: "Sys_User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_MasterPayrollId",
                table: "Sys_User",
                column: "MasterPayrollId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_InventoryItem_Inv_Setup_Units_UnitId",
                table: "Inv_Setup_InventoryItem",
                column: "UnitId",
                principalTable: "Inv_Setup_Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_User_Hr_Payroll_MasterPayroll_MasterPayrollId",
                table: "Sys_User",
                column: "MasterPayrollId",
                principalTable: "Hr_Payroll_MasterPayroll",
                principalColumn: "MasterPayrollId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
