using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class dodanienowejtabeliorderslaczacejproduktyzzamowieniem3COFNIECIEZMINA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_ZamowienieId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ZamowienieId",
                table: "Orders",
                column: "ZamowienieId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_ZamowienieId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ZamowienieId",
                table: "Orders",
                column: "ZamowienieId");
        }
    }
}
