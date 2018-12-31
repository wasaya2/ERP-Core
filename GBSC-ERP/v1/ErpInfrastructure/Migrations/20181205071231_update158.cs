using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update158 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_AttendanceFlag_AttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_Shift_ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hr_Attendance_ShiftAttendanceFlag",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "Hr_Attendance_AttendanceFlag");

            migrationBuilder.DropColumn(
                name: "NoOfHours",
                table: "Hr_Attendance_AttendanceFlag");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "Hr_Attendance_AttendanceFlag");

            migrationBuilder.AlterColumn<long>(
                name: "AttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ShiftAttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "FlagTypeId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromTime",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfHours",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToTime",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hr_Attendance_ShiftAttendanceFlag",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "ShiftAttendanceFlagId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_ShiftAttendanceFlag_FlagTypeId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "FlagTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_ShiftAttendanceFlag_ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_AttendanceFlag_AttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "AttendanceFlagId",
                principalTable: "Hr_Attendance_AttendanceFlag",
                principalColumn: "AttendanceFlagId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_FlagType_FlagTypeId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "FlagTypeId",
                principalTable: "Hr_Attendance_FlagType",
                principalColumn: "FlagTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_Shift_ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "ShiftId",
                principalTable: "Hr_Attendance_Shift",
                principalColumn: "ShiftsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_AttendanceFlag_AttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_FlagType_FlagTypeId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_Shift_ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hr_Attendance_ShiftAttendanceFlag",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Attendance_ShiftAttendanceFlag_FlagTypeId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Attendance_ShiftAttendanceFlag_ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropColumn(
                name: "ShiftAttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropColumn(
                name: "FlagTypeId",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropColumn(
                name: "NoOfHours",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "Hr_Attendance_ShiftAttendanceFlag");

            migrationBuilder.AlterColumn<long>(
                name: "ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromTime",
                table: "Hr_Attendance_AttendanceFlag",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfHours",
                table: "Hr_Attendance_AttendanceFlag",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToTime",
                table: "Hr_Attendance_AttendanceFlag",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hr_Attendance_ShiftAttendanceFlag",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                columns: new[] { "ShiftId", "AttendanceFlagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_AttendanceFlag_AttendanceFlagId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "AttendanceFlagId",
                principalTable: "Hr_Attendance_AttendanceFlag",
                principalColumn: "AttendanceFlagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Attendance_ShiftAttendanceFlag_Hr_Attendance_Shift_ShiftId",
                table: "Hr_Attendance_ShiftAttendanceFlag",
                column: "ShiftId",
                principalTable: "Hr_Attendance_Shift",
                principalColumn: "ShiftsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
