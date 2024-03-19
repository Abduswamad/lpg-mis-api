using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.StoreManagement
{
    public class BatchtypeEntity
    {
        public int? Batch_type_id { get; set; }
        public string Batch_type_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
