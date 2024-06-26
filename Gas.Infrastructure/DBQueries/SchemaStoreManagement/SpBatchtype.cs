﻿using Gas.Model.StoreManagement;

namespace Gas.Infrastructure.DBQueries.SchemaStoreManagement
{
    public static class SpBatchtype
    {
        #region procedures
        private static readonly string dbSchema = "store.";
        private static readonly string getBatchtypeqry = $"{dbSchema}ufn_select_batch_type";
        private static readonly string getBatchtype = $"SELECT * FROM {getBatchtypeqry}()";

        #endregion procedures

        #region sp for Batchtype
        //public static string getBatchtype = dbSelect;

        public static string SpGetBatchtype(GetBatchtypeModel? rqModel)
        {
            string result;
            if (rqModel == null)
            {
                result = getBatchtype;
            }
            else
            {
              string  qry = $"SELECT * FROM {getBatchtypeqry}({(rqModel.Batchtypeid != null ? $"batchtypeid := {rqModel.Batchtypeid}, " : "")} " +
                      $"{(!string.IsNullOrEmpty(rqModel.Batchtypename) ? $"batchtypename := '{rqModel.Batchtypename}', " : "")} " +
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

        #endregion sp for Batchtype
    }
}
