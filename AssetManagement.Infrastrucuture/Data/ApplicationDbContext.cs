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
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<InspectionRecord> InspectionRecords { get; set; }
        public DbSet<DriverCertification> DriverCertifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Pre-generate GUIDs and DateTime values
            var sinotrukId = Guid.NewGuid();
            var toyotaId = Guid.NewGuid();
            var fordId = Guid.NewGuid();
            var teslaId = Guid.NewGuid();
            var hondaId = Guid.NewGuid();

            var pickupTypeId = Guid.NewGuid();
            var sedanTypeId = Guid.NewGuid();
            var suvTypeId = Guid.NewGuid();
            var electricTypeId = Guid.NewGuid();
            var truckTypeId = Guid.NewGuid();

            var mainGarageId = Guid.NewGuid();
            var eastWarehouseId = Guid.NewGuid();
            var northYardId = Guid.NewGuid();
            var westDepotId = Guid.NewGuid();
            var southTerminalId = Guid.NewGuid();

            var driver1Id = Guid.NewGuid();
            var driver2Id = Guid.NewGuid();
            var driver3Id = Guid.NewGuid();
            var driver4Id = Guid.NewGuid();
            var driver5Id = Guid.NewGuid();


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

            

            // Permit relationship
            modelBuilder.Entity<Permit>()
                .HasOne(p => p.Vehicle)
                .WithMany(v => v.Permits)
                .HasForeignKey(p => p.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Safety Equipment relationship
            modelBuilder.Entity<SafetyEquipment>()
                .HasOne(se => se.Vehicle)
                .WithMany(v => v.SafetyEquipments)
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
       


            // Define your static data
            //modelBuilder.Entity<VehicleBrand>().HasData(
            //    new VehicleBrand { Id = sinotrukId, Name = "Sinotruk", Category = "Howo", Division = "T5G", SubDivision = "Heavy Trucks" },
            //    new VehicleBrand { Id = toyotaId, Name = "Toyota", Category = "Sedan", Division = "Camry", SubDivision = "Hybrid" },
            //    new VehicleBrand { Id = fordId, Name = "Ford", Category = "SUV", Division = "Explorer", SubDivision = "XLT" },
            //    new VehicleBrand { Id = teslaId, Name = "Tesla", Category = "Electric", Division = "Model S", SubDivision = "Plaid" },
            //    new VehicleBrand { Id = hondaId, Name = "Honda", Category = "Compact", Division = "Civic", SubDivision = "Sport" }
            //);

            //modelBuilder.Entity<VehicleType>().HasData(
            //    new VehicleType { Id = pickupTypeId, TypeName = "Pickup", Category = "Light Vehicles", Division = "Transport" },
            //    new VehicleType { Id = sedanTypeId, TypeName = "Sedan", Category = "Passenger Vehicles", Division = "City Transport" },
            //    new VehicleType { Id = suvTypeId, TypeName = "SUV", Category = "Off-Road Vehicles", Division = "All-Terrain" },
            //    new VehicleType { Id = electricTypeId, TypeName = "Electric", Category = "Eco-Friendly", Division = "Sustainable Mobility" },
            //    new VehicleType { Id = truckTypeId, TypeName = "Truck", Category = "Heavy Duty", Division = "Industrial Transport" }
            //);

            //modelBuilder.Entity<Location>().HasData(
            //    new Location { Id = mainGarageId, LocationName = "Main Garage", ContactInCharge = "John Doe", ProjectName = "Fleet Management" },
            //    new Location { Id = eastWarehouseId, LocationName = "East Warehouse", ContactInCharge = "Jane Smith", ProjectName = "Logistics" },
            //    new Location { Id = northYardId, LocationName = "North Yard", ContactInCharge = "Michael Brown", ProjectName = "Construction" },
            //    new Location { Id = westDepotId, LocationName = "West Depot", ContactInCharge = "Emily Davis", ProjectName = "Distribution" },
            //    new Location { Id = southTerminalId, LocationName = "South Terminal", ContactInCharge = "Robert Wilson", ProjectName = "Transport Hub" }
            //);

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
            //    new Permit { Id = permit1Id, VehicleId = vehicle1Id, PermitType = "Hazardous Waste Transport", PermitHolder = "WM", ValidUntil = new DateTime(2025, 12, 31) },
            //    new Permit { Id = permit2Id, VehicleId = vehicle2Id, PermitType = "Large-Scale Shipments", PermitHolder = "ICS", ValidUntil = new DateTime(2024, 11, 30) }
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
