namespace Gas.Model.SalesManagement
{
    public class AddCylinderSaleModel
    {
        public int? Driverid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
        public int? Superdealer { get; set; }

    }
    public class InsCylinderSaleModel
    {
        public int? CylinderSaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
        public int? Superdealer { get; set; }
    }


    public class GetCylinderSaleModel
    {
        public int? CylinderSaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? Superdealer { get; set; }
        public double? Saleprice { get; set; }

    }

    public class DeleteCylinderSaleModel
    {
        public int? CylinderSaleid { get; set; }
    }

    public class DeleteCylinderSalesItemModel
    {
        public int? CylinderSaleid { get; set; }
        public int? CylinderSaleItemid { get; set; }
    }

    public class SalesTotalModel
    {
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
    }


}
