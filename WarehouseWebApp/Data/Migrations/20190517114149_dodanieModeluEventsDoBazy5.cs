using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class dodanieModeluEventsDoBazy5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeColor",
                table: "Events",
                newName: "TextColor");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "TextColor",
                table: "Events",
                newName: "ThemeColor");
        }
    }
}
