using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranksCarLot.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCartoCustomerPurchaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "CustomerPurchases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPurchases_CarId",
                table: "CustomerPurchases",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPurchases_Cars_CarId",
                table: "CustomerPurchases",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPurchases_Cars_CarId",
                table: "CustomerPurchases");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPurchases_CarId",
                table: "CustomerPurchases");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CustomerPurchases");
        }
    }
}
