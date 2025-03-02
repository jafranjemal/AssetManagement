using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastrucuture.Migrations
{
    /// <inheritdoc />
    public partial class add_ModelNo_toVehicleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModelNo",
                table: "VehicleModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("d91e3b7a-5c8e-4f72-a4d7-6c92b3d8a7e9"),
                column: "ModelNo",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("e8b2c7d6-3a9e-4b5f-bd17-2f3c9a7e6b8a"),
                column: "ModelNo",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("f17a7c8d-4a3b-4b81-b1e6-8d97b0f1a8c9"),
                column: "ModelNo",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelNo",
                table: "VehicleModels");
        }
    }
}
