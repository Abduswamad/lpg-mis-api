using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.SalesManagement
{
    public class AddAccessoryIndicativePriceModel
    {
        public int? Accessoryid { get; set; }
        public int? Superdealer { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }

    }
    public class InsAccessoryIndicativePriceModel
    {
        public int? Accessoryindicativepriceid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Superdealer { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }

    }

    public class UpdateAccessoryIndicativePriceModel
    {
        public int? Accessoryindicativepriceid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Superdealer { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }

    }


    public class GetAccessoryIndicativePriceModel
    {
        public int? Accessoryindicativepriceid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Superdealer { get; set; }
        public float? Sellingprice { get; set; }
        public float? Buyingprice { get; set; }
        public bool? IsActive { get; set; }

    }

    public class UpdateAccessoryIndicativePriceStatusModel
    {
        public int? Accessoryindicativepriceid { get; set; }
        public bool? IsActive { get; set; }

    }



}
