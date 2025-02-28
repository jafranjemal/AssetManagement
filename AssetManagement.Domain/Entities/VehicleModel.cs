using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VehicleModel : BaseEntity
    {
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public Guid BrandId { get; set; }
        public VehicleBrand Brand { get; set; }
    }
}
