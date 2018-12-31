using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update162 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "Hr_UserCompany",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hims_Procedure",
                columns: table => new
                {
                    ProcedureId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    ProcedureCode = table.Column<string>(nullable: true),
                    ProcedureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_Procedure", x => x.ProcedureId);
                });

            migrationBuilder.CreateTable(
                name: "Hims_DailyProcedure",
                columns: table => new
                {
                    DailyProcedureId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedConsultantId = table.Column<long>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DoneByNature = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Nature = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PerformedByConsultantId = table.Column<long>(nullable: true),
                    ProcedureId = table.Column<long>(nullable: true),
                    ProcedureType = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_DailyProcedure", x => x.DailyProcedureId);
                    table.ForeignKey(
                        name: "FK_Hims_DailyProcedure_Hims_Consultant_AssignedConsultantId",
                        column: x => x.AssignedConsultantId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_DailyProcedure_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_DailyProcedure_Hims_Consultant_PerformedByConsultantId",
                        column: x => x.PerformedByConsultantId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_DailyProcedure_Hims_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Hims_Procedure",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_UserCompany_DepartmentId",
                table: "Hr_UserCompany",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_DailyProcedure_AssignedConsultantId",
                table: "Hims_DailyProcedure",
                column: "AssignedConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_DailyProcedure_PatientId",
                table: "Hims_DailyProcedure",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_DailyProcedure_PerformedByConsultantId",
                table: "Hims_DailyProcedure",
                column: "PerformedByConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_DailyProcedure_ProcedureId",
                table: "Hims_DailyProcedure",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_UserCompany_Sys_Department_DepartmentId",
                table: "Hr_UserCompany",
                column: "DepartmentId",
                principalTable: "Sys_Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_UserCompany_Sys_Department_DepartmentId",
                table: "Hr_UserCompany");

            migrationBuilder.DropTable(
                name: "Hims_DailyProcedure");

            migrationBuilder.DropTable(
                name: "Hims_Procedure");

            migrationBuilder.DropIndex(
                name: "IX_Hr_UserCompany_DepartmentId",
                table: "Hr_UserCompany");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Hr_UserCompany");
        }
    }
}
