using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class DriverCertification : BaseEntity
    {
        public Guid DriverId { get; set; }
        public string CertificationName { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Driver Driver { get; set; }
    }
}
