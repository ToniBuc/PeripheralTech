using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class migCustomProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AvailableForCustom",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableForCustom",
                table: "Product");
        }
    }
}
