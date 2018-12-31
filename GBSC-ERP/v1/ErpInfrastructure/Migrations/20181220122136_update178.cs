using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update178 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ETracker_InventoryTakings",
                columns: table => new
                {
                    InventoryTakingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryItemId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    StoreId = table.Column<long>(nullable: true),
                    StoreVisitId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_InventoryTakings", x => x.InventoryTakingId);
                    table.ForeignKey(
                        name: "FK_ETracker_InventoryTakings_Inv_Setup_InventoryItem_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "Inv_Setup_InventoryItem",
                        principalColumn: "InventoryItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ETracker_InventoryTakings_Inv_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Inv_Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ETracker_InventoryTakings_ETracker_StoreVisit_StoreVisitId",
                        column: x => x.StoreVisitId,
                        principalTable: "ETracker_StoreVisit",
                        principalColumn: "StoreVisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_InventoryTakings_InventoryItemId",
                table: "ETracker_InventoryTakings",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_InventoryTakings_StoreId",
                table: "ETracker_InventoryTakings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_InventoryTakings_StoreVisitId",
                table: "ETracker_InventoryTakings",
                column: "StoreVisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ETracker_InventoryTakings");
        }
    }
}
