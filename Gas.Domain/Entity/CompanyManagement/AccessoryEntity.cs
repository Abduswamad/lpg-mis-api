namespace Gas.Domain.Entity.CompanyManagement
{
    public class AccessoryEntity
    {
        public int? Accessory_id { get; set; }
        public string Accessory_name { get; set; } = string.Empty;    
        public int? Accessory_brand_id { get; set; }
        public string Accessory_brand_name { get; set; } = string.Empty;
        public int? Super_dealer { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
