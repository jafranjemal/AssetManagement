using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class SafetyEquipment : BaseEntity
    {
        public Guid VehicleId { get; set; }
        public string Name { get; set; }
        public DateTime InstalledDate { get; set; }
        public string Purpose { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
