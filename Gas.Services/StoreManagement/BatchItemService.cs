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

        public FullBatchItemEntity GetBatchItemById(int Batchid)
        {
            FullBatchItemEntity fullBatchItemEntity = new FullBatchItemEntity();
            List<CylinderEntity> cylinderEntities = new List<CylinderEntity>();
            List<AccessoryEntity> accessoryEntities = new List<AccessoryEntity>();
            GetBatchItemModel? rqModel = new GetBatchItemModel
            {
                Batchid = Batchid
            };
            var rqCylinderModel = GetBatchItem(rqModel);

            if (rqCylinderModel.Count>0)
            {
                fullBatchItemEntity.Batch_id = rqCylinderModel[0].Batch_id;
                fullBatchItemEntity.Batch_type_id = rqCylinderModel[0].Batch_type_id;
                fullBatchItemEntity.Batch_type_name = rqCylinderModel[0].Batch_type_name;
                fullBatchItemEntity.Truck_id = rqCylinderModel[0].Truck_id;
                fullBatchItemEntity.Plate_number = rqCylinderModel[0].Plate_number;
                fullBatchItemEntity.Driver_id = rqCylinderModel[0].Driver_id;
                fullBatchItemEntity.Driver_name = rqCylinderModel[0].Driver_name;
                fullBatchItemEntity.Depo_id = rqCylinderModel[0].Depo_id;
                fullBatchItemEntity.Depo_name = rqCylinderModel[0].Depo_name;
                fullBatchItemEntity.Batch_date = rqCylinderModel[0].Batch_date;

                foreach (var item in rqCylinderModel)
                {
                    CylinderEntity cylinderEntity = new CylinderEntity();

                    cylinderEntity.Cylinder_id = item.Cylinder_id;
                    cylinderEntity.Cylinder_name = item.Cylinder_name;
                    cylinderEntity.Cylinder_company_id = item.Cylinder_company_id;
                    cylinderEntity.Cylinder_company_name = item.Cylinder_company_name;
                    cylinderEntity.Super_dealer_id = item.Super_dealer_id;
                    cylinderEntity.Super_dealer_name = item.Super_dealer_name;
                    cylinderEntity.Cylinder_status_id = item.Cylinder_status_id;
                    cylinderEntity.Cylinder_status_name = item.Cylinder_status_name;
                    cylinderEntity.Cylinder_quantity = item.Cylinder_quantity;

                    cylinderEntities.Add(cylinderEntity);

                }

                fullBatchItemEntity.Cylinders = cylinderEntities;

                GetAccessoryBatchItemModel? rqModel2 = new GetAccessoryBatchItemModel
                {
                    Batchid = Batchid
                };

                var rqcessoryModel = new AccessoryBatchItemService().GetAccessoryBatchItem(rqModel2);

                foreach(var item in rqcessoryModel)
                {
                    AccessoryEntity accessoryEntity = new AccessoryEntity();

                    accessoryEntity.Accessory_id = item.Accessory_id;
                    accessoryEntity.Accessory_name = item.Accessory_name;
                    accessoryEntity.Accessory_brand_id = item.Accessory_brand_id;
                    accessoryEntity.Accessory_brand_name = item.Accessory_brand_name;
                    accessoryEntity.Super_dealer_id = item.Super_dealer_id;
                    accessoryEntity.Super_dealer_name = item.Super_dealer_name;
                    accessoryEntity.Accessory_quantity = item.Accessory_quantity;

                    accessoryEntities.Add(accessoryEntity);

                }

                fullBatchItemEntity.Accessorys = accessoryEntities;

                return fullBatchItemEntity;
            }
            else
            {
                return fullBatchItemEntity;
            }
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

                        if (rqModel.Batchtype == CodesBatchType.IN)
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

                        else if (getStore != null)
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

                    foreach (var accessory in rqModel.Accessors)
                    {
                        //AccessorystockModel? rqStoreModel = new AccessorystockModel
                        //{
                        //    Stockdate = rqModel.Stockdate,
                        //    Store = rqModel.Store,
                        //    Accessoryid = accessory.Accessoryid,
                        //};

                        //var getStore = new AccessoryBatchItemService(). GetAccessorystock(rqStoreModel);

                        IList<AccessorystockEntity> getStore = null;

                        if (rqModel.Batchtype == CodesBatchType.OUT)
                        {
                            AccessorystockModel? rqStoreModel = new AccessorystockModel
                            {
                                Stockdate = rqModel.Stockdate,
                                Store = rqModel.Store,
                                Accessoryid = accessory.Accessoryid,
                            };

                            getStore = new AccessoryBatchItemService().GetAccessorystock(rqStoreModel);
                        }

                        if (rqModel.Batchtype == CodesBatchType.IN)
                        {
                            InsAccessoryBatchItemModel rqAccessoryModel = new InsAccessoryBatchItemModel()
                            {
                                Accessoryid = accessory.Accessoryid,
                                Accessoryquantity = accessory.Accessoryquantity,
                                Batchid = batch
                            };

                            queryResEntity = new AccessoryBatchItemService().AddAccessoryBatchItem(rqAccessoryModel);
                        }


                        else if (getStore != null)
                        {
                            if (getStore.Count > 0)
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
