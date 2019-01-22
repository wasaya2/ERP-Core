using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update191 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ETracker_GeneralSKU");

            migrationBuilder.CreateTable(
                name: "Inv_Setup_GeneralSKU",
                columns: table => new
                {
                    GeneralSKUId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Setup_GeneralSKU", x => x.GeneralSKUId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inv_Setup_GeneralSKU");

            migrationBuilder.CreateTable(
                name: "ETracker_GeneralSKU",
                columns: table => new
                {
                    GeneralSKUId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_GeneralSKU", x => x.GeneralSKUId);
                });
        }
    }
}
