namespace Gas.Domain.Entity.PublicManagement
{
    public class WardEntity
    {
        public int? Ward_id { get; set; }
        public string Ward_name { get; set; } = string.Empty;
        public int? District_id { get; set; }
        public string District_name { get; set; } = string.Empty;
        public int? Region_id { get; set; }
        public string Region_name { get; set; } = string.Empty;
        public int? Country_id { get; set; }
        public string Country_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
