using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpStaffrole
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getStaffroleqry = $"{dbSchema}ufn_select_staff_role";
        private static readonly string insStaffroleqry = $"{dbSchema}ufn_insert_staff_role";
        private static readonly string updateStaffroleqry = $"{dbSchema}ufn_update_staff_role";

        #endregion procedures

        #region sp for Staffrole
        public static string getStaffrole = $"SELECT * FROM {getStaffroleqry}()";
        public static string SpInsStaffrole(InsStaffroleModel rqModel)
        {
            string qry = $"SELECT * FROM {insStaffroleqry}(roleid := {rqModel.Roleid}, staffid := {rqModel.Staffid} " +
                       $")";
            return qry;
        }
        public static string SpUpdateStaffrole(UpdateStaffroleModel rqModel)
        {
            string qry = $"SELECT * FROM {updateStaffroleqry}(roleid := {rqModel.Roleid}, staffid := {rqModel.Staffid} " +
                     $")";

            return qry;
        }
        public static string SpGetStaffrole(GetStaffroleModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getStaffrole;
            }
            else
            {
              string  qry = $"SELECT * FROM {getStaffroleqry}({(rqModel.Roleid != null ? $"roleid := {rqModel.Roleid}, " : "")} " +
                      $"{(rqModel.Staffid != null ? $"staffid := {rqModel.Staffid}, " : "")} " +
                      $"{(rqModel.Isactive != null ? $"isactive := {rqModel.Isactive}, " : "")} " +
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

        public static string SpUpdateStaffroleStatus(RequestStaffroleStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateStaffroleqry}(roleid := {rqModel.Roleid}, staffid := {rqModel.Staffid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Staffrole
    }
}
