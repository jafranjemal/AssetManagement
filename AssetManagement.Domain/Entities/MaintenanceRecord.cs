using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class MaintenanceRecord : BaseEntity
    {
        public Guid VehicleId { get; set; }
        public string MaintenanceType { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Notes { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
