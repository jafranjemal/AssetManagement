using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string SystemId { get; set; }
        public string PlateNumber { get; set; }
        public Guid BrandId { get; set; }
        public Guid ModelId { get; set; }
        public Guid TypeId { get; set; }     
        public Guid LocationId { get; set; }
        public Guid? AssignedDriverId { get; set; }
        public string FuelType { get; set; }
        public int FuelCapacity { get; set; }
        public string TransmissionType { get; set; }
        public string SteeringType { get; set; }
        public int Horsepower { get; set; }
        public int Co2Emission { get; set; }
        public string GpsId { get; set; }
        public string TrackerType { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal EstimatedEndTermValue { get; set; }
        public DateTime? LastInspection { get; set; }
        public DateTime? NextInspection { get; set; }
        public string VehicleStatus { get; set; }
        public string OperationalStatus { get; set; }
        public string MaintenanceStatus { get; set; }


        public VehicleBrand Brand { get; set; }
        public VehicleModel Model { get; set; }
        public VehicleType Type { get; set; }
        public Location Location { get; set; }
        public Driver AssignedDriver { get; set; }
        public ICollection<Permit> Permits { get; set; }
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
        public ICollection<SafetyEquipment> SafetyEquipments { get; set; }
    }
}
