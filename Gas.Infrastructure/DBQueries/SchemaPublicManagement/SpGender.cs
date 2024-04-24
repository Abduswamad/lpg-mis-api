using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpGender
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getGenderqry = $"{dbSchema}ufn_select_gender";
        private static readonly string insGenderqry = $"{dbSchema}ufn_insert_gender";
        private static readonly string updateGenderqry = $"{dbSchema}ufn_update_gender";

        #endregion procedures

        #region sp for Gender
        public static string getGender = $"SELECT * FROM {getGenderqry}()";
        public static string SpInsGender(InsGenderModel rqModel)
        {
            string qry = $"SELECT * FROM {insGenderqry}(genderid := {rqModel.Genderid}, gendername := '{rqModel.Gendername}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateGender(UpdateGenderModel rqModel)
        {
            string qry = $"SELECT * FROM {updateGenderqry}(genderid := {rqModel.Genderid}, gendername := '{rqModel.Gendername}' " +
                     $")";

            return qry;
        }
        public static string SpGetGender(GetGenderModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getGender;
            }
            else
            {
              string  qry = $"SELECT * FROM {getGenderqry}({(rqModel.Genderid != null ? $"genderid := {rqModel.Genderid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Gendername) ? $"gendername := '{rqModel.Gendername}', " : "")} " +
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

        public static string SpUpdateGenderStatus(RequestGenderStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateGenderqry}(genderid := {rqModel.Genderid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Gender
    }
}
