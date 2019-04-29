using Microsoft.EntityFrameworkCore.Migrations;

namespace EthCoffee.api.Migrations
{
    public partial class seedAddressType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Physical" });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Shipping" });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Billing" });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Postal" });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 5, "Headquarters" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
