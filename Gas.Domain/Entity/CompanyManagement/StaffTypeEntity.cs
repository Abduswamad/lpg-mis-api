namespace Gas.Domain.Entity.CompanyManagement
{
    public class StaffTypeEntity
    {
        public int? Staff_type_id { get; set; }
        public string Staff_type_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
