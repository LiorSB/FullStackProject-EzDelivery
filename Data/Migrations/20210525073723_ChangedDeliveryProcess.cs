using Microsoft.EntityFrameworkCore.Migrations;

namespace EzD_App.Data.Migrations
{
    public partial class ChangedDeliveryProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryGuy_CreditCard_CCNum",
                table: "DeliveryGuy");

            migrationBuilder.DropTable(
                name: "DeliveryGuyPackage");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryGuy_CCNum",
                table: "DeliveryGuy");

            migrationBuilder.DropColumn(
                name: "CCNum",
                table: "DeliveryGuy");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryGuyID",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Credits",
                table: "DeliveryGuy",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "ApprovedDelivery",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChosenDeliveryGuyDeliveryGuyID = table.Column<int>(type: "int", nullable: true),
                    PackageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedDelivery", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK_ApprovedDelivery_DeliveryGuy_ChosenDeliveryGuyDeliveryGuyID",
                        column: x => x.ChosenDeliveryGuyDeliveryGuyID,
                        principalTable: "DeliveryGuy",
                        principalColumn: "DeliveryGuyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovedDelivery_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "PackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryProposal",
                columns: table => new
                {
                    ProposalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntrestedDeliveryGuyDeliveryGuyID = table.Column<int>(type: "int", nullable: true),
                    PackageID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryProposal", x => x.ProposalID);
                    table.ForeignKey(
                        name: "FK_DeliveryProposal_DeliveryGuy_IntrestedDeliveryGuyDeliveryGuyID",
                        column: x => x.IntrestedDeliveryGuyDeliveryGuyID,
                        principalTable: "DeliveryGuy",
                        principalColumn: "DeliveryGuyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryProposal_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "PackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_DeliveryGuyID",
                table: "User",
                column: "DeliveryGuyID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedDelivery_ChosenDeliveryGuyDeliveryGuyID",
                table: "ApprovedDelivery",
                column: "ChosenDeliveryGuyDeliveryGuyID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedDelivery_PackageID",
                table: "ApprovedDelivery",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProposal_IntrestedDeliveryGuyDeliveryGuyID",
                table: "DeliveryProposal",
                column: "IntrestedDeliveryGuyDeliveryGuyID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProposal_PackageID",
                table: "DeliveryProposal",
                column: "PackageID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_DeliveryGuy_DeliveryGuyID",
                table: "User",
                column: "DeliveryGuyID",
                principalTable: "DeliveryGuy",
                principalColumn: "DeliveryGuyID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_DeliveryGuy_DeliveryGuyID",
                table: "User");

            migrationBuilder.DropTable(
                name: "ApprovedDelivery");

            migrationBuilder.DropTable(
                name: "DeliveryProposal");

            migrationBuilder.DropIndex(
                name: "IX_User_DeliveryGuyID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryGuyID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "DeliveryGuy");

            migrationBuilder.AddColumn<string>(
                name: "CCNum",
                table: "DeliveryGuy",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryGuy_CreditCard_CCNum",
                table: "DeliveryGuy",
                column: "CCNum",
                principalTable: "CreditCard",
                principalColumn: "CCNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
