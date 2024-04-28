using Gas.Model.SalesManagement;
using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaSalesManagement
{
    public static class SpAccessorySale
    {
        #region procedures
        private static readonly string dbSchema = "sales.";
        private static readonly string insertAccessorySaleqry = $"{dbSchema}ufn_insert_accessory_sale";
        private static readonly string insertAccessorySaleItemqry = $"{dbSchema}ufn_insert_accessory_sale_item";
        private static readonly string getAccessorySaleqry = $"{dbSchema}ufn_select_accessory_sale";
        private static readonly string getAccessorySalesItemqry = $"{dbSchema}ufn_select_accessory_sale_item";
        private static readonly string deleteAccessorySaleqry = $"{dbSchema}ufn_delete_accessory_sale";
        private static readonly string deleteAccessorySalesItemqry = $"{dbSchema}ufn_delete_accessory_sale_item";
        private static readonly string getAccessoryTotalSaleqry = $"{dbSchema}ufn_select_accessory_sale_total";
        private static readonly string getAccessorySale = $"SELECT * FROM {getAccessorySaleqry}()";
        private static readonly string getAccessorySalesItem = $"SELECT * FROM {getAccessorySalesItemqry}()";


        #endregion procedures

        #region sp for AccessorySale
        // public static string getAccessorySale = getAccessorySale;

        public static string SpGetAccessorySale(GetAccessorySaleModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getAccessorySale;
            }
            else
            {
              string  qry = $"SELECT * FROM {getAccessorySaleqry}({(rqModel.AccessorySaleid != null ? $"accessorysaleid := {rqModel.AccessorySaleid}, " : "")} " +
                      $"{(rqModel.Driverid != null ? $"driverid := {rqModel.Driverid}, " : "")} " +
                      $"{(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(rqModel.Saledate != null ? $"saledate := '{rqModel.Saledate?.ToString("yyyy-MM-dd")}', " : "")} " +
                      $"{(rqModel.SuperDealer != null ? $"superDealer := {rqModel.SuperDealer}, " : "")} " +
                      $"{(rqModel.Shopid != null ? $"shopid := {rqModel.Shopid}, " : "")} " +
                      $")";

                string input = qry;
                int lastCommaIndex = input.LastIndexOf(',');

                if (lastCommaIndex >= 0)
                {
                     result = input.Remove(lastCommaIndex, 1);
                }
                else
                {
                    result = qry;
                }

            }

            return result;
        }

        public static string SpGetAccessorySalesItem(GetAccessorySalesItemModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getAccessorySalesItem;
            }
            else
            {
                string qry = $"SELECT * FROM {getAccessorySalesItemqry}({(rqModel.AccessorySaleItemId != null ? $"accessorysaleitemid := {rqModel.AccessorySaleItemId}, " : "")} " +
                        $"{(rqModel.AccessoryId != null ? $"accessoryid := {rqModel.AccessoryId}, " : "")} " +
                        $"{(rqModel.SaleQuantity != null ? $"salequantity := {rqModel.SaleQuantity}, " : "")} " +
                        $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                        $"{(rqModel.AccessorySaleId != null ? $"accessorysaleid := {rqModel.AccessorySaleId}, " : "")} " +
                        $")";

                string input = qry;
                int lastCommaIndex = input.LastIndexOf(',');

                if (lastCommaIndex >= 0)
                {
                    result = input.Remove(lastCommaIndex, 1);
                }
                else
                {
                    result = qry;
                }

            }

            return result;
        }

        public static string SpInsertAccessorySale(InsAccessorySaleModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {insertAccessorySaleqry}({(rqModel.AccessorySaleid != null ? $"accessorysaleid := {rqModel.AccessorySaleid}, " : "")} " +
                      $"{(rqModel.Driverid != null ? $"driverid := {rqModel.Driverid}, " : "")} " +
                      $"{(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(rqModel.Shopid != null ? $"shopid := {rqModel.Shopid}, " : "")} " +
                      $"{(rqModel.Saledate != null ? $"saledate := '{rqModel.Saledate?.ToString("yyyy-MM-dd")}', " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Saledescription) ? $"saledescription := '{rqModel.Saledescription}', " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                     $")";

            string input = qry;
            int lastCommaIndex = input.LastIndexOf(',');

            if (lastCommaIndex >= 0)
            {
                result = input.Remove(lastCommaIndex, 1);
            }
            else
            {
                result = qry;
            }

            return result;
        }

        public static string SpInsertAccessorySaleItem(InsAccessorySaleItemModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {insertAccessorySaleItemqry}({(rqModel.AccessorySaleItemid != null ? $"accessorysaleitemid := {rqModel.AccessorySaleItemid}, " : "")} " +
                      $"{(rqModel.AccessoryId != null ? $"accessoryid := {rqModel.AccessoryId}, " : "")} " +
                      $"{(rqModel.SaleQuantity != null ? $"salequantity := {rqModel.SaleQuantity}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(rqModel.Accessorysaleid != null ? $"accessorysaleid := {rqModel.Accessorysaleid}, " : "")} " +
                     $")";

            string input = qry;
            int lastCommaIndex = input.LastIndexOf(',');

            if (lastCommaIndex >= 0)
            {
                result = input.Remove(lastCommaIndex, 1);
            }
            else
            {
                result = qry;
            }

            return result;
        }
       
        public static string SpDeleteAccessorySale(DeleteAccessorySaleModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {deleteAccessorySaleqry}({(rqModel.AccessorySaleid != null ? $"accessorysaleid := {rqModel.AccessorySaleid}, " : "")} " +
                     $")";

            string input = qry;
            int lastCommaIndex = input.LastIndexOf(',');

            if (lastCommaIndex >= 0)
            {
                result = input.Remove(lastCommaIndex, 1);
            }
            else
            {
                result = qry;
            }

            return result;
        }

        public static string SpAccessoryTotalSale(SalesTotalModel? rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {getAccessoryTotalSaleqry}({(rqModel?.Startdate != null ? $"startdate := '{rqModel.Startdate:yyyy-MM-dd}', " : "")} " +
                      $"{(rqModel?.Enddate != null ? $"enddate := '{rqModel.Enddate:yyyy-MM-dd}', " : "")} " +
                      $"{(rqModel?.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                     $")";

            string input = qry;
            int lastCommaIndex = input.LastIndexOf(',');

            if (lastCommaIndex >= 0)
            {
                result = input.Remove(lastCommaIndex, 1);
            }
            else
            {
                result = qry;
            }

            return result;
        }

        public static string SpDeleteAccessorySalesItem(DeleteAccessorySalesItemModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {deleteAccessorySalesItemqry}({(rqModel.AccessorySaleid != null ? $"accessorysaleid := {rqModel.AccessorySaleid}, " : "")} " +
                         $"{(rqModel?.AccessorySaleItemid != null ? $"accessorysaleitemid := {rqModel.AccessorySaleItemid}, " : "")} " +
                         $")";

            string input = qry;
            int lastCommaIndex = input.LastIndexOf(',');

            if (lastCommaIndex >= 0)
            {
                result = input.Remove(lastCommaIndex, 1);
            }
            else
            {
                result = qry;
            }

            return result;
        }

        #endregion sp for AccessorySale
    }
}
