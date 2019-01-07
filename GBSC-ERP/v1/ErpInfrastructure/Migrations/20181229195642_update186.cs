using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update186 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ETracker_PJP",
                columns: table => new
                {
                    PjpId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    NotProductive = table.Column<long>(nullable: true),
                    NotVisited = table.Column<long>(nullable: true),
                    OutOfPjpVisited = table.Column<long>(nullable: true),
                    PjpShops = table.Column<long>(nullable: true),
                    PjpVisited = table.Column<long>(nullable: true),
                    Productive = table.Column<long>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    SubsectionId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    VisitedShop = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_PJP", x => x.PjpId);
                    table.ForeignKey(
                        name: "FK_ETracker_PJP_Inv_Setup_Subsection_SubsectionId",
                        column: x => x.SubsectionId,
                        principalTable: "Inv_Setup_Subsection",
                        principalColumn: "SubsectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ETracker_PJP_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_PJP_SubsectionId",
                table: "ETracker_PJP",
                column: "SubsectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_PJP_UserId",
                table: "ETracker_PJP",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ETracker_PJP");
        }
    }
}
