using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.PublicManagement
{
    public class SuperdealerEntity
    {
        public int? Super_dealer_id { get; set; }
        public string Super_dealer_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
