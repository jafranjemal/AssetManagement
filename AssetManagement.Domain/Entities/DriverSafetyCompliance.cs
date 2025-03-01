using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class DriverSafetyCompliance : BaseEntity
    {
        public Guid DriverId { get; set; } // Foreign Key to Driver
        public Driver? Driver { get; set; }

        public Guid SafetyCriteriaId { get; set; } // Foreign Key to SafetyCriteria
        public SafetyCriteria? SafetyCriteria { get; set; }

        public DateTime DateCompleted { get; set; } // When the driver completed the requirement
        public DateTime? ExpiryDate { get; set; } // If applicable, when it expires
        public bool IsCertified { get; set; } // Whether the driver is certified
    }

}
