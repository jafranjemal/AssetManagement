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
        public string VehicleName { get; set; }

        public string VehicleStatus { get; set; } // Active, Alert
        public string OperationalStatus { get; set; } // On Project, Internal, Standby, Replacement, Pool
        public string CurrentStattionlStatus { get; set; } // On Site/On Garage / On Yard Khor
        public string MaintenanceStatus { get; set; } // Good Condition, Minor , Urgent


       

        //Engine Details
        public decimal EngineCo2Emission { get; set; }  // 180
        public decimal Co2Standard { get; set; }  // 160-200
        public int Horsepower { get; set; }
        public string EmissionSpec { get; set; }



        //DocumentationDetails
        public DocumentationDetails DocumentationDetails { get; set; }

        //VehicleFinance 
        public decimal InitialManufacturerPrice { get; set; }  // Brand new price
        public decimal PurchaseValue { get; set; }  // Actual purchase price
        public decimal EstimatedEndOfTermValue { get; set; }  // Depreciated value

        public Guid? TypeId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? AssignedDriverId { get; set; }

        public VehicleType Type { get; set; }
        public Location Location { get; set; }
        public Driver AssignedDriver { get; set; }
        public ICollection<Permit> Permits { get; set; } = [];
       // public ICollection<SafetyEquipment> SafetyEquipments { get; set; }
        public ICollection<VehicleEquipment> InstalledEquipment { get; set; } = [];


        public Guid BrandId { get; set; }
        public Guid ModelId { get; set; }
       
         
        public DateTime? LastInspection { get; set; }
        public DateTime? NextInspection { get; set; }
      


        public VehicleBrand Brand { get; set; }
        public VehicleModel Model { get; set; }
     
       
       
       
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
       
    }
}
