using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class buildMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_CustomerBaskets_CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BasketItem__Id",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBaskets_BasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBasket_BasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemId",
                principalTable: "BasketItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBasket_BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BasketItem__Id",
                table: "BasketItems");

            migrationBuilder.AddColumn<string>(
                name: "CustomerBasketId",
                table: "BasketItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

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
        }
    }
}
