using Microsoft.EntityFrameworkCore.Migrations;

namespace EzD_App.Data.Migrations
{
    public partial class NumberOfVotesForDeliveryGuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfVotes",
                table: "DeliveryGuy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfVotes",
                table: "DeliveryGuy");
        }
    }
}
