namespace Gas.Domain.Entity.StoreManagement
{
    public class AccessorystockEntity
    {
        public int? Accessory_id { get; set; }
        public string Accessory_name { get; set; } = string.Empty;
        public int? Total_quantity_in { get; set; }
        public int? Total_quantity_out { get; set; }
        public int? Total_quantity_remain { get; set; }
    }
}
