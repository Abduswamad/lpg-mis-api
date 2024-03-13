using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.PublicManagement
{
    public class AccessorybrandEntity
    {
        public int? Accessory_brand_id { get; set; }
        public string Accessory_brand_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
