using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetManagement.Infrastrucuture.Migrations
{
    /// <inheritdoc />
    public partial class firstcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetyCriterias",
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
                    table.PrimaryKey("PK_SafetyCriterias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassisNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatsNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomberOfCylinder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoorsNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransmissionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SteeringType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altered = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
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
                        name: "FK_DriverSafetyCompliance_SafetyCriterias_SafetyCriteriaId",
                        column: x => x.SafetyCriteriaId,
                        principalTable: "SafetyCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentStattionlStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineCo2Emission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Co2Standard = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    EmissionSpec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentationDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InitialManufacturerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedEndOfTermValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastInspection = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextInspection = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_DocumentationDetails_DocumentationDetailsId",
                        column: x => x.DocumentationDetailsId,
                        principalTable: "DocumentationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Drivers_AssignedDriverId",
                        column: x => x.AssignedDriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Vehicle_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionRecord_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecord_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermitHolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermitDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permits_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SafetyEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyEquipments_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_VehicleEquipment_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "ContactInCharge", "CostCenter", "DivisionName", "LocationName", "ProjectName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("441d36b4-dfcd-4817-afe1-27a67a1b218c"), "Michael Brown", "Construction", "Devision 1", "North Yard", "Construction", null },
                    { new Guid("6fa5b8c6-6f12-4ace-8232-2c06454b64a1"), "Emily Davis", "Distribution", "Devision 1", "West Depot", "Distribution", null },
                    { new Guid("8346b56d-d507-4dd7-99ba-3a17881cc642"), "Jane Smith", "Logistics", "Devision 1", "East Warehouse", "Logistics", null },
                    { new Guid("8733e63f-6446-4b91-b7b6-744a8cfcf75e"), "Robert Wilson", "Transport Hub", "Devision 1", "South Terminal", "Transport Hub", null },
                    { new Guid("901b2c5e-fc7a-441b-9d79-4940b60b69cc"), "John Doe", "Fleet Management", "Devision 1", "Main Garage", "Fleet Management", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "Category", "Division", "Name", "SubDivision", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1885aa2b-fd41-475b-863a-d55efca9f4d3"), "SUV", "Explorer", "Ford", "XLT", null },
                    { new Guid("66694f49-8e27-4b78-8233-57f59b9b5036"), "Electric", "Model S", "Tesla", "Plaid", null },
                    { new Guid("9497f582-8512-443f-a457-0fb2b807656a"), "Howo", "T5G", "Sinotruk", "Heavy Trucks", null },
                    { new Guid("9497f582-8512-443f-a457-0fb2b807656b"), "Sedan", "Camry", "Toyota", "Hybrid", null },
                    { new Guid("a479fb2c-b478-441a-b950-11635ac696a7"), "Compact", "Civic", "Honda", "Sport", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Altered", "Category", "ChassisNo", "Color", "Division", "DoorsNo", "EngineNo", "FuelCapacity", "FuelType", "NomberOfCylinder", "Notes", "SeatsNo", "SteeringType", "SubDivision", "TransmissionType", "TypeName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("67f85360-095e-4f42-ac74-1f7790084237"), false, "Pick Up", null, "White", "Pick Up 3 Ton", "4", null, "80L", "Diesel", "6", "Heavy-duty transport vehicle", "6", "Right Hand", "Double Cabin", "Manual", "Transport", null },
                    { new Guid("8d8f6f0b-dd69-478e-9f6e-66ba77908a6d"), false, "Construction", null, "Yellow", "Excavator", "1", null, "200L", "Diesel", "8", "Used for construction projects", "1", "Joystick", "Hydraulic", "Hydraulic", "Equipment", null },
                    { new Guid("99e315c4-395d-4a32-9342-874f13628ebf"), false, "Sedan", null, "Various", "Compact", "4", null, "50L", "Petrol", "4", "Standard passenger sedan", "5", "Left Hand", "4-Door", "Automatic", "Passenger", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "BrandId", "CreatedDate", "ModelName", "ModelYear", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d91e3b7a-5c8e-4f72-a4d7-6c92b3d8a7e9"), new Guid("a479fb2c-b478-441a-b950-11635ac696a7"), null, "Civic", 2022, null },
                    { new Guid("e8b2c7d6-3a9e-4b5f-bd17-2f3c9a7e6b8a"), new Guid("1885aa2b-fd41-475b-863a-d55efca9f4d3"), null, "F-150", 2024, null },
                    { new Guid("f17a7c8d-4a3b-4b81-b1e6-8d97b0f1a8c9"), new Guid("9497f582-8512-443f-a457-0fb2b807656b"), null, "Corolla", 2023, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverSafetyCompliance_DriverId",
                table: "DriverSafetyCompliance",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverSafetyCompliance_SafetyCriteriaId",
                table: "DriverSafetyCompliance",
                column: "SafetyCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRecord_VehicleId",
                table: "InspectionRecord",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecord_VehicleId",
                table: "MaintenanceRecord",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permits_VehicleId",
                table: "Permits",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyEquipments_VehicleId",
                table: "SafetyEquipments",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_AssignedDriverId",
                table: "Vehicle",
                column: "AssignedDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BrandId",
                table: "Vehicle",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DocumentationDetailsId",
                table: "Vehicle",
                column: "DocumentationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LocationId",
                table: "Vehicle",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelId",
                table: "Vehicle",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicle",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEquipment_VehicleId",
                table: "VehicleEquipment",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_BrandId",
                table: "VehicleModels",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverSafetyCompliance");

            migrationBuilder.DropTable(
                name: "InspectionRecord");

            migrationBuilder.DropTable(
                name: "MaintenanceRecord");

            migrationBuilder.DropTable(
                name: "Permits");

            migrationBuilder.DropTable(
                name: "SafetyEquipments");

            migrationBuilder.DropTable(
                name: "VehicleEquipment");

            migrationBuilder.DropTable(
                name: "SafetyCriterias");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "DocumentationDetails");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
