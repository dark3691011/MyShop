using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations
{
    public partial class billDetailForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillID",
                table: "billDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_billDetails_BillID",
                table: "billDetails",
                column: "BillID");

            migrationBuilder.AddForeignKey(
                name: "FK_billDetails_bills_BillID",
                table: "billDetails",
                column: "BillID",
                principalTable: "bills",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billDetails_bills_BillID",
                table: "billDetails");

            migrationBuilder.DropIndex(
                name: "IX_billDetails_BillID",
                table: "billDetails");

            migrationBuilder.DropColumn(
                name: "BillID",
                table: "billDetails");
        }
    }
}
