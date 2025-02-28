using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public Guid? AssignedVehicleId { get; set; }
        public Vehicle? AssignedVehicle { get; set; } = null;
        public ICollection<DriverCertification> Certifications { get; set; } = [];
    }
}
