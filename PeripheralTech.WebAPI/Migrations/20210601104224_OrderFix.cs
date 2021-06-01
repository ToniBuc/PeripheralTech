using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class OrderFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderID",
                table: "Product",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderID",
                table: "Product",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductID",
                table: "Order",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductID",
                table: "Order",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
