using Microsoft.EntityFrameworkCore.Migrations;

namespace EzD_App.Data.Migrations
{
    public partial class updatePackageProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_User_UserID",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Packages",
                newName: "OwnerUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_UserID",
                table: "Packages",
                newName: "IX_Packages_OwnerUserID");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_User_OwnerUserID",
                table: "Packages",
                column: "OwnerUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_User_OwnerUserID",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "OwnerUserID",
                table: "Packages",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_OwnerUserID",
                table: "Packages",
                newName: "IX_Packages_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_User_UserID",
                table: "Packages",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
