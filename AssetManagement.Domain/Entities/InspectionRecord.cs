using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class InspectionRecord : BaseEntity
    {
        public Guid VehicleId { get; set; }
        public DateTime LastInspection { get; set; }
        public DateTime NextInspection { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
