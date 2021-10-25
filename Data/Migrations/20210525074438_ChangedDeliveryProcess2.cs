using Microsoft.EntityFrameworkCore.Migrations;

namespace EzD_App.Data.Migrations
{
    public partial class ChangedDeliveryProcess2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "DeliveryProposal",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "ApprovedDelivery",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ApprovedDelivery");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "DeliveryProposal",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
