using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class migCustomOrdr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductMadeForID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductMadeForID",
                table: "Product",
                column: "ProductMadeForID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_ProductMadeForID",
                table: "Product",
                column: "ProductMadeForID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_ProductMadeForID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductMadeForID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductMadeForID",
                table: "Product");
        }
    }
}
