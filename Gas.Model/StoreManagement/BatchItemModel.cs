using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.StoreManagement
{
    public class AddBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylinderstatus { get; set; }
        public int? Cylinderquantity { get; set; }

    }
    public class InsBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylinderstatus { get; set; }
        public int? Cylinderquantity { get; set; }
    }

    public class DelBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylinderstatus { get; set; }
    }


    public class GetBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylinderstatus { get; set; }
        public int? Cylinderquantity { get; set; }
    }

}
