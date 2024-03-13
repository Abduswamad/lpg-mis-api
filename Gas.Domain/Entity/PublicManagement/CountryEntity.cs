using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.PublicManagement
{
    public class CountryEntity
    {
        public int? Country_id { get; set; }
        public string Country_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
