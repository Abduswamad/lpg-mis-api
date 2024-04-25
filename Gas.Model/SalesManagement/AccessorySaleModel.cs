namespace Gas.Model.SalesManagement
{
    public class AddAccessorySaleModel
    {
        public int? Driverid { get; set; }
        public int? Superdealer { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string Saledescription { get; set; } = string.Empty;

    }
    public class InsAccessorySaleModel
    {
        public int? AccessorySaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Superdealer { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
    }
    public class AddAccessorySaleItemModel
    {
        public int? AccessoryId { get; set; }
        public int? SaleQuantity { get; set; }
        public double? Saleprice { get; set; }
        public int? Accessorysaleid { get; set; }
    }

    public class InsAccessorySaleItemModel
    {
        public int? AccessorySaleItemid { get; set; }
        public int? AccessoryId { get; set; }
        public int? SaleQuantity { get; set; }
        public double? Saleprice { get; set; }
        public int? Accessorysaleid { get; set; }
    }

    public class AddAccessorySaleWithItemModel
    {
        public int? Driverid { get; set; }
        public int? Superdealer { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
        public List<AddAccessorySaleItemModel> AccessorySalesItem { get; set; } = new List<AddAccessorySaleItemModel>();
    }

    public class InsAccessorySaleWithItemModel
    {
        public int? AccessorySaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Superdealer { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public double? Saleprice { get; set; }
        public string? Saledescription { get; set; }
        public List<InsAccessorySaleItemModel> AccessorySalesItem { get; set; } = new List<InsAccessorySaleItemModel>();
    }

    public class GetAccessorySaleModel
    {
        public int? AccessorySaleid { get; set; }
        public int? Driverid { get; set; }
        public int? Truckid { get; set; }
        public int? Shopid { get; set; }
        public DateTime? Saledate { get; set; }
        public int? SuperDealer { get; set; }
        public double? Saleprice { get; set; }

    }

    public class GetAccessorySalesItemModel
    {
        public int? AccessorySaleItemId { get; set; }
        public int? AccessoryId { get; set; }
        public int? SaleQuantity { get; set; }
        public double? Saleprice { get; set; }
        public int? AccessorySaleId { get; set; }

    }

    public class DeleteAccessorySaleModel
    {
        public int? AccessorySaleid { get; set; }
    }

    public class DeleteAccessorySalesItemModel
    {
        public int? AccessorySaleid { get; set; }
        public int? AccessorySaleItemid { get; set; }
    }


}
