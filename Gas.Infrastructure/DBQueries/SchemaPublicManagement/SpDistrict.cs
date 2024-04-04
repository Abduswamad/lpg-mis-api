using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpDistrict
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getDistrictqry = $"{dbSchema}ufn_select_district";
        private static readonly string insDistrictqry = $"{dbSchema}ufn_insert_district";
        private static readonly string updateDistrictqry = $"{dbSchema}ufn_update_district";

        #endregion procedures

        #region sp for District
        public static string getDistrict = $"SELECT * FROM {getDistrictqry}()";
        public static string SpInsDistrict(InsDistrictModel rqModel)
        {
            string qry = $"SELECT * FROM {insDistrictqry}(districtid := {rqModel.Districtid}, districtname := '{rqModel.Districtname}',districtregion := {rqModel.Districtregion}  " +
                       $")";
            return qry;
        }
        public static string SpUpdateDistrict(UpdateDistrictModel rqModel)
        {
            string qry = $"SELECT * FROM {updateDistrictqry}(districtid := {rqModel.Districtid}, districtname := '{rqModel.Districtname}',districtregion := {rqModel.Districtregion}  " +
                     $")";

            return qry;
        }
        public static string SpGetDistrict(GetDistrictModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getDistrict;
            }
            else
            {
              string  qry = $"SELECT * FROM {getDistrictqry}({(rqModel.Districtid != null ? $"districtid := {rqModel.Districtid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Districtname) ? $"districtname := '{rqModel.Districtname}', " : "")} " +
                      $"{(rqModel.Districtregion != null ? $"districtregion := {rqModel.Districtregion}, " : "")} " +
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

        public static string SpUpdateDistrictStatus(RequestDistrictStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateDistrictqry}(districtid := {rqModel.Districtid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for District
    }
}
