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

    public class AccessoryBatchItemListModel
    {
        public int? Accessoryid { get; set; }
        public int? Accessoryquantity { get; set; }
       
    }

    public class AddAccessoryBatchItemWithChecksModel
    {
        public int? Batchtype { get; set; }
        public int? Batchtruck { get; set; }
        public int? Batchdriver { get; set; }
        public int? Batchdepo { get; set; }
        public DateTime? Batchdate { get; set; }
        public int? Store { get; set; }
        public DateTime? Stockdate { get; set; }
        public List<AccessoryBatchItemListModel?> Accessors { get;set; } = new List<AccessoryBatchItemListModel?>();

    }

}
