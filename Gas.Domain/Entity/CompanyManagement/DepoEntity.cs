using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.CompanyManagement
{
    public class DepoEntity
    {
        public int? Depo_id { get; set; }
        public string Depo_name { get; set; } = string.Empty;    
        public string House_number { get; set; } = string.Empty;
        public int? Common_street_id { get; set; }
        public string Common_street_name { get; set; } = string.Empty;
        public int? Ward_id { get; set; }
        public string Ward_name { get; set; } = string.Empty;
        public int? District_id { get; set; }
        public string District_name { get; set; } = string.Empty;
        public int? Region_id { get; set; }
        public string Region_name { get; set; } = string.Empty;
        public int? Country_id { get; set; }
        public string Country_name { get; set; } = string.Empty;
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
