using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.SalesManagement
{
    public class AddCylinderSaleModel
    {
        public int? Driverid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylindercategory { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? Salequantity { get; set; }
        public double? Saleprice { get; set; }
        public string Saledescription { get; set; } = string.Empty;

    }
    public class InsCylinderSaleModel
    {
        public int? CylinderSaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylindercategory{ get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? Salequantity { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
    }


    public class GetCylinderSaleModel
    {
        public int? CylinderSaleid { get; set; }
        public int? Cylindercategory { get; set; }
        public int? Driverid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? Salequantity { get; set; }
        public double? Saleprice { get; set; }

    }

    public class DeleteCylinderSaleModel
    {
        public int? CylinderSaleid { get; set; }
    }


}
