using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpWard
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getWardqry = $"{dbSchema}ufn_select_ward";
        private static readonly string insWardqry = $"{dbSchema}ufn_insert_ward";
        private static readonly string updateWardqry = $"{dbSchema}ufn_update_ward";

        #endregion procedures

        #region sp for Ward
        public static string getWard = $"SELECT * FROM {getWardqry}()";
        public static string SpInsWard(InsWardModel rqModel)
        {
            string qry = $"SELECT * FROM {insWardqry}(wardid := {rqModel.Wardid}, wardname := '{rqModel.Wardname}',warddistrict := {rqModel.Warddistrict}  " +
                       $")";
            return qry;
        }
        public static string SpUpdateWard(UpdateWardModel rqModel)
        {
            string qry = $"SELECT * FROM {updateWardqry}(wardid := {rqModel.Wardid}, wardname := '{rqModel.Wardname}',warddistrict := {rqModel.Warddistrict}  " +
                     $")";

            return qry;
        }
        public static string SpGetWard(GetWardModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getWard;
            }
            else
            {
              string  qry = $"SELECT * FROM {getWardqry}({(rqModel.Wardid != null ? $"wardid := {rqModel.Wardid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Wardname) ? $"wardname := '{rqModel.Wardname}', " : "")} " +
                      $"{(rqModel.Warddistrict != null ? $"warddistrict := {rqModel.Warddistrict}, " : "")} " +
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

        public static string SpUpdateWardStatus(RequestWardStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateWardqry}(wardid := {rqModel.Wardid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Ward
    }
}
