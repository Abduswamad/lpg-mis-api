using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.StoreManagement
{
    public class CylinderstockEntity
    {
        public int? Cylinder_id { get; set; }
        public string Cylinder_name { get; set; } = string.Empty;
        public int? Cylinder_status_id { get; set; }
        public string Cylinder_status_name { get; set; } = string.Empty;
        public int? Total_quantity_in { get; set; }
        public int? Total_quantity_out { get; set; }
        public int? Total_quantity_remain { get; set; }
    }
}
