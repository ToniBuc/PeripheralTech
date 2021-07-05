using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class migVidTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProductVideo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProductVideo");
        }
    }
}
