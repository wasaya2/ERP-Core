using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update215 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hims_LaproscopyFS",
                columns: table => new
                {
                    LaproscopyFSId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anesthetic = table.Column<string>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Heading1 = table.Column<string>(nullable: true),
                    Heading2 = table.Column<string>(nullable: true),
                    Heading3 = table.Column<string>(nullable: true),
                    Indications = table.Column<string>(nullable: true),
                    LMPDate = table.Column<DateTime>(nullable: false),
                    LaproscopyFsDate = table.Column<DateTime>(nullable: false),
                    OperationsNote1 = table.Column<string>(nullable: true),
                    OperationsNote2 = table.Column<string>(nullable: true),
                    OperationsNote3 = table.Column<string>(nullable: true),
                    OperationsNote4 = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    ProcedureId = table.Column<long>(nullable: true),
                    Surgeon2Id = table.Column<long>(nullable: true),
                    SurgeonId = table.Column<long>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_LaproscopyFS", x => x.LaproscopyFSId);
                    table.ForeignKey(
                        name: "FK_Hims_LaproscopyFS_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_LaproscopyFS_Hims_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Hims_Procedure",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_LaproscopyFS_Hims_Consultant_Surgeon2Id",
                        column: x => x.Surgeon2Id,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_LaproscopyFS_Hims_Consultant_SurgeonId",
                        column: x => x.SurgeonId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hims_LaproscopySp",
                columns: table => new
                {
                    LaproscopySpId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    Cervix = table.Column<string>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Heading = table.Column<string>(nullable: true),
                    Indications = table.Column<string>(nullable: true),
                    LDyeSpill = table.Column<string>(nullable: true),
                    LFallopianTube = table.Column<string>(nullable: true),
                    LaproscopySpDate = table.Column<DateTime>(nullable: false),
                    LeftOvary = table.Column<string>(nullable: true),
                    OtherFindings = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PouchofDouglas = table.Column<string>(nullable: true),
                    ProcedureId = table.Column<long>(nullable: true),
                    RDyeSpill = table.Column<string>(nullable: true),
                    RFallopianTube = table.Column<string>(nullable: true),
                    RighOvary = table.Column<string>(nullable: true),
                    SurgeonId = table.Column<long>(nullable: true),
                    UterovesicalPouch = table.Column<string>(nullable: true),
                    Uterus = table.Column<string>(nullable: true),
                    Vagina = table.Column<string>(nullable: true),
                    Vulva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_LaproscopySp", x => x.LaproscopySpId);
                    table.ForeignKey(
                        name: "FK_Hims_LaproscopySp_Hims_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Hims_Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_LaproscopySp_Hims_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Hims_Procedure",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hims_LaproscopySp_Hims_Consultant_SurgeonId",
                        column: x => x.SurgeonId,
                        principalTable: "Hims_Consultant",
                        principalColumn: "ConsultantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hims_MedicineRequest",
                columns: table => new
                {
                    MedicineRequestId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_MedicineRequest", x => x.MedicineRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Hims_OtEquipment",
                columns: table => new
                {
                    OtEquipmentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_OtEquipment", x => x.OtEquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Hims_OtProcedure",
                columns: table => new
                {
                    OtProcedureId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_OtProcedure", x => x.OtProcedureId);
                });

            migrationBuilder.CreateTable(
                name: "Hims_OtTerminology",
                columns: table => new
                {
                    OtTerminologyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hims_OtTerminology", x => x.OtTerminologyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hims_LaproscopyFS_PatientId",
                table: "Hims_LaproscopyFS",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_LaproscopyFS_ProcedureId",
                table: "Hims_LaproscopyFS",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_LaproscopyFS_Surgeon2Id",
                table: "Hims_LaproscopyFS",
                column: "Surgeon2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_LaproscopyFS_SurgeonId",
                table: "Hims_LaproscopyFS",
                column: "SurgeonId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_LaproscopySp_PatientId",
                table: "Hims_LaproscopySp",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_LaproscopySp_ProcedureId",
                table: "Hims_LaproscopySp",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Hims_LaproscopySp_SurgeonId",
                table: "Hims_LaproscopySp",
                column: "SurgeonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hims_LaproscopyFS");

            migrationBuilder.DropTable(
                name: "Hims_LaproscopySp");

            migrationBuilder.DropTable(
                name: "Hims_MedicineRequest");

            migrationBuilder.DropTable(
                name: "Hims_OtEquipment");

            migrationBuilder.DropTable(
                name: "Hims_OtProcedure");

            migrationBuilder.DropTable(
                name: "Hims_OtTerminology");
        }
    }
}
