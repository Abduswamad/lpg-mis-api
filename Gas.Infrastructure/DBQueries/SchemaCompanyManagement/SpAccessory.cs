using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpAccessory
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getAccessoryqry = $"{dbSchema}ufn_select_accessory";
        private static readonly string insAccessoryqry = $"{dbSchema}ufn_insert_accessory";
        private static readonly string updateAccessoryqry = $"{dbSchema}ufn_update_accessory";

        #endregion procedures

        #region sp for Accessory
        public static string getAccessory = $"SELECT * FROM {getAccessoryqry}()";
        public static string SpInsAccessory(InsAccessoryModel rqModel)
        {
            string qry = $"SELECT * FROM {insAccessoryqry}(accessoryid := {rqModel.Accessoryid}, accessoryname := '{rqModel.Accessoryname}', accessorybrand := {rqModel.Accessorybrand}, " +
                       $" superdealer := {rqModel.Superdealer}" +
                       $")";
            return qry;
        }
        public static string SpUpdateAccessory(UpdateAccessoryModel rqModel)
        {
            string qry = $"SELECT * FROM {updateAccessoryqry}(accessoryid := {rqModel.Accessoryid}, accessoryname := '{rqModel.Accessoryname}', accessorybrand := {rqModel.Accessorybrand}, " +
                       $" superdealer := {rqModel.Superdealer}" +
                       $")";

            return qry;
        }
        public static string SpGetAccessory(GetAccessoryModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getAccessory;
            }
            else
            {
              string  qry = $"SELECT * FROM {getAccessoryqry}({(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Accessoryname) ? $"accessoryname := '{rqModel.Accessoryname}', " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                      $"{(rqModel.Accessorybrand != null ? $"accessorybrand := {rqModel.Accessorybrand}, " : "")} " +
                      $"{(rqModel.IsActive != null ? $"isactive := {rqModel.IsActive}, " : "")} " +
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

        public static string SpUpdateAccessoryStatus(RequestAccessoryStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateAccessoryqry}(accessoryid := {rqModel.Accessoryid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Accessory
    }
}
