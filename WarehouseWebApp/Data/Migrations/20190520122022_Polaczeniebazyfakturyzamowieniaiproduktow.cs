using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class Polaczeniebazyfakturyzamowieniaiproduktow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataZamowienia = table.Column<DateTime>(nullable: false),
                    DataWystawieniaFaktury = table.Column<DateTime>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    ProductsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Produkty_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faktury",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumerFaktury = table.Column<int>(nullable: false),
                    KodFaktury = table.Column<string>(nullable: true),
                    KlientId = table.Column<int>(nullable: false),
                    ZamowienieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktury", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faktury_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faktury_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faktury_KlientId",
                table: "Faktury",
                column: "KlientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faktury_ZamowienieId",
                table: "Faktury",
                column: "ZamowienieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_ProductsId",
                table: "Zamowienia",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faktury");

            migrationBuilder.DropTable(
                name: "Zamowienia");
        }
    }
}
