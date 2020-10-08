using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class primaryKeyBasketItem_Migrartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BasketItems",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BasketItem__Id",
                table: "BasketItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__BasketItem__Id",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BasketItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "BasketItemId");
        }
    }
}
