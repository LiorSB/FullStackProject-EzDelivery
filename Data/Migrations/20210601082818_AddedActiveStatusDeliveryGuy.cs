using Microsoft.EntityFrameworkCore.Migrations;

namespace EzD_App.Data.Migrations
{
    public partial class AddedActiveStatusDeliveryGuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "DeliveryGuy",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "DeliveryGuy");
        }
    }
}
