using Microsoft.EntityFrameworkCore.Migrations;

namespace EthCoffee.api.Migrations
{
    public partial class addListingPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Listings",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0.00m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Listings");
        }
    }
}
