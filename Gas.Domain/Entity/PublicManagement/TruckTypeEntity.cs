using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.PublicManagement
{
    public class TrucktypeEntity
    {
        public int? Truck_type_id { get; set; }
        public string Truck_type_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
