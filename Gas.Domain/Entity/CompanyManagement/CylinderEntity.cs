namespace Gas.Domain.Entity.CompanyManagement
{
    public class CylinderEntity
    {
        public int? Cylinder_id { get; set; }
        public string Cylinder_name { get; set; } = string.Empty;    
        public int? Cylinder_company_id { get; set; }
        public string Cylinder_company_name { get; set; } = string.Empty;
        public int? Super_dealer { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
