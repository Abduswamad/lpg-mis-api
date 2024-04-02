using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.SalesManagement
{
    public class CylinderIndicativePriceEntity
    {
        public int? Cylinder_indicative_price_id { get; set; }
        public int? Cylinder_id { get; set; }
        public string Cylinder_name { get; set; } = string.Empty;
        public int? Cylinder_category_id { get; set; }
        public string Cylinder_category_name { get; set; } = string.Empty;
        public float? Selling_price { get; set; }
        public float? Buying_price { get; set; }
        public bool? Is_active { get; set; }
    }

}
