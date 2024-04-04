using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpCommonstreet
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getCommonstreetqry = $"{dbSchema}ufn_select_common_street";
        private static readonly string insCommonstreetqry = $"{dbSchema}ufn_insert_common_street";
        private static readonly string updateCommonstreetqry = $"{dbSchema}ufn_update_common_street";

        #endregion procedures

        #region sp for Commonstreet
        public static string getCommonstreet = $"SELECT * FROM {getCommonstreetqry}()";
        public static string SpInsCommonstreet(InsCommonstreetModel rqModel)
        {
            string qry = $"SELECT * FROM {insCommonstreetqry}(commonstreetid := {rqModel.Commonstreetid}, commonstreetname := '{rqModel.Commonstreetname}',commonstreetward := {rqModel.Commonstreetward}  " +
                       $")";
            return qry;
        }
        public static string SpUpdateCommonstreet(UpdateCommonstreetModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCommonstreetqry}(commonstreetid := {rqModel.Commonstreetid}, commonstreetname := '{rqModel.Commonstreetname}',commonstreetward := {rqModel.Commonstreetward}  " +
                     $")";

            return qry;
        }
        public static string SpGetCommonstreet(GetCommonstreetModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getCommonstreet;
            }
            else
            {
              string  qry = $"SELECT * FROM {getCommonstreetqry}({(rqModel.Commonstreetid != null ? $"commonstreetid := {rqModel.Commonstreetid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Commonstreetname) ? $"commonstreetname := '{rqModel.Commonstreetname}', " : "")} " +
                      $"{(rqModel.Commonstreetward != null ? $"commonstreetward := {rqModel.Commonstreetward}, " : "")} " +
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

        public static string SpUpdateCommonstreetStatus(RequestCommonstreetStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateCommonstreetqry}(commonstreetid := {rqModel.Commonstreetid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Commonstreet
    }
}
