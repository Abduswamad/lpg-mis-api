using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaStoreManagement
{
    public static class SpCylinderstatus
    {
        #region procedures
        private static readonly string dbSchema = "store.";
        private static readonly string getCylinderstatusqry = $"{dbSchema}ufn_select_cylinder_status";
        private static readonly string getCylinderstatus = $"SELECT * FROM {getCylinderstatusqry}()";

        #endregion procedures

        #region sp for Cylinderstatus
       // public static string getCylinderstatus = getCylinderstatus;

        public static string SpGetCylinderstatus(GetCylinderstatusModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getCylinderstatus;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCylinderstatusqry}({(rqModel.Cylinderstatusid != null ? $"cylinderstatusid := {rqModel.Cylinderstatusid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Cylinderstatusname) ? $"cylinderstatusname := '{rqModel.Cylinderstatusname}', " : "")} " +
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

        #endregion sp for Cylinderstatus
    }
}
