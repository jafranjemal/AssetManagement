using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetManagement.Infrastrucuture.Migrations
{
    /// <inheritdoc />
    public partial class updatetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("37bab96f-8fd9-4d67-b61e-e593b2d0d8ec"));

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("8c1b774d-ef82-4c92-bb69-e3a62d8b260b"));

            migrationBuilder.DropColumn(
                name: "Co2Emission",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelCapacity",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "GpsId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "TransmissionType",
                table: "Vehicles",
                newName: "VehicleName");

            migrationBuilder.RenameColumn(
                name: "TrackerType",
                table: "Vehicles",
                newName: "EmissionSpec");

            migrationBuilder.RenameColumn(
                name: "SteeringType",
                table: "Vehicles",
                newName: "CurrentStattionlStatus");

            migrationBuilder.RenameColumn(
                name: "EstimatedEndTermValue",
                table: "Vehicles",
                newName: "InitialManufacturerPrice");

            migrationBuilder.AddColumn<bool>(
                name: "Altered",
                table: "VehicleTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ChassisNo",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoorsNo",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineNo",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelCapacity",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomberOfCylinder",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeatsNo",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SteeringType",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubDivision",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransmissionType",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<decimal>(
                name: "Co2Standard",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentationDetailsId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "EngineCo2Emission",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedEndOfTermValue",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoadPermitExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsuranceExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuplicateKeySerialNo = table.Column<int>(type: "int", nullable: true),
                    FileNo = table.Column<int>(type: "int", nullable: true),
                    GPS_GSM = table.Column<int>(type: "int", nullable: true),
                    GPS_ID = table.Column<int>(type: "int", nullable: true),
                    GPSType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPSServiceVendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearMade = table.Column<int>(type: "int", nullable: true),
                    OwnershipStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MadeIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastOdometer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstRegisteredWithUsOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentationDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetyCriteria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriteriaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyCriteria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleEquipment_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverSafetyCompliance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SafetyCriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCertified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverSafetyCompliance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverSafetyCompliance_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverSafetyCompliance_SafetyCriteria_SafetyCriteriaId",
                        column: x => x.SafetyCriteriaId,
                        principalTable: "SafetyCriteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("67f85360-095e-4f42-ac74-1f7790084237"),
                columns: new[] { "Altered", "Category", "ChassisNo", "Color", "Division", "DoorsNo", "EngineNo", "FuelCapacity", "FuelType", "NomberOfCylinder", "Notes", "SeatsNo", "SteeringType", "SubDivision", "TransmissionType", "TypeName" },
                values: new object[] { false, "Pick Up", null, "White", "Pick Up 3 Ton", "4", null, "80L", "Diesel", "6", "Heavy-duty transport vehicle", "6", "Right Hand", "Double Cabin", "Manual", "Transport" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("8d8f6f0b-dd69-478e-9f6e-66ba77908a6d"),
                columns: new[] { "Altered", "Category", "ChassisNo", "Color", "Division", "DoorsNo", "EngineNo", "FuelCapacity", "FuelType", "NomberOfCylinder", "Notes", "SeatsNo", "SteeringType", "SubDivision", "TransmissionType", "TypeName" },
                values: new object[] { false, "Construction", null, "Yellow", "Excavator", "1", null, "200L", "Diesel", "8", "Used for construction projects", "1", "Joystick", "Hydraulic", "Hydraulic", "Equipment" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("99e315c4-395d-4a32-9342-874f13628ebf"),
                columns: new[] { "Altered", "Category", "ChassisNo", "Color", "Division", "DoorsNo", "EngineNo", "FuelCapacity", "FuelType", "NomberOfCylinder", "Notes", "SeatsNo", "SteeringType", "SubDivision", "TransmissionType", "TypeName" },
                values: new object[] { false, "Sedan", null, "Various", "Compact", "4", null, "50L", "Petrol", "4", "Standard passenger sedan", "5", "Left Hand", "4-Door", "Automatic", "Passenger" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DocumentationDetailsId",
                table: "Vehicles",
                column: "DocumentationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverSafetyCompliance_DriverId",
                table: "DriverSafetyCompliance",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverSafetyCompliance_SafetyCriteriaId",
                table: "DriverSafetyCompliance",
                column: "SafetyCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEquipment_VehicleId",
                table: "VehicleEquipment",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_DocumentationDetails_DocumentationDetailsId",
                table: "Vehicles",
                column: "DocumentationDetailsId",
                principalTable: "DocumentationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Vehicles_DocumentationDetails_DocumentationDetailsId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "DocumentationDetails");

            migrationBuilder.DropTable(
                name: "DriverSafetyCompliance");

            migrationBuilder.DropTable(
                name: "VehicleEquipment");

            migrationBuilder.DropTable(
                name: "SafetyCriteria");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_DocumentationDetailsId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Altered",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "ChassisNo",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "DoorsNo",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "EngineNo",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "FuelCapacity",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "NomberOfCylinder",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "SeatsNo",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "SteeringType",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "SubDivision",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "TransmissionType",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Co2Standard",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DocumentationDetailsId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EngineCo2Emission",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EstimatedEndOfTermValue",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleName",
                table: "Vehicles",
                newName: "TransmissionType");

            migrationBuilder.RenameColumn(
                name: "InitialManufacturerPrice",
                table: "Vehicles",
                newName: "EstimatedEndTermValue");

            migrationBuilder.RenameColumn(
                name: "EmissionSpec",
                table: "Vehicles",
                newName: "TrackerType");

            migrationBuilder.RenameColumn(
                name: "CurrentStattionlStatus",
                table: "Vehicles",
                newName: "SteeringType");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Co2Emission",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelCapacity",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GpsId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("67f85360-095e-4f42-ac74-1f7790084237"),
                columns: new[] { "Category", "Division", "TypeName" },
                values: new object[] { "Passenger Vehicles", "City Transport", "Sedan" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("8d8f6f0b-dd69-478e-9f6e-66ba77908a6d"),
                columns: new[] { "Category", "Division", "TypeName" },
                values: new object[] { "Off-Road Vehicles", "All-Terrain", "SUV" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: new Guid("99e315c4-395d-4a32-9342-874f13628ebf"),
                columns: new[] { "Category", "Division", "TypeName" },
                values: new object[] { "Light Vehicles", "Transport", "Pickup" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Category", "Division", "TypeName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("37bab96f-8fd9-4d67-b61e-e593b2d0d8ec"), "Heavy Duty", "Industrial Transport", "Truck", null },
                    { new Guid("8c1b774d-ef82-4c92-bb69-e3a62d8b260b"), "Eco-Friendly", "Sustainable Mobility", "Electric", null }
                });
        }
    }
}
