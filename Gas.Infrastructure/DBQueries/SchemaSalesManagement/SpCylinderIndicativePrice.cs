using Gas.Model.SalesManagement;
using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaSalesManagement
{
    public static class SpCylinderIndicativePrice
    {
        #region procedures
        private static readonly string dbSchema = "sales.";
        private static readonly string insertCylinderIndicativePriceqry = $"{dbSchema}ufn_insert_cylinder_indicative_price";
        private static readonly string getCylinderIndicativePriceqry = $"{dbSchema}ufn_select_cylinder_indicative_price";
        private static readonly string UpdateCylinderIndicativePriceqry = $"{dbSchema}ufn_update_cylinder_indicative_price";


        #endregion procedures

        #region sp for CylinderIndicativePrice
        public static string getCylinderIndicativePrice = $"SELECT * FROM {getCylinderIndicativePriceqry}()";

        public static string SpGetCylinderIndicativePrice(GetCylinderIndicativePriceModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getCylinderIndicativePrice;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCylinderIndicativePriceqry}({(rqModel.Cylinderindicativepriceid != null ? $"cylinderindicativepriceid := {rqModel.Cylinderindicativepriceid}, " : "")} " +
                      $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                      $"{(rqModel.Cylindercategory != null ? $"cylindercategory := {rqModel.Cylindercategory}, " : "")} " +
                      $"{(rqModel.Sellingprice != null ? $"sellingprice := {rqModel.Sellingprice}, " : "")} " +
                      $"{(rqModel.Buyingprice != null ? $"buyingprice := {rqModel.Buyingprice}, " : "")} " +
                      $"{(rqModel.IsActive != null ? $"isactive := {rqModel.IsActive} " : "")} " +
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

        public static string SpInsertCylinderIndicativePrice(InsCylinderIndicativePriceModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {insertCylinderIndicativePriceqry}({(rqModel.Cylinderindicativepriceid != null ? $"cylinderindicativepriceid := {rqModel.Cylinderindicativepriceid}, " : "")} " +
                     $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                     $"{(rqModel.Cylindercategory != null ? $"cylindercategory := {rqModel.Cylindercategory}, " : "")} " +
                     $"{(rqModel.Sellingprice != null ? $"sellingprice := {rqModel.Sellingprice}, " : "")} " +
                     $"{(rqModel.Buyingprice != null ? $"buyingprice := {rqModel.Buyingprice} " : "")} " +
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

        public static string SpUpdateCylinderIndicativePrice(UpdateCylinderIndicativePriceModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {UpdateCylinderIndicativePriceqry}({(rqModel.Cylinderindicativepriceid != null ? $"cylinderindicativepriceid := {rqModel.Cylinderindicativepriceid}, " : "")} " +
                     $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                     $"{(rqModel.Cylindercategory != null ? $"cylindercategory := {rqModel.Cylindercategory}, " : "")} " +
                     $"{(rqModel.Sellingprice != null ? $"sellingprice := {rqModel.Sellingprice}, " : "")} " +
                     $"{(rqModel.Buyingprice != null ? $"buyingprice := {rqModel.Buyingprice} " : "")} " +
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

        public static string SpUpdateCylinderIndicativePriceStatus(UpdateCylinderIndicativePriceStatusModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {UpdateCylinderIndicativePriceqry}({(rqModel.Cylinderindicativepriceid != null ? $"Cylinderindicativepriceid := {rqModel.Cylinderindicativepriceid}, " : "")} " +
                     $"{(rqModel.IsActive != null ? $"isactive := {rqModel.IsActive} " : "")} " +
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

        
        #endregion sp for CylinderIndicativePrice
    }
}
