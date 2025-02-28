using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetManagement.Infrastrucuture.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "BrandId", "CreatedDate", "ModelName", "ModelYear", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d91e3b7a-5c8e-4f72-a4d7-6c92b3d8a7e9"), new Guid("a479fb2c-b478-441a-b950-11635ac696a7"), null, "Civic", 2022, null },
                    { new Guid("e8b2c7d6-3a9e-4b5f-bd17-2f3c9a7e6b8a"), new Guid("1885aa2b-fd41-475b-863a-d55efca9f4d3"), null, "F-150", 2024, null },
                    { new Guid("f17a7c8d-4a3b-4b81-b1e6-8d97b0f1a8c9"), new Guid("9497f582-8512-443f-a457-0fb2b807656b"), null, "Corolla", 2023, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("d91e3b7a-5c8e-4f72-a4d7-6c92b3d8a7e9"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("e8b2c7d6-3a9e-4b5f-bd17-2f3c9a7e6b8a"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("f17a7c8d-4a3b-4b81-b1e6-8d97b0f1a8c9"));
        }
    }
}
