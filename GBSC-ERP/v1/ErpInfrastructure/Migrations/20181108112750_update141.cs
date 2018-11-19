using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update141 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_PatientInvoiceItem_Hims_Package_PackageId",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Hims_PatientInvoiceItem_Hims_Test_TestId",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropIndex(
                name: "IX_Hims_PatientInvoiceItem_PackageId",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropIndex(
                name: "IX_Hims_PatientInvoiceItem_TestId",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Hims_PatientInvoiceItem",
                newName: "NameId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Inv_Setup_PackageType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hims_PatientInvoiceItem",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercentage",
                table: "Hims_PatientInvoiceItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nature",
                table: "Hims_PatientInvoiceItem",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "Hims_PatientInvoiceItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PatientPackageId",
                table: "Hims_Patient",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Charges",
                table: "Hims_Package",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "Hims_Package",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hims_PatientPackage",
                columns: table => new
                {
                    PatientPackageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    LastPaidAmount = table.Column<double>(nullable: true),
                    LastPaymentDate = table.Column<DateTime>(nullable: true),
                    PackageId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    TotalAmountPaid = table.Column<double>(nullable: true),
                    TotalBalance = table.Column<double>(nullable: true),
                    TotalPrice = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_PatientPackage", x => x.PatientPackageId);
                    table.ForeignKey(
                        name: "FK_Hims_PatientPackage_Hims_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Hims_Package",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_Patient_PatientPackageId",
                table: "Hims_Patient",
                column: "PatientPackageId",
                unique: true,
                filter: "[PatientPackageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientPackage_PackageId",
                table: "Hims_PatientPackage",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_Patient_Hims_PatientPackage_PatientPackageId",
                table: "Hims_Patient",
                column: "PatientPackageId",
                principalTable: "Hims_PatientPackage",
                principalColumn: "PatientPackageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_Patient_Hims_PatientPackage_PatientPackageId",
                table: "Hims_Patient");

            migrationBuilder.DropTable(
                name: "Hims_PatientPackage");

            migrationBuilder.DropIndex(
                name: "IX_Hims_Patient_PatientPackageId",
                table: "Hims_Patient");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Inv_Setup_PackageType");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropColumn(
                name: "Nature",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Hims_PatientInvoiceItem");

            migrationBuilder.DropColumn(
                name: "PatientPackageId",
                table: "Hims_Patient");

            migrationBuilder.DropColumn(
                name: "Charges",
                table: "Hims_Package");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "Hims_Package");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "Hims_PatientInvoiceItem",
                newName: "TestId");

            migrationBuilder.AddColumn<long>(
                name: "PackageId",
                table: "Hims_PatientInvoiceItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientInvoiceItem_PackageId",
                table: "Hims_PatientInvoiceItem",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientInvoiceItem_TestId",
                table: "Hims_PatientInvoiceItem",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_PatientInvoiceItem_Hims_Package_PackageId",
                table: "Hims_PatientInvoiceItem",
                column: "PackageId",
                principalTable: "Hims_Package",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_PatientInvoiceItem_Hims_Test_TestId",
                table: "Hims_PatientInvoiceItem",
                column: "TestId",
                principalTable: "Hims_Test",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
