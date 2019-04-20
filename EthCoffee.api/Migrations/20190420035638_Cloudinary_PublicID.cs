using Microsoft.EntityFrameworkCore.Migrations;

namespace EthCoffee.api.Migrations
{
    public partial class Cloudinary_PublicID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "ListingPhotos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Avatars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "ListingPhotos");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Avatars");
        }
    }
}
