using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update156 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Attendance_UserRosterAttendanceAttendanceFlag_Hr_Attendance_Shift_ShiftsId",
                table: "Hr_Attendance_UserRosterAttendanceAttendanceFlag");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Attendance_UserRosterAttendanceAttendanceFlag_ShiftsId",
                table: "Hr_Attendance_UserRosterAttendanceAttendanceFlag");

            migrationBuilder.DropColumn(
                name: "ShiftsId",
                table: "Hr_Attendance_UserRosterAttendanceAttendanceFlag");

            migrationBuilder.CreateTable(
                name: "Hr_Attendance_ShiftAttendanceFlag",
                columns: table => new
                {
                    ShiftId = table.Column<long>(nullable: false),
                    AttendanceFlagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Attendance_ShiftAttendanceFlag", x => new { x.ShiftId, x.AttendanceFlagId });
                    table.ForeignKey(
                        name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_AttendanceFlag_AttendanceFlagId",
                        column: x => x.AttendanceFlagId,
                        principalTable: "Hr_Attendance_AttendanceFlag",
                        principalColumn: "AttendanceFlagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Hr_Attendance_Shift",
                        principalColumn: "ShiftsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_ShiftAttendanceFlag_AttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "AttendanceFlagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.AddColumn<long>(
                name: "ShiftsId",
                table: "Hr_Attendance_UserRosterAttendanceAttendanceFlag",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_UserRosterAttendanceAttendanceFlag_ShiftsId",
                table: "Hr_Attendance_UserRosterAttendanceAttendanceFlag",
                column: "ShiftsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Attendance_UserRosterAttendanceAttendanceFlag_Hr_Attendance_Shift_ShiftsId",
                table: "Hr_Attendance_UserRosterAttendanceAttendanceFlag",
                column: "ShiftsId",
                principalTable: "Hr_Attendance_Shift",
                principalColumn: "ShiftsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
