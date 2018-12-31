using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update180 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hr_Attendance_Daysoff",
                columns: table => new
                {
                    DaysoffId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignRosterId = table.Column<long>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Dayoff = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Attendance_Daysoff", x => x.DaysoffId);
                    table.ForeignKey(
                        name: "FK_Hr_Attendance_Daysoff_Hr_Attendance_AssignRoster_AssignRosterId",
                        column: x => x.AssignRosterId,
                        principalTable: "Hr_Attendance_AssignRoster",
                        principalColumn: "AssignRosterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_Daysoff_AssignRosterId",
                table: "Hr_Attendance_Daysoff",
                column: "AssignRosterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hr_Attendance_Daysoff");
        }
    }
}
