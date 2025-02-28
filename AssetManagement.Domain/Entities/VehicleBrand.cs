using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VehicleBrand : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        

        public ICollection<VehicleModel> Models { get; set; } = [];

       
    }
}
