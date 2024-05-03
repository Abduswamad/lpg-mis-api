namespace Gas.Domain.Entity.CompanyManagement
{
    public class RoleEntity
    {
        public int? Role_id { get; set; }
        public string Role_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
