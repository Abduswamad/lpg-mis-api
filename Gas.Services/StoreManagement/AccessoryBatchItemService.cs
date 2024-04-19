using DBConnector;
using Gas.Domain.Entities;
using Gas.Domain.Entity.StoreManagement;
using Gas.Domain.Enums;
using Gas.Infrastructure.DBQueries.SchemaStoreManagement;
using Gas.Model.StoreManagement;
using Gas.Utils.Settings;
using Npgsql;
using System.Data.SqlClient;

namespace Gas.Services.StoreManagement
{
    public class AccessoryBatchItemService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all AccessoryBatchItem
        public IList<AccessoryBatchItemEntity> GetAccessoryBatchItem()
        {
            try
            {
                IList<AccessoryBatchItemEntity> AccessoryBatchItem = conn.spGetData<AccessoryBatchItemEntity>(null, SpAccessoryBatchItem.SpGetAccessoryBatchItem(null));
                return AccessoryBatchItem;
            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
                    throw new NpgsqlException("Unique constraint violation");
                }
                else
                {
                    // Handle other NpgsqlExceptions or unknown exceptions
                    Logger.Logger.Error("NpgsqlException: " + ex.Message);
                    throw new Exception(ex.Message);
                }

            }
            catch (SqlException ex)
            {
                Logger.Logger.Error($"SQL Exception: {ex.Message}");
                throw new Exception("SQL Error");
            }
            catch (InvalidOperationException ex)
            {
                Logger.Logger.Error($"Invalid Operation Exception: {ex.Message}");
                throw new InvalidOperationException("Invalid Operation");
            }
            catch (TimeoutException ex)
            {
                Logger.Logger.Error($"Timeout Exception: {ex.Message}");
                throw new TimeoutException("Request TimeOut");
            }
            #endregion catch
        }

        //Query to get AccessoryBatchItem by Model
        public IList<AccessoryBatchItemEntity> GetAccessoryBatchItem(GetAccessoryBatchItemModel? rqModel)
        {
            try
            {
                IList<AccessoryBatchItemEntity> AccessoryBatchItem = conn.spGetData<AccessoryBatchItemEntity>(null, SpAccessoryBatchItem.SpGetAccessoryBatchItem(rqModel!));
                return AccessoryBatchItem;
            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
                    throw new NpgsqlException("Unique constraint violation");
                }
                else
                {
                    // Handle other NpgsqlExceptions or unknown exceptions
                    Logger.Logger.Error("NpgsqlException: " + ex.Message);
                    throw new Exception(ex.Message);
                }

            }
            catch (SqlException ex)
            {
                Logger.Logger.Error($"SQL Exception: {ex.Message}");
                throw new Exception("SQL Error");
            }
            catch (InvalidOperationException ex)
            {
                Logger.Logger.Error($"Invalid Operation Exception: {ex.Message}");
                throw new InvalidOperationException("Invalid Operation");
            }
            catch (TimeoutException ex)
            {
                Logger.Logger.Error($"Timeout Exception: {ex.Message}");
                throw new TimeoutException("Request TimeOut");
            }
            #endregion catch
        }

        public QueryResEntity AddAccessoryBatchItem(InsAccessoryBatchItemModel rqModel)
        {
            try
            {
                IList<QueryResEntity> AccessoryBatchItem = conn.spGetData<QueryResEntity>(null, SpAccessoryBatchItem.SpInsertAccessoryBatchItem(rqModel));
                return AccessoryBatchItem.First();

            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Unique constraint violation");
                }
                else
                {
                    // Handle other NpgsqlExceptions or unknown exceptions
                    Logger.Logger.Error("NpgsqlException: " + ex.Message);
                    throw new Exception(ex.Message);
                }

            }
            catch (SqlException ex)
            {
                Logger.Logger.Error($"SQL Exception: {ex.Message}");
                throw new Exception("SQL Error");
            }
            catch (InvalidOperationException ex)
            {
                Logger.Logger.Error($"Invalid Operation Exception: {ex.Message}");
                throw new InvalidOperationException("Invalid Operation");
            }
            catch (TimeoutException ex)
            {
                Logger.Logger.Error($"Timeout Exception: {ex.Message}");
                throw new TimeoutException("Request TimeOut");
            }
            #endregion catch
        }

        public QueryResEntity DeleteAccessoryBatchItem(DelAccessoryBatchItemModel rqModel)
        {
            try
            {
                IList<QueryResEntity> AccessoryBatchItem = conn.spGetData<QueryResEntity>(null, SpAccessoryBatchItem.SpDeleteAccessoryBatchItem(rqModel));
                return AccessoryBatchItem.First();

            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Unique constraint violation");
                }
                else
                {
                    // Handle other NpgsqlExceptions or unknown exceptions
                    Logger.Logger.Error("NpgsqlException: " + ex.Message);
                    throw new Exception(ex.Message);
                }

            }
            catch (SqlException ex)
            {
                Logger.Logger.Error($"SQL Exception: {ex.Message}");
                throw new Exception("SQL Error");
            }
            catch (InvalidOperationException ex)
            {
                Logger.Logger.Error($"Invalid Operation Exception: {ex.Message}");
                throw new InvalidOperationException("Invalid Operation");
            }
            catch (TimeoutException ex)
            {
                Logger.Logger.Error($"Timeout Exception: {ex.Message}");
                throw new TimeoutException("Request TimeOut");
            }
            #endregion catch
        }

        public IList<AccessorystockEntity> GetAccessorystock(AccessorystockModel? rqModel)
        {
            try
            {
                IList<AccessorystockEntity> Batch = conn.spGetData<AccessorystockEntity>(null, SpAccessoryBatchItem.SpGetAccessoryStock(rqModel!));
                return Batch;
            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Unique constraint violation");
                }
                else
                {
                    // Handle other NpgsqlExceptions or unknown exceptions
                    Logger.Logger.Error("NpgsqlException: " + ex.Message);
                    throw new Exception(ex.Message);
                }

            }
            catch (SqlException ex)
            {
                Logger.Logger.Error($"SQL Exception: {ex.Message}");
                throw new Exception("SQL Error");
            }
            catch (InvalidOperationException ex)
            {
                Logger.Logger.Error($"Invalid Operation Exception: {ex.Message}");
                throw new InvalidOperationException("Invalid Operation");
            }
            catch (TimeoutException ex)
            {
                Logger.Logger.Error($"Timeout Exception: {ex.Message}");
                throw new TimeoutException("Request TimeOut");
            }
            #endregion catch
        }

        public QueryResEntity AddAccessoryBatchItemWithChecks(AddAccessoryBatchItemWithChecksModel rqModel)
        {
            try
            {
                QueryResEntity queryResEntity = new QueryResEntity();

                BatchService batchService = new BatchService();

                InsBatchModel rqBatchModel = new InsBatchModel()
                {
                    Batchdate = rqModel.Batchdate,
                    Batchdepo = rqModel.Batchdepo,
                    Batchdriver = rqModel.Batchdriver,
                    Batchtruck  = rqModel.Batchtruck,
                    Batchtype = rqModel.Batchtype,
                };

                var batch = batchService.AddBatchReturnBatch(rqBatchModel);

                if(batch == 0)
                {
                    queryResEntity = new QueryResEntity()
                    {
                        Code = Codes.BadRequest,
                        Msg = "Failed to Add batch"
                    };
                }
                else
                {
                    foreach (var accessory in rqModel.Accessors)
                    {
                        IList<AccessorystockEntity> getStore = null;

                        if (rqModel.Batchtype == CodesBatchType.OUT)
                        {
                            AccessorystockModel? rqStoreModel = new AccessorystockModel
                            {
                                Stockdate = rqModel.Stockdate,
                                Store = rqModel.Store,
                                Accessoryid = accessory.Accessoryid,
                            };

                            getStore = GetAccessorystock(rqStoreModel);
                        }                           

                        if (rqModel.Batchtype == CodesBatchType.IN)
                        {
                            InsAccessoryBatchItemModel rqAccessoryModel = new InsAccessoryBatchItemModel()
                            {
                                Accessoryid = accessory.Accessoryid,
                                Accessoryquantity = accessory.Accessoryquantity,
                                Batchid = batch
                            };

                            queryResEntity = AddAccessoryBatchItem(rqAccessoryModel);
                        }
                        
                        else if (getStore != null)
                        {
                            if (getStore.Count > 0)
                            {
                                if(rqModel.Batchtype == CodesBatchType.OUT)
                                {
                                    if (getStore[0].Total_quantity_remain >= accessory.Accessoryquantity)
                                    {
                                        InsAccessoryBatchItemModel rqAccessoryModel = new InsAccessoryBatchItemModel()
                                        {
                                            Accessoryid = accessory.Accessoryid,
                                            Accessoryquantity = accessory.Accessoryquantity,
                                            Batchid = batch
                                        };
                                        queryResEntity = AddAccessoryBatchItem(rqAccessoryModel);
                                    }
                                    else
                                    {
                                        queryResEntity = new QueryResEntity()
                                        {
                                            Code = Codes.BadRequest,
                                            Msg = $"Accessory Quantity Remain {getStore[0].Total_quantity_remain}"
                                        };
                                    }
                                }
                                else
                                {
                                    InsAccessoryBatchItemModel rqAccessoryModel = new InsAccessoryBatchItemModel()
                                    {
                                        Accessoryid = accessory.Accessoryid,
                                        Accessoryquantity = accessory.Accessoryquantity,
                                        Batchid = batch
                                    };
                                    queryResEntity = AddAccessoryBatchItem(rqAccessoryModel);
                                }
                            }
                            else
                            {
                                queryResEntity = new QueryResEntity()
                                {
                                    Code = Codes.BadRequest,
                                    Msg = $"Accessory Store is Empty"
                                };
                            }
                        }
                        else
                        {
                            queryResEntity = new QueryResEntity()
                            {
                                Code = Codes.BadRequest,
                                Msg = $"Accessory Store is Empty"
                            };
                        }
                    }
                }               

                return queryResEntity;

            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                    throw new NpgsqlException("Unique constraint violation");
                }
                else
                {
                    // Handle other NpgsqlExceptions or unknown exceptions
                    Logger.Logger.Error("NpgsqlException: " + ex.Message);
                    throw new Exception(ex.Message);
                }

            }
            catch (SqlException ex)
            {
                Logger.Logger.Error($"SQL Exception: {ex.Message}");
                throw new Exception("SQL Error");
            }
            catch (InvalidOperationException ex)
            {
                Logger.Logger.Error($"Invalid Operation Exception: {ex.Message}");
                throw new InvalidOperationException("Invalid Operation");
            }
            catch (TimeoutException ex)
            {
                Logger.Logger.Error($"Timeout Exception: {ex.Message}");
                throw new TimeoutException("Request TimeOut");
            }
            #endregion catch
        }
    
    }
}
