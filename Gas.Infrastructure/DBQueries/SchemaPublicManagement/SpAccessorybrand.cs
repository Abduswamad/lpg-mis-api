using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpAccessorybrand
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getAccessorybrandqry = $"{dbSchema}ufn_select_accessory_brand";
        private static readonly string insAccessorybrandqry = $"{dbSchema}ufn_insert_accessory_brand";
        private static readonly string updateAccessorybrandqry = $"{dbSchema}ufn_update_accessory_brand";

        #endregion procedures

        #region sp for Accessorybrand
        public static string getAccessorybrand = $"SELECT * FROM {getAccessorybrandqry}()";
        public static string SpInsAccessorybrand(InsAccessorybrandModel rqModel)
        {
            string qry = $"SELECT * FROM {insAccessorybrandqry}(accessorybrandid := {rqModel.Accessorybrandid}, accessorybrandname := '{rqModel.Accessorybrandname}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateAccessorybrand(UpdateAccessorybrandModel rqModel)
        {
            string qry = $"SELECT * FROM {updateAccessorybrandqry}(accessorybrandid := {rqModel.Accessorybrandid}, accessorybrandname := '{rqModel.Accessorybrandname}' " +
                     $")";

            return qry;
        }
        public static string SpGetAccessorybrand(GetAccessorybrandModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getAccessorybrand;
            }
            else
            {
              string  qry = $"SELECT * FROM {getAccessorybrandqry}({(rqModel.Accessorybrandid != null ? $"accessorybrandid := {rqModel.Accessorybrandid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Accessorybrandname) ? $"accessorybrandname := '{rqModel.Accessorybrandname}', " : "")} " +
                      $"{(rqModel.IsActive != null ? $"isactive := {rqModel.IsActive} " : "")} " +
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

        public static string SpUpdateAccessorybrandStatus(RequestAccessorybrandStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateAccessorybrandqry}(accessorybrandid := {rqModel.Accessorybrandid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Accessorybrand
    }
}
