using Microsoft.EntityFrameworkCore.Migrations;

namespace Bartender_App.Migrations
{
    public partial class ChangedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "DrinkOrdered",
                table: "Orders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DrinkOrdered",
                value: "Bourbon Old Fashioned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrinkOrdered",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderId",
                value: "1");
        }
    }
}
