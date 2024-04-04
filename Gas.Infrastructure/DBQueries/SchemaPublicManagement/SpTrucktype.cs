using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpTrucktype
    {
        #region procedures
        private static readonly string dbSchema = "public.";
        private static readonly string getTrucktypeqry = $"{dbSchema}ufn_select_truck_type";
        private static readonly string insTrucktypeqry = $"{dbSchema}ufn_insert_truck_type";
        private static readonly string updateTrucktypeqry = $"{dbSchema}ufn_update_truck_type";

        #endregion procedures

        #region sp for Trucktype
        public static string getTrucktype = $"SELECT * FROM {getTrucktypeqry}()";
        public static string SpInsTrucktype(InsTrucktypeModel rqModel)
        {
            string qry = $"SELECT * FROM {insTrucktypeqry}(trucktypeid := {rqModel.Trucktypeid}, trucktypename := '{rqModel.Trucktypename}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateTrucktype(UpdateTrucktypeModel rqModel)
        {
            string qry = $"SELECT * FROM {updateTrucktypeqry}(trucktypeid := {rqModel.Trucktypeid}, trucktypename := '{rqModel.Trucktypename}' " +
                     $")";

            return qry;
        }
        public static string SpGetTrucktype(GetTrucktypeModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getTrucktype;
            }
            else
            {
              string  qry = $"SELECT * FROM {getTrucktypeqry}({(rqModel.Trucktypeid != null ? $"trucktypeid := {rqModel.Trucktypeid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Trucktypename) ? $"trucktypename := '{rqModel.Trucktypename}', " : "")} " +
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

        public static string SpUpdateTrucktypeStatus(RequestTrucktypeStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateTrucktypeqry}(trucktypeid := {rqModel.Trucktypeid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Trucktype
    }
}
