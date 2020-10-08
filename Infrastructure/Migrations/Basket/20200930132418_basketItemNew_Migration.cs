using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class basketItemNew_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_BasketItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "BasketItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.AddColumn<int>(
                name: "ItemBasketItemId",
                table: "CustomerBaskets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBaskets_ItemBasketItemId",
                table: "CustomerBaskets",
                column: "ItemBasketItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemBasketItemId",
                table: "CustomerBaskets",
                column: "ItemBasketItemId",
                principalTable: "BasketItems",
                principalColumn: "BasketItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_ItemBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "ItemBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.AddColumn<int>(
                name: "BasketItemsBasketItemId",
                table: "CustomerBaskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBaskets_BasketItemsBasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemsBasketItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemsBasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemsBasketItemId",
                principalTable: "BasketItems",
                principalColumn: "BasketItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
