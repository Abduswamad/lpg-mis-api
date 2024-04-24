using Gas.Model.CompanyManagement;

namespace Gas.Infrastructure.DBQueries.SchemaCompanyManagement
{
    public static class SpCylinder
    {
        #region procedures
        private static readonly string dbSchema = "company_management.";
        private static readonly string getcylinderqry = $"{dbSchema}ufn_select_cylinder";
        private static readonly string inscylinderqry = $"{dbSchema}ufn_insert_cylinder";
        private static readonly string updatecylinderqry = $"{dbSchema}ufn_update_cylinder";
        private static readonly string getCylinder = $"SELECT * FROM {getcylinderqry}()";

        #endregion procedures

        #region sp for Cylinder
        //public static string getCylinder = getCylinder;
        public static string SpInsCylinder(InsCylinderModel rqModel)
        {
            string qry = $"SELECT * FROM {inscylinderqry}(cylinderid := {rqModel.Cylinderid}, cylindername := '{rqModel.Cylindername}'," +
                       $" cylindercompany := {rqModel.Cylindercompany}, superdealer := {rqModel.Superdealer}" +
                       $")";
            return qry;
        }
        public static string SpUpdateCylinder(UpdateCylinderModel rqModel)
        {
            string qry = $"SELECT * FROM {updatecylinderqry}(cylinderid := {rqModel.Cylinderid}, cylindername := '{rqModel.Cylindername}', " +
                       $" cylindercompany := {rqModel.Cylindercompany}, superdealer := {rqModel.Superdealer}" +
                       $")";

            return qry;
        }
        public static string SpGetCylinder(GetCylinderModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getCylinder;
            }
            else
            {
              string  qry = $"SELECT * FROM {getcylinderqry}({(rqModel.Cylinderid != null ? $"Cylinderid := {rqModel.Cylinderid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Cylindername) ? $"Cylindername := '{rqModel.Cylindername}', " : "")} " +
                      $"{(rqModel.Superdealer != null ? $"superdealer := {rqModel.Superdealer}, " : "")} " +
                      $"{(rqModel.Cylindercompany != null ? $"cylindercompany := {rqModel.Cylindercompany}, " : "")} " +
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

        public static string SpUpdateCylinderStatus(RequestCylinderStatusModel rqModel)
        {
            string qry = $"SELECT * FROM {updatecylinderqry}(Cylinderid := {rqModel.Cylinderid},isactive := {rqModel.Isactive})";
            return qry;
        }

        #endregion sp for Cylinder
    }
}
