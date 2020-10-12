using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.Migrations
{
    public partial class AddedAdditionToPriceCalories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CaloriesAdditionalPriceBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CountBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryTimesCountBought",
                table: "OrderBasketItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionToPrice",
                table: "Calories",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesAdditionalPriceBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "CountBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "DeliveryTimesCountBought",
                table: "OrderBasketItem");

            migrationBuilder.DropColumn(
                name: "AdditionToPrice",
                table: "Calories");
        }
    }
}
