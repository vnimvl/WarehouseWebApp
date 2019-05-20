using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class poprawa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Listy_ZamowienieId",
                table: "Listy");

            migrationBuilder.CreateIndex(
                name: "IX_Listy_ZamowienieId",
                table: "Listy",
                column: "ZamowienieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Listy_ZamowienieId",
                table: "Listy");

            migrationBuilder.CreateIndex(
                name: "IX_Listy_ZamowienieId",
                table: "Listy",
                column: "ZamowienieId",
                unique: true);
        }
    }
}
