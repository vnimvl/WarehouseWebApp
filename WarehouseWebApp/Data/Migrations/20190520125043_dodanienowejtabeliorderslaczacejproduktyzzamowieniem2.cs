using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class dodanienowejtabeliorderslaczacejproduktyzzamowieniem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Produkty_ProductsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Produkty_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Produkty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Produkty_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsId",
                table: "Orders",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Produkty_ProductsId",
                table: "Orders",
                column: "ProductsId",
                principalTable: "Produkty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
