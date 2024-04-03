using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpCylindercompany
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getCylindercompanyqry = $"{dbSchema}ufn_select_cylinder_company";
        private static readonly string insCylindercompanyqry = $"{dbSchema}ufn_insert_cylinder_company";
        private static readonly string updateCylindercompanyqry = $"{dbSchema}ufn_update_cylinder_company";

        #endregion procedures

        #region sp for Cylindercompany
        public static string getCylindercompany = $"SELECT * FROM {getCylindercompanyqry}()";
        public static string SpInsCylindercompany(InsCylindercompanyModel rqModel)
        {
            string qry = $"SELECT * FROM {insCylindercompanyqry}(cylindercompanyid := {rqModel.Cylindercompanyid}, cylindercompanyname := '{rqModel.Cylindercompanyname}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateCylindercompany(UpdateCylindercompanyModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCylindercompanyqry}(cylindercompanyid := {rqModel.Cylindercompanyid}, cylindercompanyname := '{rqModel.Cylindercompanyname}' " +
                     $")";

            return qry;
        }
        public static string SpGetCylindercompany(GetCylindercompanyModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getCylindercompany;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCylindercompanyqry}({(rqModel.Cylindercompanyid != null ? $"cylindercompanyid := {rqModel.Cylindercompanyid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Cylindercompanyname) ? $"cylindercompanyname := '{rqModel.Cylindercompanyname}', " : "")} " +
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

        public static string SpUpdateCylindercompanyStatus(RequestCylindercompanyStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCylindercompanyqry}(cylindercompanyid := {rqModel.Cylindercompanyid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Cylindercompany
    }
}
