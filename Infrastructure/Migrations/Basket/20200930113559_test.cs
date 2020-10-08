using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "BasketItemId",
                table: "CustomerBaskets");

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "CustomerBaskets",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBaskets_BasketItems_ItemsId",
                table: "CustomerBaskets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBaskets_ItemsId",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "CustomerBaskets");

            migrationBuilder.AddColumn<int>(
                name: "BasketItemId",
                table: "CustomerBaskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBaskets_BasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBaskets_BasketItems_BasketItemId",
                table: "CustomerBaskets",
                column: "BasketItemId",
                principalTable: "BasketItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
