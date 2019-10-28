using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations
{
    public partial class removeModelImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_imgProducts_ImgID",
                table: "products");

            migrationBuilder.DropTable(
                name: "imgProducts");

            migrationBuilder.DropIndex(
                name: "IX_products_ImgID",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImgID",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "products",
                maxLength: 50,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SingleImage1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SingleImage2",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ImgID",
                table: "products",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "imgProducts",
                columns: table => new
                {
                    ImgID = table.Column<int>(maxLength: 50, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductImage = table.Column<string>(maxLength: 50, nullable: true),
                    SingleImage1 = table.Column<string>(maxLength: 50, nullable: true),
                    SingleImage2 = table.Column<string>(maxLength: 50, nullable: true),
                    SingleImage3 = table.Column<string>(maxLength: 50, nullable: true),
                    SingleImage4 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imgProducts", x => x.ImgID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ImgID",
                table: "products",
                column: "ImgID");

            migrationBuilder.AddForeignKey(
                name: "FK_products_imgProducts_ImgID",
                table: "products",
                column: "ImgID",
                principalTable: "imgProducts",
                principalColumn: "ImgID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
