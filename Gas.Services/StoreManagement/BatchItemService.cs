using DBConnector;
using Gas.Domain.Entities;
using Gas.Domain.Entity.StoreManagement;
using Gas.Domain.Enums;
using Gas.Infrastructure.DBQueries.SchemaStoreManagement;
using Gas.Model.PublicManagement;
using Gas.Model.StoreManagement;
using Gas.Utils.Settings;
using Npgsql;
using System.Data.SqlClient;

namespace Gas.Services.StoreManagement
{
    public class BatchItemService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all BatchItem
        public IList<BatchItemEntity> GetBatchItem()
        {
            try
            {
                IList<BatchItemEntity> BatchItem = conn.spGetData<BatchItemEntity>(null, SpBatchItem.SpGetBatchItem(null));
                return BatchItem;
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

        //Query to get BatchItem by Model
        public IList<BatchItemEntity> GetBatchItem(GetBatchItemModel? rqModel)
        {
            try
            {
                IList<BatchItemEntity> BatchItem = conn.spGetData<BatchItemEntity>(null, SpBatchItem.SpGetBatchItem(rqModel!));
                return BatchItem;
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

        public QueryResEntity AddBatchItem(InsBatchItemModel rqModel)
        {
            try
            {
                IList<QueryResEntity> Batchitem = conn.spGetData<QueryResEntity>(null, SpBatchItem.SpInsertBatchItem(rqModel));
                return Batchitem.First();

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

        public QueryResEntity DeleteBatchItem(DelBatchItemModel rqModel)
        {
            try
            {
                IList<QueryResEntity> Batchitem = conn.spGetData<QueryResEntity>(null, SpBatchItem.SpDeleteBatchItem(rqModel));
                return Batchitem.First();

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

        public IList<CylinderstockEntity> GetCylinderstock(CylinderstockModel? rqModel)
        {
            try
            {
                IList<CylinderstockEntity> Batch = conn.spGetData<CylinderstockEntity>(null, SpBatch.SpGetCylinderStock(rqModel!));
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

        public QueryResEntity AddCylinderBatchItemWithChecks(AddCylinderBatchItemWithChecksModel rqModel)
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
                    Batchtruck = rqModel.Batchtruck,
                    Batchtype = rqModel.Batchtype,
                };

                var batch = batchService.AddBatchReturnBatch(rqBatchModel);

                if (batch == 0)
                {
                    queryResEntity = new QueryResEntity()
                    {
                        Code = Codes.BadRequest,
                        Msg = "Failed to Add batch"
                    };
                }
                else
                {
                    foreach (var Cylinder in rqModel.Cylinders)
                    {
                        CylinderstockModel? rqStoreModel = new CylinderstockModel
                        {
                            Stockdate = rqModel.Stockdate,
                            Store = rqModel.Store,
                            Cylinderid = Cylinder.Cylinderid,
                            Cylinderstatusid = Cylinder.Cylinderstatus,
                        };

                        var getStore = GetCylinderstock(rqStoreModel);

                        if (getStore != null)
                        {
                            if (getStore.Count > 0)
                            {
                                if (rqModel.Batchtype == CodesBatchType.OUT)
                                {
                                    if (getStore[0].Total_quantity_remain >= Cylinder.Cylinderquantity)
                                    {
                                        InsBatchItemModel rqCylinderModel = new InsBatchItemModel()
                                        {
                                            Cylinderid = Cylinder.Cylinderid,
                                            Cylinderquantity = Cylinder.Cylinderquantity,
                                            Batchid = batch,
                                            Cylinderstatus = Cylinder.Cylinderstatus,
                                        };
                                        queryResEntity = AddBatchItem(rqCylinderModel);
                                    }
                                    else
                                    {
                                        queryResEntity = new QueryResEntity()
                                        {
                                            Code = Codes.BadRequest,
                                            Msg = $"Cylinder Quantity Remain {getStore[0].Total_quantity_remain}"
                                        };
                                    }
                                }
                                else
                                {
                                    InsBatchItemModel rqCylinderModel = new InsBatchItemModel()
                                    {
                                        Cylinderid = Cylinder.Cylinderid,
                                        Cylinderquantity = Cylinder.Cylinderquantity,
                                        Batchid = batch,
                                        Cylinderstatus = Cylinder.Cylinderstatus,
                                    };
                                    queryResEntity = AddBatchItem(rqCylinderModel);
                                }
                            }
                            else
                            {
                                queryResEntity = new QueryResEntity()
                                {
                                    Code = Codes.BadRequest,
                                    Msg = $"Cylinder Store is Empty"
                                };
                            }
                        }
                        else
                        {
                            queryResEntity = new QueryResEntity()
                            {
                                Code = Codes.BadRequest,
                                Msg = $"Cylinder Store is Empty"
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

        public QueryResEntity AddBatchItemWithChecks(AddBatchItemWithChecksModel rqModel)
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
                    Batchtruck = rqModel.Batchtruck,
                    Batchtype = rqModel.Batchtype,
                };

                var batch = batchService.AddBatchReturnBatch(rqBatchModel);

                if (batch == 0)
                {
                    queryResEntity = new QueryResEntity()
                    {
                        Code = Codes.BadRequest,
                        Msg = "Failed to Add batch"
                    };
                }
                else
                {
                    foreach (var Cylinder in rqModel.Cylinders)
                    {
                        CylinderstockModel? rqStoreModel = new CylinderstockModel
                        {
                            Stockdate = rqModel.Stockdate,
                            Store = rqModel.Store,
                            Cylinderid = Cylinder.Cylinderid,
                            Cylinderstatusid = Cylinder.Cylinderstatus,
                        };

                        var getStore = GetCylinderstock(rqStoreModel);

                        if (getStore != null)
                        {
                            if (getStore.Count >= 0)
                            {
                                if (rqModel.Batchtype == CodesBatchType.OUT)
                                {
                                    if (getStore[0].Total_quantity_remain >= Cylinder.Cylinderquantity)
                                    {
                                        InsBatchItemModel rqCylinderModel = new InsBatchItemModel()
                                        {
                                            Cylinderid = Cylinder.Cylinderid,
                                            Cylinderquantity = Cylinder.Cylinderquantity,
                                            Batchid = batch,
                                            Cylinderstatus = Cylinder.Cylinderstatus,
                                        };
                                        queryResEntity = AddBatchItem(rqCylinderModel);
                                    }
                                    else
                                    {
                                        queryResEntity = new QueryResEntity()
                                        {
                                            Code = Codes.BadRequest,
                                            Msg = $"Cylinder Quantity Remain {getStore[0].Total_quantity_remain}"
                                        };
                                    }
                                }
                                else
                                {
                                    InsBatchItemModel rqCylinderModel = new InsBatchItemModel()
                                    {
                                        Cylinderid = Cylinder.Cylinderid,
                                        Cylinderquantity = Cylinder.Cylinderquantity,
                                        Batchid = batch,
                                        Cylinderstatus = Cylinder.Cylinderstatus,
                                    };
                                    queryResEntity = AddBatchItem(rqCylinderModel);
                                }
                            }
                            else
                            {
                                queryResEntity = new QueryResEntity()
                                {
                                    Code = Codes.BadRequest,
                                    Msg = $"Cylinder Store is Empty"
                                };
                            }
                        }
                        else
                        {
                            queryResEntity = new QueryResEntity()
                            {
                                Code = Codes.BadRequest,
                                Msg = $"Cylinder Store is Empty"
                            };
                        }
                    }

                    foreach (var accessory in rqModel.Accessors)
                    {
                        AccessorystockModel? rqStoreModel = new AccessorystockModel
                        {
                            Stockdate = rqModel.Stockdate,
                            Store = rqModel.Store,
                            Accessoryid = accessory.Accessoryid,
                        };

                        var getStore = new AccessoryBatchItemService(). GetAccessorystock(rqStoreModel);

                        if (getStore != null)
                        {
                            if (getStore.Count >= 0)
                            {
                                if (rqModel.Batchtype == CodesBatchType.OUT)
                                {
                                    if (getStore[0].Total_quantity_remain >= accessory.Accessoryquantity)
                                    {
                                        InsAccessoryBatchItemModel rqAccessoryModel = new InsAccessoryBatchItemModel()
                                        {
                                            Accessoryid = accessory.Accessoryid,
                                            Accessoryquantity = accessory.Accessoryquantity,
                                            Batchid = batch
                                        };
                                        queryResEntity = new AccessoryBatchItemService().AddAccessoryBatchItem(rqAccessoryModel);
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
                                    queryResEntity = new AccessoryBatchItemService().AddAccessoryBatchItem(rqAccessoryModel);
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
