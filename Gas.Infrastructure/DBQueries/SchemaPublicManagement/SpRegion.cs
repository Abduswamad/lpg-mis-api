using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpRegion
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getRegionqry = $"{dbSchema}ufn_select_region";
        private static readonly string insRegionqry = $"{dbSchema}ufn_insert_region";
        private static readonly string updateRegionqry = $"{dbSchema}ufn_update_region";

        #endregion procedures

        #region sp for Region
        public static string getRegion = $"SELECT * FROM {getRegionqry}()";
        public static string SpInsRegion(InsRegionModel rqModel)
        {
            string qry = $"SELECT * FROM {insRegionqry}(regionid := {rqModel.Regionid}, regionname := '{rqModel.Regionname}',regioncountry := {rqModel.Regioncountry}  " +
                       $")";
            return qry;
        }
        public static string SpUpdateRegion(UpdateRegionModel rqModel)
        {
            string qry = $"SELECT * FROM {updateRegionqry}(regionid := {rqModel.Regionid}, regionname := '{rqModel.Regionname}',regioncountry := {rqModel.Regioncountry}  " +
                     $")";

            return qry;
        }
        public static string SpGetRegion(GetRegionModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getRegion;
            }
            else
            {
              string  qry = $"SELECT * FROM {getRegionqry}({(rqModel.Regionid != null ? $"regionid := {rqModel.Regionid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Regionname) ? $"regionname := '{rqModel.Regionname}', " : "")} " +
                      $"{(rqModel.Regioncountry != null ? $"regioncountry := {rqModel.Regioncountry}, " : "")} " +
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

        public static string SpUpdateRegionStatus(RequestRegionStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateRegionqry}(regionid := {rqModel.Regionid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Region
    }
}
