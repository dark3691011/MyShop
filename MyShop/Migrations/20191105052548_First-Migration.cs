using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "customers",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "customers",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);
        }
    }
}
