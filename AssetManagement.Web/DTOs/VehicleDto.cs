using AssetManagement.Domain.Entities;

namespace AssetManagement.Web.DTOs
{
    public class VehicleDto
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

        //Location
        public string LocationName { get; set; }
        public string ContactInCharge { get; set; }
        public string ProjectName { get; set; }
        public string CostCenter { get; set; }
        public string DivisionName { get; set; }

        public Guid VehicleTypeId { get; set; }    
        public VehicleType VehicleType { get; set; }  
        
        public Guid DriverId { get; set; }    
        public Driver Driver { get; set; }    

        public DocumentationDetails DocumentationDetails { get; set; }

        //Permits
        public ICollection<Permit> Permits { get; set; } = [];
        public ICollection<SafetyEquipment> SafetyEquipments { get; set; } = [];
        public ICollection<DriverSafetyCompliance> DriverSafetyCompliances { get; set; } = [];

    }
}
