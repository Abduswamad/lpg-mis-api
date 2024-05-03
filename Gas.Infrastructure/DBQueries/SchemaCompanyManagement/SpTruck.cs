using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpTruck
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string gettruckqry = $"{dbSchema}ufn_select_truck";
        private static readonly string instruckqry = $"{dbSchema}ufn_insert_truck";
        private static readonly string updatetruckqry = $"{dbSchema}ufn_update_truck";
        private static readonly string getTruck = $"SELECT * FROM {gettruckqry}()";
        #endregion procedures

        #region sp for Truck

        public static string SpInsTruck(InsTruckModel rqModel)
        {
            string qry = $"SELECT * FROM {instruckqry}(truckid := {rqModel.Truckid}, platenumber := '{rqModel.Platenumber}', weigthintones := {rqModel.Weigthintones}, " +
                       $" trucktype := {rqModel.Trucktype}, truckdriver := {rqModel.Truckdriver}, superdealer := {rqModel.Superdealer}" +
                       $")";
            return qry;
        }
        public static string SpUpdateTruck(UpdateTruckModel rqModel)
        {
            string qry = $"SELECT * FROM {updatetruckqry}(truckid := {rqModel.Truckid}, platenumber := '{rqModel.Platenumber}', weigthintones := {rqModel.Weigthintones}, " +
                       $" trucktype := {rqModel.Trucktype}, truckdriver := {rqModel.Truckdriver}, superdealer := {rqModel.Superdealer}" +
                       $")";

            return qry;
        }
        public static string SpGetTruck(GetTruckModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getTruck;
            }
            else
            {
              string  qry = $"SELECT * FROM {gettruckqry}({(rqModel.Truckid != null ? $"truckid := {rqModel.Truckid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Platenumber) ? $"platenumber := '{rqModel.Platenumber}', " : "")} " +
                      $"{(rqModel.Weigthintones != null ? $"weigthintones := {rqModel.Weigthintones}, " : "")} " +
                      $"{(rqModel.Trucktype != null ? $"trucktype := {rqModel.Trucktype}, " : "")} " +
                      $"{(rqModel.Truckdriver != null ? $"truckdriver := {rqModel.Truckdriver}, " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
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

        public static string SpUpdateTruckStatus(RequestTruckStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updatetruckqry}(truckid := {rqModel.Truckid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Truck
    }
}
