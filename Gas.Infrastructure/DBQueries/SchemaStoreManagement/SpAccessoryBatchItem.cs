using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaStoreManagement
{
    public static class SpAccessoryBatchItem
    {
        #region procedures
        private static readonly string dbSchema = "store.";
        private static readonly string insertBatchqry = $"{dbSchema}ufn_insert_accessory_batch_item";
        private static readonly string getBatchqry = $"{dbSchema}ufn_select_accessory_batch_item";
        private static readonly string deleteBatchqry = $"{dbSchema}ufn_delete_accessory_batch_item";
        private static readonly string getAccessorystockqry = $"{dbSchema}ufn_get_accessory_stock";


        #endregion procedures

        #region sp for Batch
        public static string getBatch = $"SELECT * FROM {getBatchqry}()";

        public static string SpGetAccessoryBatchItem(GetAccessoryBatchItemModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getBatch;
            }
            else
            {
              string  qry = $"SELECT * FROM {getBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                      $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                      $"{(rqModel.Accessoryquantity != null ? $"accessoryquantity := {rqModel.Accessoryquantity}, " : "")} " +
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

        public static string SpInsertAccessoryBatchItem(InsAccessoryBatchItemModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {insertBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                         $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
                         $"{(rqModel.Accessoryquantity != null ? $"accessoryquantity := {rqModel.Accessoryquantity}, " : "")} " +
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

        public static string SpDeleteAccessoryBatchItem(DelAccessoryBatchItemModel? rqModel)
        {
            string result = "";
            string qry = $"SELECT * FROM {deleteBatchqry}({(rqModel.Batchid != null ? $"batchid := {rqModel.Batchid}, " : "")} " +
                        $"{(rqModel.Accessoryid != null ? $"accessoryid := {rqModel.Accessoryid}, " : "")} " +
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

        public static string SpGetAccessoryStock(AccessorystockModel? rqModel)
        {
            string result = "";
            if (rqModel == null)
            {
                result = getBatch;
            }
            else
            {
                string qry = $"SELECT * FROM {getAccessorystockqry}({(rqModel.Store != null ? $"store := {rqModel.Store}, " : "")} " +
                        $"{(rqModel.Accessoryid != null ? $"Accessoryid := {rqModel.Accessoryid}, " : "")} " +
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
