using Gas.Model.SalesManagement;
using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaSalesManagement
{
    public static class SpAccessoryIndicativePrice
    {
        #region procedures
        private static readonly string dbSchema = "sales.";
        private static readonly string insertAccessoryIndicativePriceqry = $"{dbSchema}ufn_insert_accessory_indicative_price";
        private static readonly string getAccessoryIndicativePriceqry = $"{dbSchema}ufn_select_accessory_indicative_price";
        private static readonly string UpdateAccessoryIndicativePriceqry = $"{dbSchema}ufn_update_accessory_indicative_price";


        #endregion procedures

        #region sp for AccessoryIndicativePrice
        public static string getAccessoryIndicativePrice = $"SELECT * FROM {getAccessoryIndicativePriceqry}()";

        public static string SpGetAccessoryIndicativePrice(GetAccessoryIndicativePriceModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getAccessoryIndicativePrice;
            }
            else
            {
              string  qry = $"SELECT * FROM {getAccessoryIndicativePriceqry}({(rqModel.Accessoryindicativepriceid != null ? $"accessoryindicativepriceid := {rqModel.Accessoryindicativepriceid}, " : "")} " +
                      $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                      $"{(rqModel.Sellingprice != null ? $"sellingprice := {rqModel.Sellingprice}, " : "")} " +
                      $"{(rqModel.Buyingprice != null ? $"buyingprice := {rqModel.Buyingprice}, " : "")} " +
                      $"{(rqModel.IsActive != null ? $"isactive := {rqModel.IsActive}, " : "")} " +
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

        public static string SpInsertAccessoryIndicativePrice(InsAccessoryIndicativePriceModel rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {insertAccessoryIndicativePriceqry}({(rqModel.Accessoryindicativepriceid != null ? $"accessoryindicativepriceid := {rqModel.Accessoryindicativepriceid}, " : "")} " +
                     $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                     $"{(rqModel.Sellingprice != null ? $"sellingprice := {rqModel.Sellingprice}, " : "")} " +
                     $"{(rqModel.Buyingprice != null ? $"buyingprice := {rqModel.Buyingprice}, " : "")} " +
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

        public static string SpUpdateAccessoryIndicativePrice(UpdateAccessoryIndicativePriceModel rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {UpdateAccessoryIndicativePriceqry}({(rqModel.Accessoryindicativepriceid != null ? $"accessoryindicativepriceid := {rqModel.Accessoryindicativepriceid}, " : "")} " +
                     $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                     $"{(rqModel.Sellingprice != null ? $"sellingprice := {rqModel.Sellingprice}, " : "")} " +
                     $"{(rqModel.Buyingprice != null ? $"buyingprice := {rqModel.Buyingprice}, " : "")} " +
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

        public static string SpUpdateAccessoryIndicativePriceStatus(UpdateAccessoryIndicativePriceStatusModel rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {UpdateAccessoryIndicativePriceqry}({(rqModel.Accessoryindicativepriceid != null ? $"accessoryindicativepriceid := {rqModel.Accessoryindicativepriceid}, " : "")} " +
                     $"{(rqModel.IsActive != null ? $"isactive := {rqModel.IsActive}, " : "")} " +
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

        
        #endregion sp for AccessoryIndicativePrice
    }
}
