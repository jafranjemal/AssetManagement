using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VehicleBrand : BaseEntity
    {
        public string Name { get; set; } //Howo T5G SinoTruck
        public string Category { get; set; } // Sinotruck
        public string Division { get; set; } // Howo
        public string SubDivision { get; set; } //T5G
        

        public ICollection<VehicleModel> Models { get; set; } = [];

       
    }
}
