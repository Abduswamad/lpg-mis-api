using Gas.Infrastructure.DBQueries.SchemaPublicManagement;
using Gas.Model.SalesManagement;
using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaSalesManagement
{
    public static class SpCylinderSale
    {
        #region procedures
        private static readonly string dbSchema = "sales.";
        private static readonly string insertCylinderSaleqry = $"{dbSchema}ufn_insert_cylinder_sale";
        private static readonly string insertCylinderSalesItemqry = $"{dbSchema}ufn_insert_cylinder_sale_item";
        private static readonly string getCylinderSaleqry = $"{dbSchema}ufn_select_cylinder_sale";
        private static readonly string getCylinderSalesItemqry = $"{dbSchema}ufn_select_cylinder_sale_item";        
        private static readonly string deleteCylinderSaleqry = $"{dbSchema}ufn_delete_cylinder_sale";
        private static readonly string deleteCylinderSalesItemqry = $"{dbSchema}ufn_delete_cylinder_sale_item";
        private static readonly string getCylinderTotalSaleqry = $"{dbSchema}ufn_select_cylinder_sale_total";
        private static readonly string getCylinderSale = $"SELECT * FROM {getCylinderSaleqry}()";
        private static readonly string getCylinderSalesItem = $"SELECT * FROM {getCylinderSalesItemqry}()";


        #endregion procedures

        #region sp for CylinderSale
        // public static string getCylinderSale = getCylinderSale;

        public static string SpGetCylinderSale(GetCylinderSaleModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getCylinderSale;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCylinderSaleqry}({(rqModel.CylinderSaleid != null ? $"cylindersaleid := {rqModel.CylinderSaleid}, " : "")} " +
                     $"{(rqModel.Driverid != null ? $"driverid := {rqModel.Driverid}, " : "")} " +
                      $"{(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(rqModel.Saledate != null ? $"saledate := '{rqModel.Saledate?.ToString("yyyy-MM-dd")}', " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
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

        public static string SpGetCylinderSalesItem(GetCylinderSalesItemModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getCylinderSalesItem;
            }
            else
            {
                string qry = $"SELECT * FROM {getCylinderSalesItemqry}({(rqModel.CylinderSaleItemid != null ? $"cylindersaleitemid := {rqModel.CylinderSaleItemid}, " : "")} " +
                       $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                        $"{(rqModel.Cylindercategory != null ? $"cylindercategory := {rqModel.Cylindercategory}, " : "")} " +
                        $"{(rqModel.Salequantity != null ? $"salequantity := {rqModel.Salequantity}, " : "")} " +
                        $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                        $"{(rqModel.Cylindersaleid != null ? $"cylindersaleid := {rqModel.Cylindersaleid}, " : "")} " +
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

        public static string SpInsertCylinderSale(InsCylinderSaleModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {insertCylinderSaleqry}({(rqModel.CylinderSaleid != null ? $"cylindersaleid := {rqModel.CylinderSaleid}, " : "")} " +
                      $"{(rqModel.Driverid != null ? $"driverid := {rqModel.Driverid}, " : "")} " +
                      $"{(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(rqModel.Shopid != null ? $"shopid := {rqModel.Shopid}, " : "")} " +
                      $"{(rqModel.Saledate != null ? $"saledate := '{rqModel.Saledate?.ToString("yyyy-MM-dd")}', " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Saledescription) ? $"saledescription := '{rqModel.Saledescription}', " : $"saledescription := '',")} " +
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

        public static string SpInsertCylinderSalesItem(InsCylinderSalesItemModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {insertCylinderSalesItemqry}({(rqModel.Cylindersaleitemid != null ? $"cylindersaleitemid := {rqModel.Cylindersaleitemid}, " : "")} " +
                      $"{(rqModel.CylinderId != null ? $"cylinderid := {rqModel.CylinderId}, " : "")} " +
                      $"{(rqModel.CylinderCategory != null ? $"cylindercategory := {rqModel.CylinderCategory}, " : "")} " +
                      $"{(rqModel.SaleQuantity != null ? $"salequantity := {rqModel.SaleQuantity}, " : "")} " +
                      $"{(rqModel.CylinderSaleId != null ? $"cylindersaleid := {rqModel.CylinderSaleId}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
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

        public static string SpDeleteCylinderSale(DeleteCylinderSaleModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {deleteCylinderSaleqry}({(rqModel.CylinderSaleid != null ? $"cylindersaleid := {rqModel.CylinderSaleid}, " : "")} " +
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

        public static string SpDeleteCylinderSalesItem(DeleteCylinderSalesItemModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {deleteCylinderSalesItemqry}({(rqModel.CylinderSaleid != null ? $"cylindersaleid := {rqModel.CylinderSaleid}, " : "")} " +
                         $"{(rqModel.CylinderSaleItemid != null ? $"cylindersaleitemid := {rqModel.CylinderSaleItemid}, " : "")} " +
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

        public static string SpCylinderTotalSale(SalesTotalModel? rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {getCylinderTotalSaleqry}({(rqModel?.Startdate != null ? $"startdate := '{rqModel.Startdate:yyyy-MM-dd}', " : "")} " +
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

        #endregion sp for CylinderSale
    }
}
