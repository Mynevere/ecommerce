using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class basketItem_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_ItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "ItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.AddColumn<int>(
                name: "BasketItemsBasketItemId",
                table: "CustomerBaskets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerBasketId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBaskets_BasketItemsBasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemsBasketItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CustomerBasketId",
                table: "BasketItems",
                column: "CustomerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_CustomerBaskets_CustomerBasketId",
                table: "BasketItems",
                column: "CustomerBasketId",
                principalTable: "CustomerBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemsBasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemsBasketItemId",
                principalTable: "BasketItems",
                principalColumn: "BasketItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_CustomerBaskets_CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_BasketItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "BasketItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemsBasketItemId",
                table: "CustomerBaskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBaskets_ItemsBasketItemId",
                table: "CustomerBaskets",
                column: "ItemsBasketItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemsBasketItemId",
                table: "CustomerBaskets",
                column: "ItemsBasketItemId",
                principalTable: "BasketItems",
                principalColumn: "BasketItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
