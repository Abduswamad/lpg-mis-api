namespace Gas.Domain.Entity.PublicManagement
{
    public class DistrictEntity
    {
        public int? District_id { get; set; }
        public string District_name { get; set; } = string.Empty;
        public int? Region_id { get; set; }
        public string Region_name { get; set; } = string.Empty;
        public int? Country_id { get; set; }
        public string Country_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
