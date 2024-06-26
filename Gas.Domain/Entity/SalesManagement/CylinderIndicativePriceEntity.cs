﻿namespace Gas.Domain.Entity.SalesManagement
{
    public class AccessoryIndicativePriceEntity
    {
        public int? Accessory_indicative_price_id { get; set; }
        public int? Accessory_id { get; set; }
        public string Accessory_name { get; set; } = string.Empty;
        public float? Selling_price { get; set; }
        public float? Buying_price { get; set; }
        public bool? Is_active { get; set; }
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
    }

}
