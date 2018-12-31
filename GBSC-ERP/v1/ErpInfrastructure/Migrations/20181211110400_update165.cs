using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update165 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DependantsRelationId",
                table: "Hr_Relation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hr_UserDependantRelation",
                columns: table => new
                {
                    DependantsRelationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_UserDependantRelation", x => x.DependantsRelationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Relation_DependantsRelationId",
                table: "Hr_Relation",
                column: "DependantsRelationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hr_Relation_Hr_UserDependantRelation_DependantsRelationId",
                table: "Hr_Relation",
                column: "DependantsRelationId",
                principalTable: "Hr_UserDependantRelation",
                principalColumn: "DependantsRelationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hr_Relation_Hr_UserDependantRelation_DependantsRelationId",
                table: "Hr_Relation");

            migrationBuilder.DropTable(
                name: "Hr_UserDependantRelation");

            migrationBuilder.DropIndex(
                name: "IX_Hr_Relation_DependantsRelationId",
                table: "Hr_Relation");

            migrationBuilder.DropColumn(
                name: "DependantsRelationId",
                table: "Hr_Relation");
        }
    }
}
