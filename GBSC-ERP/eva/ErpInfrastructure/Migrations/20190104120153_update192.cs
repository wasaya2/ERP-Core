using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update192 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserStopSalary",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    StopSalaryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStopSalary", x => new { x.UserId, x.StopSalaryId });
                    table.ForeignKey(
                        name: "FK_UserStopSalary_Hr_Payroll_StopSalary_StopSalaryId",
                        column: x => x.StopSalaryId,
                        principalTable: "Hr_Payroll_StopSalary",
                        principalColumn: "StopSalaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStopSalary_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStopSalary_StopSalaryId",
                table: "UserStopSalary",
                column: "StopSalaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStopSalary");
        }
    }
}
