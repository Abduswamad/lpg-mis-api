namespace Gas.Domain.Entity.SalesManagement
{
    public class CylinderSaleEntity
    {
        public int? Cylinder_sale_id { get; set; }
        public int? Driver_id { get; set; }
        public string Driver_name { get; set; } = string.Empty;
        public int? Truck_id { get; set; }
        public string Plate_number { get; set; } = string.Empty;
        public int? Shop_id { get; set; }
        public string Shop_name { get; set; } = string.Empty;
        public string Sale_date { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
    }

    public class CylinderSalesItemEntity
    {
        public int? Cylinder_sale_item_id { get; set; }
        public int? Cylinder_id { get; set; }
        public string Cylinder_name { get; set; } = string.Empty;
        public int? Cylinder_category_id { get; set; }
        public string Cylinder_category_name { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? Cylinder_sale_id { get; set; }
    }

    public class CylinderTotalSaleEntity
    {
        public string Cylinder_name { get; set; } = string.Empty;
        public string Cylinder_category_name { get; set; } = string.Empty;
        public int? Total_quantity { get; set; }
        public decimal? Total_price { get; set; }
    }

}
