using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.SalesManagement
{
    public class AddAccessorySaleModel
    {
        public int? Driverid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? Salequantity { get; set; }
        public double? Saleprice { get; set; }
        public string Saledescription { get; set; } = string.Empty;

    }
    public class InsAccessorySaleModel
    {
        public int? AccessorySaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? Salequantity { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
    }


    public class GetAccessorySaleModel
    {
        public int? AccessorySaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Accessoryid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? Salequantity { get; set; }
        public double? Saleprice { get; set; }

    }

    public class DeleteAccessorySaleModel
    {
        public int? AccessorySaleid { get; set; }
    }


}
