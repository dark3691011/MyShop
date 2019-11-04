using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SingleImage1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SingleImage2",
                table: "products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SingleImage1",
                table: "products",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SingleImage2",
                table: "products",
                maxLength: 50,
                nullable: true);
        }
    }
}
