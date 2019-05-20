using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class dodanienowejtabeliorderslaczacejproduktyzzamowieniem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Produkty_ProductsId",
                table: "Zamowienia");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_ProductsId",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Zamowienia");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LiczbaSztuk = table.Column<int>(nullable: false),
                    ZamowienieId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Produkty_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsId",
                table: "Orders",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ZamowienieId",
                table: "Orders",
                column: "ZamowienieId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Zamowienia",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_ProductsId",
                table: "Zamowienia",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Produkty_ProductsId",
                table: "Zamowienia",
                column: "ProductsId",
                principalTable: "Produkty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
