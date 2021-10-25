using Microsoft.EntityFrameworkCore.Migrations;

namespace EzD_App.Data.Migrations
{
    public partial class UpdatedDeliveryProposalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProposal_DeliveryGuy_IntrestedDeliveryGuyDeliveryGuyID",
                table: "DeliveryProposal");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProposal_Packages_PackageID",
                table: "DeliveryProposal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryProposal",
                table: "DeliveryProposal");

            migrationBuilder.RenameTable(
                name: "DeliveryProposal",
                newName: "DeliveryProposals");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryProposal_PackageID",
                table: "DeliveryProposals",
                newName: "IX_DeliveryProposals_PackageID");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryProposal_IntrestedDeliveryGuyDeliveryGuyID",
                table: "DeliveryProposals",
                newName: "IX_DeliveryProposals_IntrestedDeliveryGuyDeliveryGuyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryProposals",
                table: "DeliveryProposals",
                column: "ProposalID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProposals_DeliveryGuy_IntrestedDeliveryGuyDeliveryGuyID",
                table: "DeliveryProposals",
                column: "IntrestedDeliveryGuyDeliveryGuyID",
                principalTable: "DeliveryGuy",
                principalColumn: "DeliveryGuyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProposals_Packages_PackageID",
                table: "DeliveryProposals",
                column: "PackageID",
                principalTable: "Packages",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProposals_DeliveryGuy_IntrestedDeliveryGuyDeliveryGuyID",
                table: "DeliveryProposals");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProposals_Packages_PackageID",
                table: "DeliveryProposals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryProposals",
                table: "DeliveryProposals");

            migrationBuilder.RenameTable(
                name: "DeliveryProposals",
                newName: "DeliveryProposal");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryProposals_PackageID",
                table: "DeliveryProposal",
                newName: "IX_DeliveryProposal_PackageID");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryProposals_IntrestedDeliveryGuyDeliveryGuyID",
                table: "DeliveryProposal",
                newName: "IX_DeliveryProposal_IntrestedDeliveryGuyDeliveryGuyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryProposal",
                table: "DeliveryProposal",
                column: "ProposalID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProposal_DeliveryGuy_IntrestedDeliveryGuyDeliveryGuyID",
                table: "DeliveryProposal",
                column: "IntrestedDeliveryGuyDeliveryGuyID",
                principalTable: "DeliveryGuy",
                principalColumn: "DeliveryGuyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProposal_Packages_PackageID",
                table: "DeliveryProposal",
                column: "PackageID",
                principalTable: "Packages",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
