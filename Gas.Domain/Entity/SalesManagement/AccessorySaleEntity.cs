using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.SalesManagement
{
    public class AccessorySaleEntity
    {
        public int? Accessory_sale_id { get; set; }
        public int? Driver_id { get; set; }
        public string Driver_name { get; set; } = string.Empty;
        public int? Accessory_id { get; set; }
        public string Accessory_name { get; set; } = string.Empty;
        public int? Truck_id { get; set; }
        public string Plate_number { get; set; } = string.Empty;
        public int? Shop_id { get; set; }
        public string Shop_name { get; set; } = string.Empty;
        public string Sale_date { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}
