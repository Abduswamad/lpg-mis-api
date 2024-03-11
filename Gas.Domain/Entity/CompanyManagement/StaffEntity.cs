using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.CompanyManagement
{
    public class StaffEntity
    {
        public int? Staff_id { get; set; }
        public string First_name { get; set; } = string.Empty;
        public string Staff_id_number { get; set; } = string.Empty;
        public string Middle_name { get; set; } = string.Empty;
        public string Last_name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Phone_number { get; set; } = string.Empty;
        public string Staff_password { get; set; } = string.Empty;
        public int? Gender_id { get; set; }
        public string Gender_name { get; set; } = string.Empty;
        public int? Staff_type_id { get; set; }
        public string Staff_type_name { get; set; } = string.Empty;
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
        public bool Is_active { get; set; }
        public bool Is_first_time { get; set; }
    }
}
