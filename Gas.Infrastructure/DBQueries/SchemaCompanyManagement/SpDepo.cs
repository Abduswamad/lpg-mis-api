using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpDepo
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getdepoqry = $"{dbSchema}ufn_select_depo";
        private static readonly string insdepoqry = $"{dbSchema}ufn_insert_depo";
        private static readonly string updatedepoqry = $"{dbSchema}ufn_update_depo";
        private static readonly string getDepo = $"SELECT * FROM {getdepoqry}()";
        #endregion procedures

        #region sp for Depo

        public static string SpInsDepo(InsDepoModel rqModel)
        {
            string qry = $"SELECT * FROM {insdepoqry}(depoid := {rqModel.Depoid}, deponame := '{rqModel.Deponame}', housenumber := '{rqModel.Housenumber}', " +
                       $" commonstreet := {rqModel.Commonstreet}, superdealer := {rqModel.Superdealer}" +
                       $")";
            return qry;
        }
        public static string SpUpdateDepo(UpdateDepoModel rqModel)
        {
            string qry = $"SELECT * FROM {updatedepoqry}(depoid := {rqModel.Depoid}, deponame := '{rqModel.Deponame}', housenumber := '{rqModel.Housenumber}', " +
                       $" commonstreet := {rqModel.Commonstreet}, superdealer := {rqModel.Superdealer}" +
                       $")";

            return qry;
        }
        public static string SpGetDepo(GetDepoModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getDepo;
            }
            else
            {
              string  qry = $"SELECT * FROM {getdepoqry}({(rqModel.Depoid != null ? $"depoid := {rqModel.Depoid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Deponame) ? $"deponame := '{rqModel.Deponame}', " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Housenumber) ? $"housenumber := '{rqModel.Housenumber}', " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                      $"{(rqModel.Commonstreet != null ? $"commonstreet := {rqModel.Commonstreet}, " : "")} " +
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

        public static string SpUpdateDepoStatus(RequestDepoStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updatedepoqry}(depoid := {rqModel.Depoid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Depo
    }
}
