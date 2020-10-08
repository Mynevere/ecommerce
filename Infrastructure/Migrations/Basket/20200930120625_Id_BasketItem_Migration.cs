using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class Id_BasketItem_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemsId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_ItemsId",
                table: "CustomerBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemsBasketItemId",
                table: "CustomerBaskets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasketItemId",
                table: "BasketItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "BasketItemId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_ItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ItemsBasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "BasketItemId",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "CustomerBaskets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBaskets_ItemsId",
                table: "CustomerBaskets",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemsId",
                table: "CustomerBaskets",
                column: "ItemsId",
                principalTable: "BasketItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
