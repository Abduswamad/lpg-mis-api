using Gas.Model.SalesManagement;
using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaSalesManagement
{
    public static class SpAccessorySale
    {
        #region procedures
        private static readonly string dbSchema = "sales.";
        private static readonly string insertAccessorySaleqry = $"{dbSchema}ufn_insert_accessory_sale";
        private static readonly string getAccessorySaleqry = $"{dbSchema}ufn_select_accessory_sale";
        private static readonly string deleteAccessorySaleqry = $"{dbSchema}ufn_delete_accessory_sale";


        #endregion procedures

        #region sp for AccessorySale
        public static string getAccessorySale = $"SELECT * FROM {getAccessorySaleqry}()";

        public static string SpGetAccessorySale(GetAccessorySaleModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getAccessorySale;
            }
            else
            {
              string  qry = $"SELECT * FROM {getAccessorySaleqry}({(rqModel.AccessorySaleid != null ? $"accessorysaleid := {rqModel.AccessorySaleid}, " : "")} " +
                      $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                      $"{(rqModel.Driverid != null ? $"driverid := {rqModel.Driverid}, " : "")} " +
                      $"{(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(rqModel.Saledate != null ? $"saledate := {rqModel.Saledate}, " : "")} " +
                      $"{(rqModel.Salequantity != null ? $"salequantity := {rqModel.Salequantity}, " : "")} " +
                      $"{(rqModel.Shopid != null ? $"shopid := {rqModel.Shopid} " : "")} " +
                      $")";

                string input = qry;
                int lastCommaIndex = input.LastIndexOf(',');

                if (lastCommaIndex != -1 && qry.EndsWith(", )") && qry.EndsWith(",)") && qry.EndsWith(",  )"))
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

        public static string SpInsertAccessorySale(InsAccessorySaleModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {insertAccessorySaleqry}({(rqModel.AccessorySaleid != null ? $"accessorysaleid := {rqModel.AccessorySaleid}, " : "")} " +
                      $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                      $"{(rqModel.Driverid != null ? $"driverid := {rqModel.Driverid}, " : "")} " +
                      $"{(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(rqModel.Saledate != null ? $"saledate := {rqModel.Saledate}, " : "")} " +
                      $"{(rqModel.Salequantity != null ? $"salequantity := {rqModel.Salequantity}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Saledescription) ? $"saledescription := '{rqModel.Saledescription}', " : "")} " +
                      $"{(rqModel.Shopid != null ? $"shopid := {rqModel.Shopid}, " : "")} " +
                     $")";

            string input = qry;
            int lastCommaIndex = input.LastIndexOf(',');

            if (lastCommaIndex != -1 && qry.EndsWith(", )") && qry.EndsWith(",)") && qry.EndsWith(",  )"))
            {
                result = input.Remove(lastCommaIndex, 1);
            }
            else
            {
                result = qry;
            }

            return result;
        }

        public static string SpDeleteAccessorySale(DeleteAccessorySaleModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {deleteAccessorySaleqry}({(rqModel.AccessorySaleid != null ? $"accessorysaleid := {rqModel.AccessorySaleid}, " : "")} " +
                     $")";

            string input = qry;
            int lastCommaIndex = input.LastIndexOf(',');

            if (lastCommaIndex != -1 && qry.EndsWith(", )") && qry.EndsWith(",)") && qry.EndsWith(",  )"))
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
