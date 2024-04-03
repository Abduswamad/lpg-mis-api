using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpStaff
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getstaffqry = $"{dbSchema}ufn_select_staff";
        private static readonly string insstaffqry = $"{dbSchema}ufn_insert_staff";
        private static readonly string updatestaffqry = $"{dbSchema}ufn_update_staff";

        #endregion procedures

        #region sp for User
        public static string getUser = $"SELECT * FROM {getstaffqry}()";
        public static string SpInsStaff(InsStaffModel rqModel)
        {
            string qry = $"SELECT * FROM {insstaffqry}(staffid := {rqModel.Staffid}, firstname := '{rqModel.Firstname}', staffidnumber := '{rqModel.Staffidnumber}', " +
                        $"middlename := '{rqModel.Middlename}', lastname := '{rqModel.Lastname}', staffemail := '{rqModel.Staffemail}', staffusername := '{rqModel.Staffusername}' , " +
                        $"phonenumber := '{rqModel.Phonenumber}', staffpassword :='{rqModel.Staffpassword}', staffgender := {rqModel.Staffgender}, stafftype := {rqModel.Stafftype}, " +
                        $"superdealer := {rqModel.Superdealer},{(rqModel.Commonstreet != null ? $"commonstreet := {rqModel.Commonstreet} " : "")})";
            return qry;
        }
        public static string SpUpdateStaff(UpdateStaffModel rqModel)
        {
            string qry = $"SELECT * FROM {updatestaffqry}(staffid := {rqModel.Staffid}, firstname := '{rqModel.Firstname}', staffidnumber := '{rqModel.Staffidnumber}', " +
                       $"middlename := '{rqModel.Middlename}', lastname := '{rqModel.Lastname}', staffemail := '{rqModel.Staffemail}', staffusername := '{rqModel.Staffusername}' , " +
                       $"phonenumber := '{rqModel.Phonenumber}', staffgender := {rqModel.Staffgender}, stafftype := {rqModel.Stafftype}, " +
                       $"superdealer := {rqModel.Superdealer},{(rqModel.Commonstreet != null ? $"commonstreet := {rqModel.Commonstreet} " : "")})";

            return qry;
        }
        public static string SpGetStaff(GetStaffModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getUser;
            }
            else
            {
              string  qry = $"SELECT * FROM {getstaffqry}({(rqModel.Staffid != null ? $"staffid := {rqModel.Staffid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Firstname) ? $"firstname := '{rqModel.Firstname}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Staffidnumber) ? $"staffidnumber := '{rqModel.Staffidnumber}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Middlename) ? $"middlename := '{rqModel.Middlename}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Lastname) ? $"lastname := '{rqModel.Lastname}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Staffemail) ? $"staffemail := '{rqModel.Staffemail}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Staffusername) ? $"staffusername := '{rqModel.Staffusername}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Phonenumber) ? $"phonenumber := '{rqModel.Phonenumber}', " : "")} " +
                      $"{(rqModel.Staffgender != null ? $"staffgender := {rqModel.Staffgender}, " : "")} " +
                      $"{(rqModel.Stafftype != null ? $"stafftype := {rqModel.Stafftype}, " : "")} " +
                      $"{(rqModel.Commonstreet != null ? $"commonstreet := {rqModel.Commonstreet}, " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                      $"{(rqModel.IsActive != null ? $"isactive := {rqModel.IsActive}, " : "")} " +
                      $"{(rqModel.IsFirstTime != null ? $"isfirsttime := {rqModel.IsFirstTime}, " : "")} " +
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

        public static string SpGetStaffLogin(RequestStaffLoginEntity rqModel)
        {
            string qry = $"SELECT * FROM {getstaffqry}(staffusername := '{rqModel.Staffusername}' , staffpassword := '{rqModel.Password}')";
            return qry;
        }

        public static string SpUpdateStaffStatus(RequestStaffStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updatestaffqry}(staffid := {rqModel.Staffid},isactive := {rqModel.Isactive})";
            return qry;
        }

        public static string SpChangePasswordOnFirstLogin(RequestStaffpassChangeOnLoginModel rqModel)
        {
            string qry = $"SELECT * FROM {updatestaffqry}(staffusername := '{rqModel.Staffusername}',staffpassword := '{rqModel.Staffpassword}', isfirsttime := false)";
            return qry;
        }

        public static string SpChangePassword(RequestStaffpassChangeModel rqModel)
        {
            string qry = $"SELECT * FROM {updatestaffqry}(staffid := {rqModel.Staffid},staffpassword :='{rqModel.Staffpassword}', isfirsttime := false)";
            return qry;
        }

        public static string SpResetPassword(RequestStaffResetpassChangeModel rqModel)
        {
            string qry = $"SELECT * FROM {updatestaffqry}(staffid := {rqModel.Staffid},staffpassword :='{rqModel.Staffpassword}' , isfirsttime := True)";
            return qry;
        }

        #endregion sp for User
    }
}
