using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update161 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hr_Attendance_AssignRosterShift");

            migrationBuilder.AddColumn<long>(
                name: "ShiftsId",
                table: "Hr_Attendance_AssignRoster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_AssignRoster_ShiftsId",
                table: "Hr_Attendance_AssignRoster",
                column: "ShiftsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Attendance_AssignRoster_Hr_Attendance_Shift_ShiftsId",
                table: "Hr_Attendance_AssignRoster",
                column: "ShiftsId",
                principalTable: "Hr_Attendance_Shift",
                principalColumn: "ShiftsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Attendance_AssignRoster_Hr_Attendance_Shift_ShiftsId",
                table: "Hr_Attendance_AssignRoster");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Attendance_AssignRoster_ShiftsId",
                table: "Hr_Attendance_AssignRoster");

            migrationBuilder.DropColumn(
                name: "ShiftsId",
                table: "Hr_Attendance_AssignRoster");

            migrationBuilder.CreateTable(
                name: "Hr_Attendance_AssignRosterShift",
                columns: table => new
                {
                    AssignRosterId = table.Column<long>(nullable: false),
                    ShiftId = table.Column<long>(nullable: false),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Attendance_AssignRosterShift", x => new { x.AssignRosterId, x.ShiftId });
                    table.ForeignKey(
                        name: "FK_Hr_Attendance_AssignRosterShift_Hr_Attendance_AssignRoster_AssignRosterId",
                        column: x => x.AssignRosterId,
                        principalTable: "Hr_Attendance_AssignRoster",
                        principalColumn: "AssignRosterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hr_Attendance_AssignRosterShift_Hr_Attendance_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Hr_Attendance_Shift",
                        principalColumn: "ShiftsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_AssignRosterShift_ShiftId",
                table: "Hr_Attendance_AssignRosterShift",
                column: "ShiftId");
        }
    }
}
