using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaStoreManagement
{
    public static class SpBatchItem
    {
        #region procedures
        private static readonly string dbSchema = "store.";
        private static readonly string insertBatchqry = $"{dbSchema}ufn_insert_cylinder_batch_item";
        private static readonly string getBatchqry = $"{dbSchema}ufn_select_cylinder_batch_item";
        private static readonly string deleteBatchqry = $"{dbSchema}ufn_delete_cylinder_batch_item";
        private static readonly string getBatch = $"SELECT * FROM {getBatchqry}()";

        #endregion procedures

        #region sp for Batch
        //public static string getBatch = $"SELECT * FROM {getBatchqry}()";

        public static string SpGetBatchItem(GetBatchItemModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getBatch;
            }
            else
            {
              string  qry = $"SELECT * FROM {getBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                      $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                      $"{(rqModel.Cylinderstatus != null ? $"cylinderstatus := {rqModel.Cylinderstatus}, " : "")} " +
                      $"{(rqModel.Cylinderquantity != null ? $"cylinderquantity := {rqModel.Cylinderquantity}, " : "")} " +
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

        public static string SpInsertBatchItem(InsBatchItemModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {insertBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                        $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                        $"{(rqModel.Cylinderstatus != null ? $"cylinderstatus := {rqModel.Cylinderstatus}, " : "")} " +
                        $"{(rqModel.Cylinderquantity != null ? $"cylinderquantity := {rqModel.Cylinderquantity}, " : "")} " +
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

        public static string SpDeleteBatchItem(DelBatchItemModel rqModel)
        {
            string result;
            string qry = $"SELECT * FROM {deleteBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                        $"{(rqModel.Cylinderid != null ? $"cylinderid := {rqModel.Cylinderid}, " : "")} " +
                        $"{(rqModel.Cylinderstatus != null ? $"cylinderstatus := {rqModel.Cylinderstatus}, " : "")} " +
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

        #endregion sp for Batch
    }
}
