using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpCylindercategory
    {
        #region procedures
        private static readonly string dbSchema = "sales.";
        private static readonly string getCylindercategoryqry = $"{dbSchema}ufn_select_cylinder_category";
        private static readonly string insCylindercategoryqry = $"{dbSchema}ufn_insert_cylinder_category";
        private static readonly string updateCylindercategoryqry = $"{dbSchema}ufn_update_cylinder_category";

        #endregion procedures

        #region sp for Cylindercategory
        public static string getCylindercategory = $"SELECT * FROM {getCylindercategoryqry}()";
        public static string SpInsCylindercategory(InsCylindercategoryModel rqModel)
        {
            string qry = $"SELECT * FROM {insCylindercategoryqry}(cylindercategoryid := {rqModel.Cylindercategoryid}, cylindercategoryname := '{rqModel.Cylindercategoryname}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateCylindercategory(UpdateCylindercategoryModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCylindercategoryqry}(cylindercategoryid := {rqModel.Cylindercategoryid}, cylindercategoryname := '{rqModel.Cylindercategoryname}' " +
                     $")";

            return qry;
        }
        public static string SpGetCylindercategory(GetCylindercategoryModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getCylindercategory;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCylindercategoryqry}({(rqModel.Cylindercategoryid != null ? $"cylindercategoryid := {rqModel.Cylindercategoryid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Cylindercategoryname) ? $"cylindercategoryname := '{rqModel.Cylindercategoryname}', " : "")} " +
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

        public static string SpUpdateCylindercategoryStatus(RequestCylindercategoryStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCylindercategoryqry}(cylindercategoryid := {rqModel.Cylindercategoryid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Cylindercategory
    }
}
