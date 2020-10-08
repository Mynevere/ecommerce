using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Basket
{
    public partial class basketItems_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_CustomerBaskets_CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_CustomerBasketId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "CustomerBasketId",
                table: "BasketItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerBasketId",
                table: "BasketItems",
                type: "nvarchar(450)",
                nullable: true);

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
