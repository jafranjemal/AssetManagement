using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class Permit : BaseEntity
    {
       
        public string PermitType { get; set; }
        public string PermitHolder { get; set; }
        public string PermitDetails { get; set; }
        public DateTime ValidUntil { get; set; }

        

    }
}
