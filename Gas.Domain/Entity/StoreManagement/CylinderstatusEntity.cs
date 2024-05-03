namespace Gas.Domain.Entity.StoreManagement
{
    public class CylinderstatusEntity
    {
        public int? Cylinder_status_id { get; set; }
        public string Cylinder_status_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
