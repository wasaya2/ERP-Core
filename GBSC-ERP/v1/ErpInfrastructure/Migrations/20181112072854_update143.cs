using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update143 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviousAmout",
                table: "Hims_PatientInvoice",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                table: "Hims_PatientInvoice",
                newName: "TotalNetAmount");

            migrationBuilder.RenameColumn(
                name: "BalanceAmount",
                table: "Hims_PatientInvoice",
                newName: "TotalGrossAmount");

            migrationBuilder.RenameColumn(
                name: "AmountToPay",
                table: "Hims_PatientInvoice",
                newName: "TotalDiscountAmount");

            migrationBuilder.AddColumn<double>(
                name: "CreditCardChargesAmount",
                table: "Hims_PatientInvoice",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CreditCardChargesPercentage",
                table: "Hims_PatientInvoice",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LastPaidAmount",
                table: "Hims_PatientInvoice",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmountPaid",
                table: "Hims_PatientInvoice",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalBalance",
                table: "Hims_PatientInvoice",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConsultantId",
                table: "Hims_PatientEmbryology",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmbryologistId",
                table: "Hims_PatientEmbryology",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientEmbryology_ConsultantId",
                table: "Hims_PatientEmbryology",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_PatientEmbryology_EmbryologistId",
                table: "Hims_PatientEmbryology",
                column: "EmbryologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_PatientEmbryology_Hims_Consultant_ConsultantId",
                table: "Hims_PatientEmbryology",
                column: "ConsultantId",
                principalTable: "Hims_Consultant",
                principalColumn: "ConsultantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hims_PatientEmbryology_Hims_Embryologist_EmbryologistId",
                table: "Hims_PatientEmbryology",
                column: "EmbryologistId",
                principalTable: "Hims_Embryologist",
                principalColumn: "EmbryologistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hims_PatientEmbryology_Hims_Consultant_ConsultantId",
                table: "Hims_PatientEmbryology");

            migrationBuilder.DropForeignKey(
                name: "FK_Hims_PatientEmbryology_Hims_Embryologist_EmbryologistId",
                table: "Hims_PatientEmbryology");

            migrationBuilder.DropIndex(
                name: "IX_Hims_PatientEmbryology_ConsultantId",
                table: "Hims_PatientEmbryology");

            migrationBuilder.DropIndex(
                name: "IX_Hims_PatientEmbryology_EmbryologistId",
                table: "Hims_PatientEmbryology");

            migrationBuilder.DropColumn(
                name: "CreditCardChargesAmount",
                table: "Hims_PatientInvoice");

            migrationBuilder.DropColumn(
                name: "CreditCardChargesPercentage",
                table: "Hims_PatientInvoice");

            migrationBuilder.DropColumn(
                name: "LastPaidAmount",
                table: "Hims_PatientInvoice");

            migrationBuilder.DropColumn(
                name: "TotalAmountPaid",
                table: "Hims_PatientInvoice");

            migrationBuilder.DropColumn(
                name: "TotalBalance",
                table: "Hims_PatientInvoice");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Hims_PatientEmbryology");

            migrationBuilder.DropColumn(
                name: "EmbryologistId",
                table: "Hims_PatientEmbryology");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Hims_PatientInvoice",
                newName: "PreviousAmout");

            migrationBuilder.RenameColumn(
                name: "TotalNetAmount",
                table: "Hims_PatientInvoice",
                newName: "PaidAmount");

            migrationBuilder.RenameColumn(
                name: "TotalGrossAmount",
                table: "Hims_PatientInvoice",
                newName: "BalanceAmount");

            migrationBuilder.RenameColumn(
                name: "TotalDiscountAmount",
                table: "Hims_PatientInvoice",
                newName: "AmountToPay");
        }
    }
}
