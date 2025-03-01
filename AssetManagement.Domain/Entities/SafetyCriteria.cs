using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class SafetyCriteria : BaseEntity
    {
        public string CriteriaName { get; set; } // Name of the certification/training
        public string RequiredBy { get; set; } // Who requires it (Insurance, HR, Government, etc.)
        public string Purpose { get; set; } // The reason for the requirement
        public string Notes { get; set; } // Additional information
    }

}
