using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.PublicManagement
{
    public class CylindercategoryEntity
    {
        public int? Cylinder_category_id { get; set; }
        public string Cylinder_category_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
