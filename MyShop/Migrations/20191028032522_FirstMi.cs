using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations
{
    public partial class FirstMi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Addres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    DiscountID = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountValue = table.Column<int>(nullable: false),
                    ExpirationDay = table.Column<DateTime>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.DiscountID);
                });

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

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(maxLength: 50, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 100, nullable: true),
                    FatherTypeID = table.Column<int>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.TypeID);
                    table.ForeignKey(
                        name: "FK_productTypes_productTypes_FatherTypeID",
                        column: x => x.FatherTypeID,
                        principalTable: "productTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trademarks",
                columns: table => new
                {
                    TrademarkID = table.Column<int>(maxLength: 50, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Logo = table.Column<string>(maxLength: 50, nullable: true),
                    Addres = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trademarks", x => x.TrademarkID);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    BillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalAmount = table.Column<double>(nullable: false),
                    BillTime = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bills", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_bills_customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<int>(maxLength: 50, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 100, nullable: true),
                    UnitPrice = table.Column<double>(maxLength: 50, nullable: false),
                    Amount = table.Column<int>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DiscountID = table.Column<int>(maxLength: 50, nullable: false),
                    TypeID = table.Column<int>(maxLength: 50, nullable: false),
                    TrademarkID = table.Column<int>(maxLength: 50, nullable: false),
                    ImgID = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_products_discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "discounts",
                        principalColumn: "DiscountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_imgProducts_ImgID",
                        column: x => x.ImgID,
                        principalTable: "imgProducts",
                        principalColumn: "ImgID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_trademarks_TrademarkID",
                        column: x => x.TrademarkID,
                        principalTable: "trademarks",
                        principalColumn: "TrademarkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_productTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "productTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "billDetails",
                columns: table => new
                {
                    BillDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billDetails", x => x.BillDetailID);
                    table.ForeignKey(
                        name: "FK_billDetails_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billDetails_ProductID",
                table: "billDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_bills_CustomerID",
                table: "bills",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_products_DiscountID",
                table: "products",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_products_ImgID",
                table: "products",
                column: "ImgID");

            migrationBuilder.CreateIndex(
                name: "IX_products_TrademarkID",
                table: "products",
                column: "TrademarkID");

            migrationBuilder.CreateIndex(
                name: "IX_products_TypeID",
                table: "products",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_productTypes_FatherTypeID",
                table: "productTypes",
                column: "FatherTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billDetails");

            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "imgProducts");

            migrationBuilder.DropTable(
                name: "trademarks");

            migrationBuilder.DropTable(
                name: "productTypes");
        }
    }
}
