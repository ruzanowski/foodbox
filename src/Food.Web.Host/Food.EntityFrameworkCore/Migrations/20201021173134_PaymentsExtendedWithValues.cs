using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.Migrations
{
    public partial class PaymentsExtendedWithValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TaxPaid",
                table: "Payments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValueGrossPaid",
                table: "Payments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValuePaid",
                table: "Payments",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxPaid",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ValueGrossPaid",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ValuePaid",
                table: "Payments");
        }
    }
}
