namespace Gas.Domain.Entity.SalesManagement
{
    public class AccessorySaleEntity
    {
        public int? Accessory_sale_id { get; set; }
        public int? Driver_id { get; set; }
        public string Driver_name { get; set; } = string.Empty;
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public int? Truck_id { get; set; }
        public string Plate_number { get; set; } = string.Empty;
        public int? Shop_id { get; set; }
        public string Shop_name { get; set; } = string.Empty;
        public string Sale_date { get; set; } = string.Empty;
        public int? Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class AccessorySalesItemEntity
    {
        public int? Accessory_sale_item_id { get; set; }
        public int? Accessory_id { get; set; }
        public string Accessory_name { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? Accessory_sale_id { get; set; }
    }

    public class AccessoryTotalSaleEntity
    {
        public string Accessory_name { get; set; } = string.Empty;
        public int? Total_quantity { get; set; }
        public decimal? Total_price { get; set; }
    }

}
