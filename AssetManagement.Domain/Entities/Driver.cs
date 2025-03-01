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
   
        public ICollection<DriverSafetyCompliance> SafetyCompliances { get; set; } = [];
    }
}
