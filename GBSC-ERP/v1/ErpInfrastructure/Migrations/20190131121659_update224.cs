using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update224 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalReturnQuantity",
                table: "Inv_PurchaseReturn",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Hr_Payroll_MasterPayroll",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopCensusDetails",
                columns: table => new
                {
                    SerialNumber = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    CNIC = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(nullable: true),
                    DSF = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    Distributor = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    ShopkeeperName = table.Column<string>(nullable: true),
                    StoreName = table.Column<string>(nullable: true),
                    Subsection = table.Column<string>(nullable: true),
                    Territory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCensusDetails", x => x.SerialNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCensusDetails");

            migrationBuilder.DropColumn(
                name: "TotalReturnQuantity",
                table: "Inv_PurchaseReturn");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Hr_Payroll_MasterPayroll");
        }
    }
}
