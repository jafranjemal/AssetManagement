using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VehicleEquipment : BaseEntity
    {
        public string EquipmentName { get; set; } // Name of the equipment
        public DateTime InstalledDate { get; set; } // Date it was installed
        public string Purpose { get; set; } // Why it is used
        public string Notes { get; set; } // Additional remarks

        public Guid VehicleId { get; set; } // Foreign Key to Vehicle
        public Vehicle Vehicle { get; set; } // Navigation Property
    }

}
