using Microsoft.EntityFrameworkCore.Migrations;

namespace EthCoffee.api.Migrations
{
    public partial class addListingWatchEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListingWatchs",
                columns: table => new
                {
                    WatcherId = table.Column<int>(nullable: false),
                    WatchingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingWatchs", x => new { x.WatcherId, x.WatchingId });
                    table.ForeignKey(
                        name: "FK_ListingWatchs_Users_WatcherId",
                        column: x => x.WatcherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListingWatchs_Listings_WatchingId",
                        column: x => x.WatchingId,
                        principalTable: "Listings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingWatchs_WatchingId",
                table: "ListingWatchs",
                column: "WatchingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingWatchs");
        }
    }
}
