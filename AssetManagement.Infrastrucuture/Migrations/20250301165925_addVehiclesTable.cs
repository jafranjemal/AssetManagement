using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastrucuture.Migrations
{
    /// <inheritdoc />
    public partial class addVehiclesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionRecord_Vehicle_VehicleId",
                table: "InspectionRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecord_Vehicle_VehicleId",
                table: "MaintenanceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Permits_Vehicle_VehicleId",
                table: "Permits");

            migrationBuilder.DropForeignKey(
                name: "FK_SafetyEquipments_Vehicle_VehicleId",
                table: "SafetyEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_DocumentationDetails_DocumentationDetailsId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Drivers_AssignedDriverId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Locations_LocationId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleBrands_BrandId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleModels_ModelId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleTypes_TypeId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleTypes_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEquipment_Vehicle_VehicleId",
                table: "VehicleEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicles",
                newName: "IX_Vehicles_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_ModelId",
                table: "Vehicles",
                newName: "IX_Vehicles_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_LocationId",
                table: "Vehicles",
                newName: "IX_Vehicles_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_DocumentationDetailsId",
                table: "Vehicles",
                newName: "IX_Vehicles_DocumentationDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_BrandId",
                table: "Vehicles",
                newName: "IX_Vehicles_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_AssignedDriverId",
                table: "Vehicles",
                newName: "IX_Vehicles_AssignedDriverId");

            migrationBuilder.AddColumn<string>(
                name: "ContactInCharge",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CostCenter",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DivisionName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionRecord_Vehicles_VehicleId",
                table: "InspectionRecord",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecord_Vehicles_VehicleId",
                table: "MaintenanceRecord",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permits_Vehicles_VehicleId",
                table: "Permits",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyEquipments_Vehicles_VehicleId",
                table: "SafetyEquipments",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEquipment_Vehicles_VehicleId",
                table: "VehicleEquipment",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_DocumentationDetails_DocumentationDetailsId",
                table: "Vehicles",
                column: "DocumentationDetailsId",
                principalTable: "DocumentationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Drivers_AssignedDriverId",
                table: "Vehicles",
                column: "AssignedDriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Locations_LocationId",
                table: "Vehicles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleBrands_BrandId",
                table: "Vehicles",
                column: "BrandId",
                principalTable: "VehicleBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_TypeId",
                table: "Vehicles",
                column: "TypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionRecord_Vehicles_VehicleId",
                table: "InspectionRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecord_Vehicles_VehicleId",
                table: "MaintenanceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Permits_Vehicles_VehicleId",
                table: "Permits");

            migrationBuilder.DropForeignKey(
                name: "FK_SafetyEquipments_Vehicles_VehicleId",
                table: "SafetyEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEquipment_Vehicles_VehicleId",
                table: "VehicleEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_DocumentationDetails_DocumentationDetailsId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Drivers_AssignedDriverId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Locations_LocationId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleBrands_BrandId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_ModelId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_TypeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ContactInCharge",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CostCenter",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DivisionName",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_TypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicle",
                newName: "IX_Vehicle_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_LocationId",
                table: "Vehicle",
                newName: "IX_Vehicle_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_DocumentationDetailsId",
                table: "Vehicle",
                newName: "IX_Vehicle_DocumentationDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_BrandId",
                table: "Vehicle",
                newName: "IX_Vehicle_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_AssignedDriverId",
                table: "Vehicle",
                newName: "IX_Vehicle_AssignedDriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionRecord_Vehicle_VehicleId",
                table: "InspectionRecord",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecord_Vehicle_VehicleId",
                table: "MaintenanceRecord",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permits_Vehicle_VehicleId",
                table: "Permits",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyEquipments_Vehicle_VehicleId",
                table: "SafetyEquipments",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_DocumentationDetails_DocumentationDetailsId",
                table: "Vehicle",
                column: "DocumentationDetailsId",
                principalTable: "DocumentationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Drivers_AssignedDriverId",
                table: "Vehicle",
                column: "AssignedDriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Locations_LocationId",
                table: "Vehicle",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleBrands_BrandId",
                table: "Vehicle",
                column: "BrandId",
                principalTable: "VehicleBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleModels_ModelId",
                table: "Vehicle",
                column: "ModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleTypes_TypeId",
                table: "Vehicle",
                column: "TypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleTypes_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEquipment_Vehicle_VehicleId",
                table: "VehicleEquipment",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
