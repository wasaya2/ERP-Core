using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update208 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "Inv_PurchaseInvoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorBillNumber",
                table: "Inv_PurchaseInvoice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "Inv_PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "VendorBillNumber",
                table: "Inv_PurchaseInvoice");
        }
    }
}
