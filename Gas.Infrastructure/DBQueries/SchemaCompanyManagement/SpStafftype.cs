using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpStafftype
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getstafftypeqry = $"{dbSchema}ufn_select_staff_type";
        private static readonly string insstafftypeqry = $"{dbSchema}ufn_insert_staff_type";
        private static readonly string updatestafftypeqry = $"{dbSchema}ufn_update_staff_type";

        #endregion procedures

        #region sp for Stafftype
        public static string getStafftype = $"SELECT * FROM {getstafftypeqry}()";
        public static string SpInsStafftype(InsStafftypeModel rqModel)
        {
            string qry = $"SELECT * FROM {insstafftypeqry}(stafftypeid := {rqModel.Stafftypeid}, stafftypename := '{rqModel.Stafftypename}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateStafftype(UpdateStafftypeModel rqModel)
        {
            string qry = $"SELECT * FROM {updatestafftypeqry}(stafftypeid := {rqModel.Stafftypeid}, stafftypename := '{rqModel.Stafftypename}' " +
                     $")";

            return qry;
        }
        public static string SpGetStafftype(GetStafftypeModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getStafftype;
            }
            else
            {
              string  qry = $"SELECT * FROM {getstafftypeqry}({(rqModel.Stafftypeid != null ? $"stafftypeid := {rqModel.Stafftypeid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Stafftypename) ? $"stafftypename := '{rqModel.Stafftypename}', " : "")} " +
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

        public static string SpUpdateStafftypeStatus(RequestStafftypeStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updatestafftypeqry}(stafftypeid := {rqModel.Stafftypeid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Stafftype
    }
}
