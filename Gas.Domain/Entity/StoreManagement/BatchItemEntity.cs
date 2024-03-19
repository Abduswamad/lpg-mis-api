using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.StoreManagement
{
    public class BatchItemEntity
    {
        public int? Batch_id { get; set; }
        public int? Batch_type_id { get; set; }
        public string Batch_type_name { get; set; } = string.Empty;
        public int? Truck_id { get; set; }
        public string Plate_number { get; set; } = string.Empty;
        public int? Driver_id { get; set; }
        public string Driver_name { get; set; } = string.Empty;
        public int? Depo_id { get; set; }
        public string Depo_name { get; set; } = string.Empty;
        public DateTime Batch_date { get; set; }
        public int? Cylinder_id { get; set; }
        public string Cylinder_name { get; set; } = string.Empty;
        public int? Cylinder_company_id { get; set; }
        public string Cylinder_company_name { get; set; } = string.Empty;
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public int? Cylinder_status_id { get; set; }
        public string Cylinder_status_name { get; set; } = string.Empty;
        public int? Cylinder_quantity { get; set; }
    }

}
