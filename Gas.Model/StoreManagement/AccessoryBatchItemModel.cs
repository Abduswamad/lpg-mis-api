using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.StoreManagement
{
    public class AddAccessoryBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Accessoryquantity { get; set; }

    }
    public class InsAccessoryBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Accessoryquantity { get; set; }
    }

    public class DelAccessoryBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Accessoryid { get; set; }
    }


    public class GetAccessoryBatchItemModel
    {
        public int? Batchid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Accessoryquantity { get; set; }
    }

    public class AccessorystockModel
    {
        public int? Store { get; set; }
        public int? Accessoryid { get; set; }
        public DateTime? Stockdate { get; set; }

    }

}
