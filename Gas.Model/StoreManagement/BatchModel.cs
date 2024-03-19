using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.StoreManagement
{
    public class AddBatchModel
    {
        public int? Batchtype { get; set; }
        public int? Batchtruck { get; set; }
        public int? Batchdriver { get; set; }
        public int? Batchdepo { get; set; }
        public DateTime? Batchdate { get; set; }

    }
    public class InsBatchModel
    {
        public int? Batchid { get; set; }
        public int? Batchtype { get; set; }
        public int? Batchtruck { get; set; }
        public int? Batchdriver { get; set; }
        public int? Batchdepo { get; set; }
        public DateTime? Batchdate { get; set; }

    }


    public class GetBatchModel
    {
        public int? Batchid { get; set; }
        public int? Batchtype { get; set; }
        public int? Batchtruck { get; set; }
        public int? Batchdriver { get; set; }
        public int? Batchdepo { get; set; }
        public DateTime? Batchdate { get; set; }
        public bool? IsActive { get; set; }

    }

    public class CylinderstockModel
    {
        public int? Store { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylinderstatusid { get; set; }
        public DateTime? Stockdate { get; set; }

    }


}
