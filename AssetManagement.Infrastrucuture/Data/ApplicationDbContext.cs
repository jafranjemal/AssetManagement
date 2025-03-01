using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastrucuture.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Permit> Permits { get; set; }
        public DbSet<SafetyEquipment> SafetyEquipments { get; set; }
        public DbSet<SafetyCriteria> SafetyCriterias { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<InspectionRecord> InspectionRecords { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Pre-generate GUIDs and DateTime values
            var sinotrukId = new Guid("{9497F582-8512-443F-A457-0FB2B807656A}");
            var toyotaId = new  Guid("{9497F582-8512-443F-A457-0FB2B807656B}");
            var fordId = new   Guid("{1885AA2B-FD41-475B-863A-D55EFCA9F4D3}");
            var teslaId =   new Guid("{66694F49-8E27-4B78-8233-57F59B9B5036}");
            var hondaId =   new Guid("{A479FB2C-B478-441A-B950-11635AC696A7}");

            var pickupTypeId = new Guid("{99E315C4-395D-4A32-9342-874F13628EBF}");
            var sedanTypeId = new Guid("{67F85360-095E-4F42-AC74-1F7790084237}");
            var suvTypeId = new Guid("{8D8F6F0B-DD69-478E-9F6E-66BA77908A6D}");
            var electricTypeId = new Guid("{8C1B774D-EF82-4C92-BB69-E3A62D8B260B}");
            var truckTypeId = new Guid("{37BAB96F-8FD9-4D67-B61E-E593B2D0D8EC}");

            var mainGarageId = new Guid("{901B2C5E-FC7A-441B-9D79-4940B60B69CC}");
            var eastWarehouseId = new Guid("{8346B56D-D507-4DD7-99BA-3A17881CC642}");
            var northYardId = new Guid("{441D36B4-DFCD-4817-AFE1-27A67A1B218C}");
            var westDepotId = new Guid("{6FA5B8C6-6F12-4ACE-8232-2C06454B64A1}");
            var southTerminalId = new Guid("{8733E63F-6446-4B91-B7B6-744A8CFCF75E}");

            var driver1Id = new Guid("{2E63EC2F-5B04-4D82-9731-BF369E97F827}");
            var driver2Id = new Guid("{E6B5EFD3-F050-40D7-BBE0-684ACE0CFA1A}");
            var driver3Id = new Guid("{DD10B432-BFFC-474B-8AC4-F7D3E2533122}");
            var driver4Id = new Guid("{98D8FBED-C5C4-461D-A3D3-C60D25A220B5}");
            var driver5Id = new Guid("{98D8FBED-C5C4-461D-A3D3-C60D25A220B5}");


            // Vehicle relationships
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Brand)
                .WithMany()
                .HasForeignKey(v => v.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Model)
                .WithMany()
                .HasForeignKey(v => v.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Type)
                .WithMany()
                .HasForeignKey(v => v.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Location)
                .WithMany()
                .HasForeignKey(v => v.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.AssignedDriver)
                .WithMany()
                .HasForeignKey(v => v.AssignedDriverId)
                .OnDelete(DeleteBehavior.SetNull);

            // Vehicle Model relationship
            modelBuilder.Entity<VehicleModel>()
                .HasOne(vm => vm.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(vm => vm.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            // Driver relationship
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.AssignedVehicle)
                .WithOne(v => v.AssignedDriver)
                .HasForeignKey<Driver>(d => d.AssignedVehicleId)
                .OnDelete(DeleteBehavior.SetNull);
 
          

            // Safety Equipment relationship
            modelBuilder.Entity<VehicleEquipment>()
                .HasOne(se => se.Vehicle)
                .WithMany(v => v.InstalledEquipment)
                .HasForeignKey(se => se.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Maintenance Record relationship
            modelBuilder.Entity<MaintenanceRecord>()
                .HasOne(mr => mr.Vehicle)
                .WithMany(v => v.MaintenanceRecords)
                .HasForeignKey(mr => mr.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Inspection Record relationship
            modelBuilder.Entity<InspectionRecord>()
                .HasOne(ir => ir.Vehicle)
                .WithMany()
                .HasForeignKey(ir => ir.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Driver Certification relationship
            modelBuilder.Entity<DriverCertification>()
                .HasOne(dc => dc.Driver)
                .WithMany(d => d.Certifications)
                .HasForeignKey(dc => dc.DriverId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<VehicleBrand>()
       .Property(l => l.CreatedDate)
       .HasDefaultValueSql("GETUTCDATE()"); // Auto-set in database

            modelBuilder.Entity<VehicleType>()
       .Property(l => l.CreatedDate)
       .HasDefaultValueSql("GETUTCDATE()"); // Auto-set in database

            modelBuilder.Entity<Location>()
       .Property(l => l.CreatedDate)
       .HasDefaultValueSql("GETUTCDATE()"); // Auto-set in database

            // Define your static data
            modelBuilder.Entity<VehicleBrand>().HasData(
                new VehicleBrand { Id = sinotrukId, Name = "Sinotruk", Category = "Howo", Division = "T5G", SubDivision = "Heavy Trucks" },
                new VehicleBrand { Id = toyotaId, Name = "Toyota", Category = "Sedan", Division = "Camry", SubDivision = "Hybrid" },
                new VehicleBrand { Id = fordId, Name = "Ford", Category = "SUV", Division = "Explorer", SubDivision = "XLT" },
                new VehicleBrand { Id = teslaId, Name = "Tesla", Category = "Electric", Division = "Model S", SubDivision = "Plaid" },
                new VehicleBrand { Id = hondaId, Name = "Honda", Category = "Compact", Division = "Civic", SubDivision = "Sport" }
            );

            modelBuilder.Entity<VehicleModel>().HasData(
    new VehicleModel { Id = Guid.Parse("f17a7c8d-4a3b-4b81-b1e6-8d97b0f1a8c9"), ModelName = "Corolla", ModelYear = 2023, BrandId = toyotaId },
    new VehicleModel { Id = Guid.Parse("d91e3b7a-5c8e-4f72-a4d7-6c92b3d8a7e9"), ModelName = "Civic", ModelYear = 2022, BrandId = hondaId },
    new VehicleModel { Id = Guid.Parse("e8b2c7d6-3a9e-4b5f-bd17-2f3c9a7e6b8a"), ModelName = "F-150", ModelYear = 2024, BrandId = fordId }
);



            modelBuilder.Entity<VehicleType>().HasData(
               

                 new VehicleType
                 {
                     Id = pickupTypeId,
                     TypeName = "Passenger",
                     Category = "Sedan",
                     Division = "Compact",
                     SubDivision = "4-Door",
                     ChassisNo = null,
                     EngineNo = null,
                     SeatsNo = "5",
                     NomberOfCylinder = "4",
                     DoorsNo = "4",
                     Color = "Various",
                     TransmissionType = "Automatic",
                     SteeringType = "Left Hand",
                     FuelType = "Petrol",
                     FuelCapacity = "50L",
                     Altered = false,
                     Notes = "Standard passenger sedan"
                 },
            new VehicleType
            {
                Id = sedanTypeId,
                TypeName = "Transport",
                Category = "Pick Up",
                Division = "Pick Up 3 Ton",
                SubDivision = "Double Cabin",
                ChassisNo = null,
                EngineNo = null,
                SeatsNo = "6",
                NomberOfCylinder = "6",
                DoorsNo = "4",
                Color = "White",
                TransmissionType = "Manual",
                SteeringType = "Right Hand",
                FuelType = "Diesel",
                FuelCapacity = "80L",
                Altered = false,
                Notes = "Heavy-duty transport vehicle"
            },
            new VehicleType
            {
                Id = suvTypeId,
                TypeName = "Equipment",
                Category = "Construction",
                Division = "Excavator",
                SubDivision = "Hydraulic",
                ChassisNo = null,
                EngineNo = null,
                SeatsNo = "1",
                NomberOfCylinder = "8",
                DoorsNo = "1",
                Color = "Yellow",
                TransmissionType = "Hydraulic",
                SteeringType = "Joystick",
                FuelType = "Diesel",
                FuelCapacity = "200L",
                Altered = false,
                Notes = "Used for construction projects"
            }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = mainGarageId, LocationName = "Main Garage", ContactInCharge = "John Doe", ProjectName = "Fleet Management" , CostCenter= "Fleet Management" , DivisionName="Devision 1" },
                new Location { Id = eastWarehouseId, LocationName = "East Warehouse", ContactInCharge = "Jane Smith", ProjectName = "Logistics" , CostCenter="Logistics", DivisionName = "Devision 1" },
                new Location { Id = northYardId, LocationName = "North Yard", ContactInCharge = "Michael Brown", ProjectName = "Construction" , CostCenter="Construction", DivisionName = "Devision 1" },
                new Location { Id = westDepotId, LocationName = "West Depot", ContactInCharge = "Emily Davis", ProjectName = "Distribution" , CostCenter="Distribution", DivisionName = "Devision 1" },
                new Location { Id = southTerminalId, LocationName = "South Terminal", ContactInCharge = "Robert Wilson", ProjectName = "Transport Hub" , CostCenter="Transport Hub", DivisionName = "Devision 1" }
            );

            //modelBuilder.Entity<Driver>().HasData(
            //    new Driver { Id = driver1Id, Name = "John Smith", ContactNumber = "123-456-7890" },
            //    new Driver { Id = driver2Id, Name = "Alice Johnson", ContactNumber = "987-654-3210" },
            //    new Driver { Id = driver3Id, Name = "Michael Brown", ContactNumber = "456-789-1230" },
            //    new Driver { Id = driver4Id, Name = "Emily Davis", ContactNumber = "321-654-9870" },
            //    new Driver { Id = driver5Id, Name = "Robert Wilson", ContactNumber = "789-123-4560" }
            //);



            //// Pre-generate GUIDs for Permit and SafetyEquipment
            //var permit1Id = Guid.NewGuid();
            //var permit2Id = Guid.NewGuid();
            //var safetyEquipment1Id = Guid.NewGuid();
            //var safetyEquipment2Id = Guid.NewGuid();
            //var safetyEquipment3Id = Guid.NewGuid();
            //var safetyEquipment4Id = Guid.NewGuid();
            //var safetyEquipment5Id = Guid.NewGuid();

            //// Pre-generate GUIDs for Vehicle IDs
            //var vehicle1Id = Guid.NewGuid();
            //var vehicle2Id = Guid.NewGuid();
            //var vehicle3Id = Guid.NewGuid();
            //var vehicle4Id = Guid.NewGuid();
            //var vehicle5Id = Guid.NewGuid();

            //// Seed Permit data
            //modelBuilder.Entity<Permit>().HasData(
            //    new Permit { Id= new Guid("441d36b4-dfcd-4817-afe1-27a67a1b218c"),   PermitType = "Hazardous Waste Transport", PermitHolder = "WM", ValidUntil = new DateTime(2025, 12, 31) },
            //    new Permit { Id= new Guid("6fa5b8c6-6f12-4ace-8232-2c06454b64a1"), PermitType = "Large-Scale Shipments", PermitHolder = "ICS", ValidUntil = new DateTime(2024, 11, 30) }
            //);

            //// Seed SafetyEquipment data
            //modelBuilder.Entity<SafetyEquipment>().HasData(
            //    new SafetyEquipment { Id = safetyEquipment1Id, VehicleId = vehicle1Id, Name = "Spark Arrester", InstalledDate = new DateTime(2023, 1, 15), Purpose = "Prevents ignition in flammable environments" },
            //    new SafetyEquipment { Id = safetyEquipment2Id, VehicleId = vehicle2Id, Name = "Double-Walled Tank", InstalledDate = new DateTime(2023, 5, 10), Purpose = "Provides extra containment for liquids" },
            //    new SafetyEquipment { Id = safetyEquipment3Id, VehicleId = vehicle3Id, Name = "Emergency Shutoff Valve", InstalledDate = new DateTime(2023, 6, 1), Purpose = "Quickly stops flow of hazardous materials" },
            //    new SafetyEquipment { Id = safetyEquipment4Id, VehicleId = vehicle4Id, Name = "Leak Detection Sensor", InstalledDate = new DateTime(2023, 9, 5), Purpose = "Alerts operator to leaks/spills" },
            //    new SafetyEquipment { Id = safetyEquipment5Id, VehicleId = vehicle5Id, Name = "Explosion-Proof Lighting", InstalledDate = new DateTime(2024, 2, 11), Purpose = "Safe illumination in flammable zones" }
            //);



            base.OnModelCreating(modelBuilder);
        }
   
    
    }
}
