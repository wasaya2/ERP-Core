using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update160 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sys_User_Hr_Attendance_AssignRoster_AssignRosterId",
                table: "Sys_User");

            migrationBuilder.DropIndex(
                name: "IX_Sys_User_AssignRosterId",
                table: "Sys_User");

            migrationBuilder.DropColumn(
                name: "AssignRosterId",
                table: "Sys_User");

            migrationBuilder.CreateTable(
                name: "Hr_Attendance_UserAssignRoster",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    AssignRosterId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Attendance_UserAssignRoster", x => new { x.UserId, x.AssignRosterId });
                    table.ForeignKey(
                        name: "FK_Hr_Attendance_UserAssignRoster_Hr_Attendance_AssignRoster_AssignRosterId",
                        column: x => x.AssignRosterId,
                        principalTable: "Hr_Attendance_AssignRoster",
                        principalColumn: "AssignRosterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hr_Attendance_UserAssignRoster_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Attendance_UserAssignRoster_AssignRosterId",
                table: "Hr_Attendance_UserAssignRoster",
                column: "AssignRosterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hr_Attendance_UserAssignRoster");

            migrationBuilder.AddColumn<long>(
                name: "AssignRosterId",
                table: "Sys_User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_AssignRosterId",
                table: "Sys_User",
                column: "AssignRosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_User_Hr_Attendance_AssignRoster_AssignRosterId",
                table: "Sys_User",
                column: "AssignRosterId",
                principalTable: "Hr_Attendance_AssignRoster",
                principalColumn: "AssignRosterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
