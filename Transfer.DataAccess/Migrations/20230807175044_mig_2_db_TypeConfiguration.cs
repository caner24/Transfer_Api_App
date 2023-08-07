using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transfer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig2dbTypeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DropOffPoint_Vehicle_Id",
                table: "DropOffPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_PickUpPoint_Vehicle_Id",
                table: "PickUpPoint");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "PickUpPoint",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "DropOffPoint",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PickUpPoint_VehicleId",
                table: "PickUpPoint",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DropOffPoint_VehicleId",
                table: "DropOffPoint",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DropOffPoint_Vehicle_VehicleId",
                table: "DropOffPoint",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PickUpPoint_Vehicle_VehicleId",
                table: "PickUpPoint",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DropOffPoint_Vehicle_VehicleId",
                table: "DropOffPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_PickUpPoint_Vehicle_VehicleId",
                table: "PickUpPoint");

            migrationBuilder.DropIndex(
                name: "IX_PickUpPoint_VehicleId",
                table: "PickUpPoint");

            migrationBuilder.DropIndex(
                name: "IX_DropOffPoint_VehicleId",
                table: "DropOffPoint");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "PickUpPoint");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "DropOffPoint");

            migrationBuilder.AddForeignKey(
                name: "FK_DropOffPoint_Vehicle_Id",
                table: "DropOffPoint",
                column: "Id",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PickUpPoint_Vehicle_Id",
                table: "PickUpPoint",
                column: "Id",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
