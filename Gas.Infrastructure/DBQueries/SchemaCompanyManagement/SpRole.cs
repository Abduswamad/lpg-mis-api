using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpRole
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getroleqry = $"{dbSchema}ufn_select_role";
        private static readonly string insroleqry = $"{dbSchema}ufn_insert_role";
        private static readonly string updateroleqry = $"{dbSchema}ufn_update_role";

        #endregion procedures

        #region sp for Role
        public static string getRole = $"SELECT * FROM {getroleqry}()";
        public static string SpInsRole(InsRoleModel rqModel)
        {
            string qry = $"SELECT * FROM {insroleqry}(roleid := {rqModel.Roleid}, rolename := '{rqModel.Rolename}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateRole(UpdateRoleModel rqModel)
        {
            string qry = $"SELECT * FROM {updateroleqry}(roleid := {rqModel.Roleid}, rolename := '{rqModel.Rolename}' " +
                     $")";

            return qry;
        }
        public static string SpGetRole(GetRoleModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getRole;
            }
            else
            {
              string  qry = $"SELECT * FROM {getroleqry}({(rqModel.Roleid != null ? $"roleid := {rqModel.Roleid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Rolename) ? $"rolename := '{rqModel.Rolename}', " : "")} " +
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

        public static string SpUpdateRoleStatus(RequestRoleStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateroleqry}(roleid := {rqModel.Roleid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Role
    }
}
