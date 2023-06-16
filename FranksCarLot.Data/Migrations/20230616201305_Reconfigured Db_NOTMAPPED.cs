﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranksCarLot.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReconfiguredDbNOTMAPPED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPurchases_Cars_CarId",
                table: "CustomerPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPurchases_Customers_CustomerId",
                table: "CustomerPurchases");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPurchases_CarId",
                table: "CustomerPurchases");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPurchases_CustomerId",
                table: "CustomerPurchases");

            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "CustomerPurchases",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "CustomerPurchases",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPurchases_CarId",
                table: "CustomerPurchases",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPurchases_CustomerId",
                table: "CustomerPurchases",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPurchases_Cars_CarId",
                table: "CustomerPurchases",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPurchases_Customers_CustomerId",
                table: "CustomerPurchases",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
