using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaStoreManagement
{
    public static class SpBatch
    {
        #region procedures
        private static readonly string dbSchema = "store.";
        private static readonly string insertBatchqry = $"{dbSchema}ufn_insert_batch";
        private static readonly string getCylinderstockqry = $"{dbSchema}ufn_get_cylinder_stock";
        private static readonly string getBatchqry = $"{dbSchema}ufn_select_batch";
        private static readonly string getBatch = $"SELECT * FROM {getBatchqry}()";

        #endregion procedures

        #region sp for Batch
       // public static string getBatch = getBatch;

        public static string SpGetBatch(GetBatchModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getBatch;
            }
            else
            {
              string  qry = $"SELECT * FROM {getBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                      $"{(rqModel.Batchtype != null ? $"batchtype := {rqModel.Batchtype}, " : "")} " +
                      $"{(rqModel.Batchdriver != null ? $"batchdriver := {rqModel.Batchdriver}, " : "")} " +
                      $"{(rqModel.Batchdepo != null ? $"batchdepo := {rqModel.Batchdepo}, " : "")} " +
                      $"{(rqModel.Batchtruck != null ? $"batchtruck := {rqModel.Batchtruck}, " : "")} " +
                      $"{(rqModel.Batchdate != null ? $"batchdate := '{rqModel.Batchdate?.ToString("yyyy-MM-dd")}', " : "")} " +
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

        public static string SpInsertBatch(InsBatchModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {insertBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                        $"{(rqModel.Batchtype != null ? $"batchtype := {rqModel.Batchtype}, " : "")} " +
                        $"{(rqModel.Batchdriver != null ? $"batchdriver := {rqModel.Batchdriver}, " : "")} " +
                        $"{(rqModel.Batchdepo != null ? $"batchdepo := {rqModel.Batchdepo}, " : "")} " +
                        $"{(rqModel.Batchtruck != null ? $"batchtruck := {rqModel.Batchtruck}, " : "")} " +
                        $"{(rqModel.Batchdate != null ? $"batchdate := '{rqModel.Batchdate?.ToString("yyyy-MM-dd")}', " : "")} " +
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

            return result;
        }

        public static string SpGetCylinderStock(CylinderstockModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getBatch;
            }
            else
            {
                string qry = $"SELECT * FROM {getCylinderstockqry}({(rqModel.Store != null ? $"store := {rqModel.Store}, " : "")} " +
                        $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                        $"{(rqModel.Cylinderstatusid != null ? $"cylinderstatusid := {rqModel.Cylinderstatusid}, " : "")} " +
                        $"{(rqModel.Stockdate != null ? $"stockdate := '{rqModel.Stockdate?.ToString("yyyy-MM-dd")}', " : "")} " +
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

        #endregion sp for Batch
    }
}
