using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpShop
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getshopqry = $"{dbSchema}ufn_select_shop";
        private static readonly string insshopqry = $"{dbSchema}ufn_insert_shop";
        private static readonly string updateshopqry = $"{dbSchema}ufn_update_shop";

        #endregion procedures

        #region sp for Shop
        public static string getShop = $"SELECT * FROM {getshopqry}()";
        public static string SpInsShop(InsShopModel rqModel)
        {
            string qry = $"SELECT * FROM {insshopqry}(shopid := {rqModel.Shopid}, shopname := '{rqModel.Shopname}', phonenumber := '{rqModel.Phonenumber}', " +
                       $" commonstreet := {rqModel.Commonstreet}, superdealer := {rqModel.Superdealer}" +
                       $")";
            return qry;
        }
        public static string SpUpdateShop(UpdateShopModel rqModel)
        {
            string qry = $"SELECT * FROM {updateshopqry}(shopid := {rqModel.Shopid}, shopname := '{rqModel.Shopname}', phonenumber := '{rqModel.Phonenumber}', " +
                       $" commonstreet := {rqModel.Commonstreet}, superdealer := {rqModel.Superdealer}" +
                       $")";

            return qry;
        }
        public static string SpGetShop(GetShopModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getShop;
            }
            else
            {
              string  qry = $"SELECT * FROM {getshopqry}({(rqModel.Shopid != null ? $"shopid := {rqModel.Shopid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Shopname) ? $"shopname := '{rqModel.Shopname}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Phonenumber) ? $"phonenumber := '{rqModel.Phonenumber}', " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                      $"{(rqModel.Commonstreet != null ? $"commonstreet := {rqModel.Commonstreet}, " : "")} " +
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

        public static string SpUpdateShopStatus(RequestShopStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateshopqry}(shopid := {rqModel.Shopid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Shop
    }
}
