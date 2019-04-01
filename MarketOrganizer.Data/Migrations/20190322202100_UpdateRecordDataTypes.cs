using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketOrganizer.Data.Migrations
{
    public partial class UpdateRecordDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "HighestMarketPrice",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyPrice",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SellPrice",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "HighestMarketPrice",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "BuyPrice",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
