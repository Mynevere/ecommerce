using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class fourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerBasketId",
                table: "CustomerBaskets");

            migrationBuilder.AddColumn<int>(
                name: "BasketItemId",
                table: "CustomerBaskets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.AddColumn<int>(
                name: "CustomerBasketId",
                table: "CustomerBaskets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
