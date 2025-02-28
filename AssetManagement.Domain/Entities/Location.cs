using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string LocationName { get; set; }
        public string ContactInCharge { get; set; }
        public string ProjectName { get; set; }
        public string CostCenter { get; set; }
        public string DivisionName { get; set; }

        
    }
}
