using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.SalesManagement
{
    public class AddCylinderIndicativePriceModel
    {
        public int? Cylinderid { get; set; }
        public int? Cylindercategory { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }

    }
    public class InsCylinderIndicativePriceModel
    {
        public int? Cylinderindicativepriceid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylindercategory { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }

    }

    public class UpdateCylinderIndicativePriceModel
    {
        public int? Cylinderindicativepriceid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylindercategory { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }

    }


    public class GetCylinderIndicativePriceModel
    {
        public int? Cylinderindicativepriceid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylindercategory { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }
        public bool? IsActive { get; set; }

    }

    public class UpdateCylinderIndicativePriceStatusModel
    {
        public int? Cylinderindicativepriceid { get; set; }
        public bool? IsActive { get; set; }

    }



}
