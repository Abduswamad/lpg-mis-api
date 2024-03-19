using Gas.Model.PublicManagement;

namespace Gas.Infrastructure.DBQueries.SchemaPublicManagement
{
    public static class SpSuperdealer
    {
        #region procedures
        private static readonly string dbSchema = "super_management.";
        private static readonly string getSuperdealerqry = $"{dbSchema}ufn_select_super_dealer";
        private static readonly string insSuperdealerqry = $"{dbSchema}ufn_insert_super_dealer";
        private static readonly string updateSuperdealerqry = $"{dbSchema}ufn_update_super_dealer";

        #endregion procedures

        #region sp for Superdealer
        public static string getSuperdealer = $"SELECT * FROM {getSuperdealerqry}()";
        public static string SpInsSuperdealer(InsSuperdealerModel rqModel)
        {
            string qry = $"SELECT * FROM {insSuperdealerqry}(superdealerid := {rqModel.Superdealerid}, superdealername := '{rqModel.Superdealername}' " +
                       $")";
            return qry;
        }
        public static string SpUpdateSuperdealer(UpdateSuperdealerModel rqModel)
        {
            string qry = $"SELECT * FROM {updateSuperdealerqry}(superdealerid := {rqModel.Superdealerid}, superdealername := '{rqModel.Superdealername}' " +
                     $")";

            return qry;
        }
        public static string SpGetSuperdealer(GetSuperdealerModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getSuperdealer;
            }
            else
            {
              string  qry = $"SELECT * FROM {getSuperdealerqry}({(rqModel.Superdealerid != null ? $"superdealerid := {rqModel.Superdealerid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Superdealername) ? $"superdealername := '{rqModel.Superdealername}', " : "")} " +
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

        public static string SpUpdateSuperdealerStatus(RequestSuperdealerStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updateSuperdealerqry}(superdealerid := {rqModel.Superdealerid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Superdealer
    }
}
