using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class removeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBasket_BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BasketItem__Id",
                table: "BasketItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemId",
                principalTable: "BasketItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BasketItem__Id",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBasket_BasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemId",
                principalTable: "BasketItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
