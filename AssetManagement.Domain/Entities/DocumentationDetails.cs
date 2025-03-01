using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class DocumentationDetails : BaseEntity
    {
        public DateTime? RoadPermitExpiry { get; set; }
        public DateTime? InsuranceExpiry { get; set; }
        public int? DuplicateKeySerialNo { get; set; }
        public int? FileNo { get; set; }
        public int? GPS_GSM { get; set; }
        public int? GPS_ID { get; set; }
        public string GPSType { get; set; } = "Normal Tracker"; //IVMS FUll , IVMS Partial
        public string? GPSServiceVendorName { get; set; }
        public int? YearMade { get; set; }
        public string? OwnershipStatus { get; set; }
        public string? MadeIn { get; set; }
        public string? LastOdometer { get; set; }
        public DateTime? FirstRegisteredWithUsOn { get; set; }
        public DateTime? CancellationDate { get; set; }
    }
}
