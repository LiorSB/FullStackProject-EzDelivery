using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EzD_App.Data.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    CCNum = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CCNum);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadLineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromAddressAddressID = table.Column<int>(type: "int", nullable: true),
                    ToAddressAddressID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SenderIsReceiver = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageID);
                    table.ForeignKey(
                        name: "FK_Packages_Address_FromAddressAddressID",
                        column: x => x.FromAddressAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packages_Address_ToAddressAddressID",
                        column: x => x.ToAddressAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryGuy",
                columns: table => new
                {
                    DeliveryGuyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<float>(type: "real", nullable: false),
                    CCNum = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryGuy", x => x.DeliveryGuyID);
                    table.ForeignKey(
                        name: "FK_DeliveryGuy_CreditCard_CCNum",
                        column: x => x.CCNum,
                        principalTable: "CreditCard",
                        principalColumn: "CCNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryGuyPackage",
                columns: table => new
                {
                    DeliveredPackagesPackageID = table.Column<int>(type: "int", nullable: false),
                    InterestedDeliveryGuysDeliveryGuyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryGuyPackage", x => new { x.DeliveredPackagesPackageID, x.InterestedDeliveryGuysDeliveryGuyID });
                    table.ForeignKey(
                        name: "FK_DeliveryGuyPackage_DeliveryGuy_InterestedDeliveryGuysDeliveryGuyID",
                        column: x => x.InterestedDeliveryGuysDeliveryGuyID,
                        principalTable: "DeliveryGuy",
                        principalColumn: "DeliveryGuyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryGuyPackage_Packages_DeliveredPackagesPackageID",
                        column: x => x.DeliveredPackagesPackageID,
                        principalTable: "Packages",
                        principalColumn: "PackageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryGuy_CCNum",
                table: "DeliveryGuy",
                column: "CCNum");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryGuyPackage_InterestedDeliveryGuysDeliveryGuyID",
                table: "DeliveryGuyPackage",
                column: "InterestedDeliveryGuysDeliveryGuyID");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_FromAddressAddressID",
                table: "Packages",
                column: "FromAddressAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ToAddressAddressID",
                table: "Packages",
                column: "ToAddressAddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryGuyPackage");

            migrationBuilder.DropTable(
                name: "DeliveryGuy");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
