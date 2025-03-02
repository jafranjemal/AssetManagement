using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VehicleModel : BaseEntity
    {
        public string ModelName { get; set; } //ZZ45454515
        public string ModelNo { get; set; } = ""; //ZZ45454515
        public int ModelYear { get; set; } //2024
        public Guid BrandId { get; set; } 
        public VehicleBrand Brand { get; set; }
    }
}
