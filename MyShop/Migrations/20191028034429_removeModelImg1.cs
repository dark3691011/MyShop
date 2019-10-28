using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations
{
    public partial class removeModelImg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_discounts_DiscountID",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "products",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_products_discounts_DiscountID",
                table: "products",
                column: "DiscountID",
                principalTable: "discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_discounts_DiscountID",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "products",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_discounts_DiscountID",
                table: "products",
                column: "DiscountID",
                principalTable: "discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
