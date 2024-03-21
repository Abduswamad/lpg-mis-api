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

    public class CylinderBatchItemListModel
    {
        public int? Cylinderid { get; set; }
        public int? Cylinderstatus { get; set; }
        public int? Cylinderquantity { get; set; }
    }
    public class AddCylinderBatchItemWithChecksModel
    {
        public int? Batchtype { get; set; }
        public int? Batchtruck { get; set; }
        public int? Batchdriver { get; set; }
        public int? Batchdepo { get; set; }
        public DateTime? Batchdate { get; set; }
        public int? Store { get; set; }
        public DateTime? Stockdate { get; set; }
        public List<CylinderBatchItemListModel?> Cylinders { get; set; } = new List<CylinderBatchItemListModel?>();

    }

}
