using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update199 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Hr_Payroll_TaxSchedule");

            migrationBuilder.DropColumn(
                name: "Till",
                table: "Hr_Payroll_TaxSchedule");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Hr_Payroll_TaxRelief");

            migrationBuilder.DropColumn(
                name: "Till",
                table: "Hr_Payroll_TaxRelief");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Inv_Setup_Units",
                newName: "UnitCode");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Inv_Setup_ProductType",
                newName: "ProductTypeCode");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Inv_Setup_PackType",
                newName: "PackTypeCode");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Inv_Setup_PackSize",
                newName: "PackSizeCode");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Inv_Setup_Category",
                newName: "InventoryItemCategoryCode");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Inv_Setup_Brand",
                newName: "BrandCode");

            migrationBuilder.AddColumn<string>(
                name: "PackCategoryCode",
                table: "Inv_Setup_PackCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageTypeCode",
                table: "Inv_Setup_PackageType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SKUCode",
                table: "Inv_Setup_GeneralSKU",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackCategoryCode",
                table: "Inv_Setup_PackCategory");

            migrationBuilder.DropColumn(
                name: "PackageTypeCode",
                table: "Inv_Setup_PackageType");

            migrationBuilder.DropColumn(
                name: "SKUCode",
                table: "Inv_Setup_GeneralSKU");

            migrationBuilder.RenameColumn(
                name: "UnitCode",
                table: "Inv_Setup_Units",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "ProductTypeCode",
                table: "Inv_Setup_ProductType",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "PackTypeCode",
                table: "Inv_Setup_PackType",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "PackSizeCode",
                table: "Inv_Setup_PackSize",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "InventoryItemCategoryCode",
                table: "Inv_Setup_Category",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "BrandCode",
                table: "Inv_Setup_Brand",
                newName: "ItemCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Hr_Payroll_TaxSchedule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Till",
                table: "Hr_Payroll_TaxSchedule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Hr_Payroll_TaxRelief",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Till",
                table: "Hr_Payroll_TaxRelief",
                nullable: true);
        }
    }
}
