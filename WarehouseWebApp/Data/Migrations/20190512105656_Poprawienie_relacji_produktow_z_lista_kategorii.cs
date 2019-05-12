using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class Poprawienie_relacji_produktow_z_lista_kategorii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorie_Produkty_ProductsId",
                table: "Kategorie");

            migrationBuilder.DropIndex(
                name: "IX_Kategorie_ProductsId",
                table: "Kategorie");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Kategorie");

            migrationBuilder.AddColumn<int>(
                name: "KategorieId",
                table: "Produkty",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_KategorieId",
                table: "Produkty",
                column: "KategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkty_Kategorie_KategorieId",
                table: "Produkty",
                column: "KategorieId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkty_Kategorie_KategorieId",
                table: "Produkty");

            migrationBuilder.DropIndex(
                name: "IX_Produkty_KategorieId",
                table: "Produkty");

            migrationBuilder.DropColumn(
                name: "KategorieId",
                table: "Produkty");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Kategorie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategorie_ProductsId",
                table: "Kategorie",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorie_Produkty_ProductsId",
                table: "Kategorie",
                column: "ProductsId",
                principalTable: "Produkty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
