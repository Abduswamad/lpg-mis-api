namespace Gas.Domain.Entity.StoreManagement
{
    public class AccessoryBatchItemEntity
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
        public int? Accessory_id { get; set; }
        public string Accessory_name { get; set; } = string.Empty;
        public int? Accessory_brand_id { get; set; }
        public string Accessory_brand_name { get; set; } = string.Empty;
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public int? Accessory_quantity { get; set; }
    }

}
