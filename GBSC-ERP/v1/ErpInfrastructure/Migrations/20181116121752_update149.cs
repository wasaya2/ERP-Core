using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update149 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientInvoiceReturnId",
                table: "Hims_PatientInvoice",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hims_PatientInvoiceReturn",
                columns: table => new
                {
                    PatientInvoiceReturnId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    InvoiceReturnNumber = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PatientInvoiceId = table.Column<long>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ReturnDate = table.Column<DateTime>(nullable: true),
                    TotalReturnAmount = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_PatientInvoiceReturn", x => x.PatientInvoiceReturnId);
                    table.ForeignKey(
                        name: "FK_Hims_PatientInvoiceReturn_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_PatientInvoiceReturn_Hims_PatientInvoice_PatientInvoiceId",
                        column: x => x.PatientInvoiceId,
                        principalTable: "Hims_PatientInvoice",
                        principalColumn: "PatientInvoiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hims_PatientInvoiceReturnItem",
                columns: table => new
                {
                    PatientInvoiceReturnItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DiscountDeductionAmount = table.Column<double>(nullable: true),
                    DiscountPercentage = table.Column<double>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameId = table.Column<long>(nullable: true),
                    Nature = table.Column<string>(nullable: true),
                    PatientInvoiceReturnId = table.Column<long>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ReturnNetAmount = table.Column<double>(nullable: true),
                    ReturnQuantity = table.Column<double>(nullable: true),
                    SaleDiscountAmount = table.Column<double>(nullable: true),
                    SaleGrossAmount = table.Column<double>(nullable: true),
                    SaleNetAmount = table.Column<double>(nullable: true),
                    SaleQuantity = table.Column<double>(nullable: true),
                    UnitPrice = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_PatientInvoiceReturnItem", x => x.PatientInvoiceReturnItemId);
                    table.ForeignKey(
                        name: "FK_Hims_PatientInvoiceReturnItem_Hims_PatientInvoiceReturn_PatientInvoiceReturnId",
                        column: x => x.PatientInvoiceReturnId,
                        principalTable: "Hims_PatientInvoiceReturn",
                        principalColumn: "PatientInvoiceReturnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientInvoiceReturn_PatientId",
                table: "Hims_PatientInvoiceReturn",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientInvoiceReturn_PatientInvoiceId",
                table: "Hims_PatientInvoiceReturn",
                column: "PatientInvoiceId",
                unique: true,
                filter: "[PatientInvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientInvoiceReturnItem_PatientInvoiceReturnId",
                table: "Hims_PatientInvoiceReturnItem",
                column: "PatientInvoiceReturnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hims_PatientInvoiceReturnItem");

            migrationBuilder.DropTable(
                name: "Hims_PatientInvoiceReturn");

            migrationBuilder.DropColumn(
                name: "PatientInvoiceReturnId",
                table: "Hims_PatientInvoice");
        }
    }
}
