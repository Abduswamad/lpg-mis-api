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

    public class AddCylinderSalesItemModel
    {
        public int? CylinderId { get; set; }
        public int? CylinderCategory { get; set; }
        public int? SaleQuantity { get; set; }
        public double? Saleprice { get; set; }
       // public int? CylinderSaleId { get; set; }
    }

    public class InsCylinderSalesItemModel
    {
        public int? Cylindersaleitemid { get; set; }
        public int? CylinderId { get; set; }
        public int? CylinderCategory { get; set; }
        public int? SaleQuantity { get; set; }
        public double? Saleprice { get; set; }
        public int? CylinderSaleId { get; set; }
    }

    public class AddCylinderSalesWithItemModel
    {
        public int? Driverid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
        public int? Superdealer { get; set; }
        public List<AddCylinderSalesItemModel> CylinderSalesItem { get; set; } = new List<AddCylinderSalesItemModel>();
    }

    public class InsCylinderSalesWithItemModel
    {
        public int? CylinderSaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
        public int? Superdealer { get; set; }
        public List<InsCylinderSalesItemModel> CylinderSalesItem { get; set; } = new List<InsCylinderSalesItemModel>();
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

    public class GetCylinderSalesItemModel
    {
        public int? CylinderSaleItemid { get; set; }
        public int? Cylinderid { get; set; }
        public int? Cylindercategory { get; set; }
        public int? Salequantity { get; set; }
        public double? Saleprice { get; set; }
        public int? Cylindersaleid { get; set; }

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
