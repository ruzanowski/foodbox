using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.Migrations
{
    public partial class AddedBoughtPropertiesToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CutleryFeeTaxPercentBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CutleryNetFeeBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryFeeTaxPercentBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryNetFeeBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceNetBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxProductPercentBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CutleryFeeTaxPercentBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "CutleryNetFeeBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "DeliveryFeeTaxPercentBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "DeliveryNetFeeBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "DiscountPercentBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "PriceNetBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "TaxProductPercentBought",
                table: "OrderBasketItem");
        }
    }
}
