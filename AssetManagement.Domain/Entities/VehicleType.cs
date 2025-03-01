using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VehicleType : BaseEntity
    {
        public string TypeName { get; set; } //(Passenger/Transport/Equipment)
        public string Category { get; set; } // Pick Up
        public string Division { get; set; } // Pick Up 3 Ton
        public string SubDivision { get; set; } // Ouble cabin
        public string? ChassisNo { get; set; } 
        public string? EngineNo { get; set; } 

        public string? SeatsNo { get; set; } 
        public string? NomberOfCylinder { get; set; } 
        public string? DoorsNo { get; set; } 
        public string? Color { get; set; } 
        public string? TransmissionType { get; set; } 
        public string? SteeringType { get; set; } 
      
        public string? FuelType { get; set; } 
        public string? FuelCapacity { get; set; } 
        public bool Altered { get; set; } = false;
        public string? Notes { get; set; } = "";

        // Relationship: One VehicleType can be used by multiple Vehicles
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }

}
