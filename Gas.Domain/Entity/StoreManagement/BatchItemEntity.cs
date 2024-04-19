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

    public class FullBatchItemEntity
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
        public List<CylinderEntity> Cylinders { get; set; } = new List<CylinderEntity>();   
        public List<AccessoryEntity> Accessorys { get; set; } = new List<AccessoryEntity>();

    }

    public class CylinderEntity
    {
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

    public class AccessoryEntity
    {
        public int? Accessory_id { get; set; }
        public string Accessory_name { get; set; } = string.Empty;
        public int? Accessory_brand_id { get; set; }
        public string Accessory_brand_name { get; set; } = string.Empty;
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public int? Accessory_quantity { get; set; }
    }

}
