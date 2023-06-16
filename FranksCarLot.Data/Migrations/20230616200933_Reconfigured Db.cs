using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranksCarLot.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReconfiguredDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPurchases_CarLots_CarLotId",
                table: "CustomerPurchases");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPurchases_CarLotId",
                table: "CustomerPurchases");

            migrationBuilder.DropColumn(
                name: "CarLotId",
                table: "CustomerPurchases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarLotId",
                table: "CustomerPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPurchases_CarLotId",
                table: "CustomerPurchases",
                column: "CarLotId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPurchases_CarLots_CarLotId",
                table: "CustomerPurchases",
                column: "CarLotId",
                principalTable: "CarLots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
