using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranksCarLot.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReconfiguredDbDelima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerPurchases_CustomerId",
                table: "CustomerPurchases",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPurchases_Customers_CustomerId",
                table: "CustomerPurchases",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPurchases_Customers_CustomerId",
                table: "CustomerPurchases");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPurchases_CustomerId",
                table: "CustomerPurchases");
        }
    }
}
