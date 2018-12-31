using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ErpInfrastructure.Migrations
{
    public partial class update163 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_SalesOrder_Inv_Setup_SalesPerson_SalesPersonId",
                table: "Inv_SalesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Area_Inv_Setup_Region_RegionId",
                table: "Inv_Setup_Area");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Customer_Inv_Setup_SalesPerson_SalesPersonId",
                table: "Inv_Setup_Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Territory_Inv_Setup_Area_AreaId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropTable(
                name: "Inv_Setup_SalesPerson");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Setup_Customer_SalesPersonId",
                table: "Inv_Setup_Customer");

            migrationBuilder.DropIndex(
                name: "IX_Inv_SalesOrder_SalesPersonId",
                table: "Inv_SalesOrder");

            migrationBuilder.DropColumn(
                name: "SalesPersonId",
                table: "Inv_Setup_Customer");

            migrationBuilder.DropColumn(
                name: "SalesPersonId",
                table: "Inv_SalesOrder");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Inv_Setup_Area",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Setup_Area_RegionId",
                table: "Inv_Setup_Area",
                newName: "IX_Inv_Setup_Area_CityId");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Hims_PatientInvoiceItem",
                newName: "Exclude");

            migrationBuilder.AddColumn<long>(
                name: "DistributorId",
                table: "Sys_User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SectionId",
                table: "Sys_User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionId",
                table: "Sys_City",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreaId",
                table: "Inv_Setup_Territory",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DistributorId",
                table: "Inv_Setup_Territory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inv_Setup_Section",
                columns: table => new
                {
                    SectionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    TerritoryId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Setup_Section", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Inv_Setup_Section_Inv_Setup_Territory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Inv_Setup_Territory",
                        principalColumn: "TerritoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inv_Setup_Subsection",
                columns: table => new
                {
                    SubsectionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SectionId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Setup_Subsection", x => x.SubsectionId);
                    table.ForeignKey(
                        name: "FK_Inv_Setup_Subsection_Inv_Setup_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Inv_Setup_Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inv_Setup_Subsection_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inv_Store",
                columns: table => new
                {
                    StoreId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveStatus = table.Column<bool>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    Cnic = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DayRegistered = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LandMark = table.Column<string>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    NextScheduledVisit = table.Column<DateTime>(nullable: true),
                    ShopKeeper = table.Column<string>(nullable: true),
                    ShopName = table.Column<string>(maxLength: 30, nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    SubsectionId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Inv_Store_Inv_Setup_Subsection_SubsectionId",
                        column: x => x.SubsectionId,
                        principalTable: "Inv_Setup_Subsection",
                        principalColumn: "SubsectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inv_Store_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ETracker_StoreVisit",
                columns: table => new
                {
                    StoreVisitId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ContactNo = table.Column<string>(maxLength: 20, nullable: true),
                    ContactPersonName = table.Column<string>(maxLength: 60, nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    StoreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_StoreVisit", x => x.StoreVisitId);
                    table.ForeignKey(
                        name: "FK_ETracker_StoreVisit_Inv_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Inv_Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ETracker_VisitDay",
                columns: table => new
                {
                    VisitDayId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    StoreId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_VisitDay", x => x.VisitDayId);
                    table.ForeignKey(
                        name: "FK_ETracker_VisitDay_Inv_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Inv_Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ETracker_CompetatorStocks",
                columns: table => new
                {
                    CompetatorStockId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Item = table.Column<string>(maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StoreVisitId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_CompetatorStocks", x => x.CompetatorStockId);
                    table.ForeignKey(
                        name: "FK_ETracker_CompetatorStocks_ETracker_StoreVisit_StoreVisitId",
                        column: x => x.StoreVisitId,
                        principalTable: "ETracker_StoreVisit",
                        principalColumn: "StoreVisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ETracker_Merchandising",
                columns: table => new
                {
                    MerchandisingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeforeMerchandising = table.Column<bool>(nullable: true),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    StoreVisitId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_Merchandising", x => x.MerchandisingId);
                    table.ForeignKey(
                        name: "FK_ETracker_Merchandising_ETracker_StoreVisit_StoreVisitId",
                        column: x => x.StoreVisitId,
                        principalTable: "ETracker_StoreVisit",
                        principalColumn: "StoreVisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ETracker_OrderTaking",
                columns: table => new
                {
                    OrderTakingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    Item = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StoreId = table.Column<long>(nullable: true),
                    StoreVisitId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_OrderTaking", x => x.OrderTakingId);
                    table.ForeignKey(
                        name: "FK_ETracker_OrderTaking_Inv_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Inv_Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ETracker_OrderTaking_ETracker_StoreVisit_StoreVisitId",
                        column: x => x.StoreVisitId,
                        principalTable: "ETracker_StoreVisit",
                        principalColumn: "StoreVisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ETracker_OutletStock",
                columns: table => new
                {
                    OutletStockId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StoreVisitId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETracker_OutletStock", x => x.OutletStockId);
                    table.ForeignKey(
                        name: "FK_ETracker_OutletStock_ETracker_StoreVisit_StoreVisitId",
                        column: x => x.StoreVisitId,
                        principalTable: "ETracker_StoreVisit",
                        principalColumn: "StoreVisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_DistributorId",
                table: "Sys_User",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_SectionId",
                table: "Sys_User",
                column: "SectionId",
                unique: true,
                filter: "[SectionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_City_RegionId",
                table: "Sys_City",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_CompetatorStocks_StoreVisitId",
                table: "ETracker_CompetatorStocks",
                column: "StoreVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_Merchandising_StoreVisitId",
                table: "ETracker_Merchandising",
                column: "StoreVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_OrderTaking_StoreId",
                table: "ETracker_OrderTaking",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_OrderTaking_StoreVisitId",
                table: "ETracker_OrderTaking",
                column: "StoreVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_OutletStock_StoreVisitId",
                table: "ETracker_OutletStock",
                column: "StoreVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_StoreVisit_StoreId",
                table: "ETracker_StoreVisit",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ETracker_VisitDay_StoreId",
                table: "ETracker_VisitDay",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Section_TerritoryId",
                table: "Inv_Setup_Section",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Subsection_SectionId",
                table: "Inv_Setup_Subsection",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Subsection_UserId",
                table: "Inv_Setup_Subsection",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Store_SubsectionId",
                table: "Inv_Store",
                column: "SubsectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Store_UserId",
                table: "Inv_Store",
                column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Inv_Setup_Area_Sys_City_CityId",
            //    table: "Inv_Setup_Area",
            //    column: "CityId",
            //    principalTable: "Sys_City",
            //    principalColumn: "CityId",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Territory_Inv_Setup_Area_AreaId",
                table: "Inv_Setup_Territory",
                column: "AreaId",
                principalTable: "Inv_Setup_Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_City_Inv_Setup_Region_RegionId",
                table: "Sys_City",
                column: "RegionId",
                principalTable: "Inv_Setup_Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_User_Inv_Setup_Distributor_DistributorId",
                table: "Sys_User",
                column: "DistributorId",
                principalTable: "Inv_Setup_Distributor",
                principalColumn: "DistributorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_User_Inv_Setup_Section_SectionId",
                table: "Sys_User",
                column: "SectionId",
                principalTable: "Inv_Setup_Section",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Setup_Territory_Inv_Setup_Area_AreaId",
                table: "Inv_Setup_Territory");

            migrationBuilder.DropForeignKey(
                name: "FK_Sys_City_Inv_Setup_Region_RegionId",
                table: "Sys_City");

            migrationBuilder.DropForeignKey(
                name: "FK_Sys_User_Inv_Setup_Distributor_DistributorId",
                table: "Sys_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Sys_User_Inv_Setup_Section_SectionId",
                table: "Sys_User");

            migrationBuilder.DropTable(
                name: "ETracker_CompetatorStocks");

            migrationBuilder.DropTable(
                name: "ETracker_Merchandising");

            migrationBuilder.DropTable(
                name: "ETracker_OrderTaking");

            migrationBuilder.DropTable(
                name: "ETracker_OutletStock");

            migrationBuilder.DropTable(
                name: "ETracker_VisitDay");

            migrationBuilder.DropTable(
                name: "ETracker_StoreVisit");

            migrationBuilder.DropTable(
                name: "Inv_Store");

            migrationBuilder.DropTable(
                name: "Inv_Setup_Subsection");

            migrationBuilder.DropTable(
                name: "Inv_Setup_Section");

            migrationBuilder.DropIndex(
                name: "IX_Sys_User_DistributorId",
                table: "Sys_User");

            migrationBuilder.DropIndex(
                name: "IX_Sys_User_SectionId",
                table: "Sys_User");

            migrationBuilder.DropIndex(
                name: "IX_Sys_City_RegionId",
                table: "Sys_City");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Sys_User");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Sys_User");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Sys_City");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Inv_Setup_Territory");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Inv_Setup_Area",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Setup_Area_CityId",
                table: "Inv_Setup_Area",
                newName: "IX_Inv_Setup_Area_RegionId");

            migrationBuilder.RenameColumn(
                name: "Exclude",
                table: "Hims_PatientInvoiceItem",
                newName: "IsPaid");

            migrationBuilder.AlterColumn<long>(
                name: "AreaId",
                table: "Inv_Setup_Territory",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "SalesPersonId",
                table: "Inv_Setup_Customer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalesPersonId",
                table: "Inv_SalesOrder",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inv_Setup_SalesPerson",
                columns: table => new
                {
                    SalesPersonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DistributorId = table.Column<long>(nullable: true),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<long>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    ForeignAddress = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    NIC = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    OfficeAddress = table.Column<string>(nullable: true),
                    OfficeTel = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ResidenceAddress = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Setup_SalesPerson", x => x.SalesPersonId);
                    table.ForeignKey(
                        name: "FK_Inv_Setup_SalesPerson_Inv_Setup_Distributor_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Inv_Setup_Distributor",
                        principalColumn: "DistributorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_Customer_SalesPersonId",
                table: "Inv_Setup_Customer",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_SalesOrder_SalesPersonId",
                table: "Inv_SalesOrder",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Setup_SalesPerson_DistributorId",
                table: "Inv_Setup_SalesPerson",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_SalesOrder_Inv_Setup_SalesPerson_SalesPersonId",
                table: "Inv_SalesOrder",
                column: "SalesPersonId",
                principalTable: "Inv_Setup_SalesPerson",
                principalColumn: "SalesPersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Area_Inv_Setup_Region_RegionId",
                table: "Inv_Setup_Area",
                column: "RegionId",
                principalTable: "Inv_Setup_Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Customer_Inv_Setup_SalesPerson_SalesPersonId",
                table: "Inv_Setup_Customer",
                column: "SalesPersonId",
                principalTable: "Inv_Setup_SalesPerson",
                principalColumn: "SalesPersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Setup_Territory_Inv_Setup_Area_AreaId",
                table: "Inv_Setup_Territory",
                column: "AreaId",
                principalTable: "Inv_Setup_Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
