using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpCountry
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getCountryqry = $"{dbSchema}ufn_select_country";
        private static readonly string insCountryqry = $"{dbSchema}ufn_insert_country";
        private static readonly string updateCountryqry = $"{dbSchema}ufn_update_country";

        #endregion procedures

        #region sp for Country
        public static string getCountry = $"SELECT * FROM {getCountryqry}()";
        public static string SpInsCountry(InsCountryModel rqModel)
        {
            string qry = $"SELECT * FROM {insCountryqry}(countryid := {rqModel.Countryid}, countryname := '{rqModel.Countryname}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateCountry(UpdateCountryModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCountryqry}(countryid := {rqModel.Countryid}, countryname := '{rqModel.Countryname}' " +
                     $")";

            return qry;
        }
        public static string SpGetCountry(GetCountryModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getCountry;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCountryqry}({(rqModel.Countryid != null ? $"countryid := {rqModel.Countryid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Countryname) ? $"countryname := '{rqModel.Countryname}', " : "")} " +
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

        public static string SpUpdateCountryStatus(RequestCountryStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCountryqry}(countryid := {rqModel.Countryid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Country
    }
}
