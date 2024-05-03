namespace Gas.Domain.Entity.CompanyManagement
{
    public class TruckEntity
    {
        public int? Truck_id { get; set; }
        public string Plate_number { get; set; } = string.Empty;
        public float? Weigth_in_tones { get; set; }      
        public int? Truck_type_id { get; set; }
        public string Truck_type_name { get; set; } = string.Empty;
        public int? Driver_id { get; set; }
        public string Driver_name { get; set; } = string.Empty;
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
