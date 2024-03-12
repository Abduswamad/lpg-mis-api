using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.PublicManagement
{
    public class CylindercompanyEntity
    {
        public int? Cylinder_company_id { get; set; }
        public string Cylinder_company_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
