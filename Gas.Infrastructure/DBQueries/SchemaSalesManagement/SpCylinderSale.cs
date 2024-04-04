using Gas.Model.SalesManagement;
using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaSalesManagement
{
    public static class SpCylinderSale
    {
        #region procedures
        private static readonly string dbSchema = "sales.";
        private static readonly string insertCylinderSaleqry = $"{dbSchema}ufn_insert_cylinder_sale";
        private static readonly string getCylinderSaleqry = $"{dbSchema}ufn_select_cylinder_sale";
        private static readonly string deleteCylinderSaleqry = $"{dbSchema}ufn_delete_cylinder_sale";


        #endregion procedures

        #region sp for CylinderSale
        public static string getCylinderSale = $"SELECT * FROM {getCylinderSaleqry}()";

        public static string SpGetCylinderSale(GetCylinderSaleModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getCylinderSale;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCylinderSaleqry}({(rqModel.CylinderSaleid != null ? $"cylindersaleid := {rqModel.CylinderSaleid}, " : "")} " +
                      $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                      $"{(rqModel.Cylindercategory != null ? $"cylindercategory := {rqModel.Cylindercategory}, " : "")} " +
                      $"{(rqModel.Driverid != null ? $"driverid := {rqModel.Driverid}, " : "")} " +
                      $"{(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(rqModel.Saleprice != null ? $"saleprice := {rqModel.Saleprice}, " : "")} " +
                      $"{(rqModel.Saledate != null ? $"saledate := {rqModel.Saledate}, " : "")} " +
                      $"{(rqModel.Salequantity != null ? $"salequantity := {rqModel.Salequantity}, " : "")} " +
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

        public static string SpInsertCylinderSale(InsCylinderSaleModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {insertCylinderSaleqry}({(rqModel.CylinderSaleid != null ? $"Cylindersaleid := {rqModel.CylinderSaleid}, " : "")} " +
                      $"{(rqModel.Cylinderid != null ? $"Cylinderid := {rqModel.Cylinderid}, " : "")} " +
                      $"{(rqModel.Cylindercategory != null ? $"cylindercategory := {rqModel.Cylindercategory}, " : "")} " +
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

        public static string SpDeleteCylinderSale(DeleteCylinderSaleModel? rqModel)
        {
            string result = "";
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

        #endregion sp for CylinderSale
    }
}
