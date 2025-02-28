using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VehicleType : BaseEntity
    {
        public string TypeName { get; set; }
        public string Category { get; set; }
        public string Division { get; set; }

        
    }
}
