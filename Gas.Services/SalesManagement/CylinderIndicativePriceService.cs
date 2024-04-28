using DBConnector;
using Gas.Domain.Entities;
using Gas.Domain.Entity.SalesManagement;
using Gas.Domain.Enums;
using Gas.Infrastructure.DBQueries.SchemaSalesManagement;
using Gas.Model.SalesManagement;
using Gas.Utils.Settings;
using Npgsql;
using System.Data.SqlClient;

namespace Gas.Services.SalesManagement
{
    public class CylinderIndicativePriceService
    {
        readonly PSQLCONNECT conn = new (ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all Batch
        public IList<CylinderIndicativePriceEntity> GetCylinderIndicativePrice()
        {
            try
            {
                IList<CylinderIndicativePriceEntity> Batch = conn.spGetData<CylinderIndicativePriceEntity>(null!, SpCylinderIndicativePrice.SpGetCylinderIndicativePrice(null));
                return Batch.Where(x => (bool)x.Is_active!).ToList();
            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException!.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException!.Message);
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

        //Query to get Batch by Model
        public IList<CylinderIndicativePriceEntity> GetCylinderIndicativePrice(GetCylinderIndicativePriceModel? rqModel)
        {
            try
            {
                IList<CylinderIndicativePriceEntity> Batch = conn.spGetData<CylinderIndicativePriceEntity>(null!, SpCylinderIndicativePrice.SpGetCylinderIndicativePrice(rqModel!));
                return Batch;
            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException!.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null?ex.Message: ex.InnerException!.Message);
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

        public QueryResEntity AddCylinderIndicativePrice(InsCylinderIndicativePriceModel rqModel)
        {
            try
            {
                int? number = 0;
                var data = GetCylinderIndicativePrice(null).OrderByDescending(x => x.Cylinder_indicative_price_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    var checkeddata = data.Where(x => x.Cylinder_id == rqModel.Cylinderid && x.Cylinder_category_id == rqModel.Cylindercategory).ToList();
                    if (checkeddata.Count > 0)
                    {
                        if ((bool)!checkeddata[0].Is_active!)
                        {
                            UpdateCylinderIndicativePriceStatusModel rqIsActiveModel = new()
                            {
                                Cylinderindicativepriceid = (int)checkeddata[0].Cylinder_indicative_price_id!,
                                IsActive = true
                            };
                            var status = UpdateCylinderIndicativePriceStatus(rqIsActiveModel);
                            return status;
                        }
                        else
                        {
                            QueryResEntity queryResEntity = new()
                            {
                                Code = Codes.BadRequest,
                                Msg = $"Cylinder already contain Price"
                            };
                            return queryResEntity;
                        }
                    }
                    
                    number = data[0].Cylinder_indicative_price_id + 1;
                }
                rqModel.Cylinderindicativepriceid = number;
                IList<QueryResEntity> batch = conn.spGetData<QueryResEntity>(null!, SpCylinderIndicativePrice.SpInsertCylinderIndicativePrice(rqModel));
                return batch.First();

            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
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

        public QueryResEntity UpdateCylinderIndicativePrice(UpdateCylinderIndicativePriceModel rqModel)
        {
            try
            {
                var data = GetCylinderIndicativePrice(null).Where(x => x.Cylinder_id == rqModel.Cylinderid && x.Cylinder_category_id == rqModel.Cylindercategory).ToList();
                if (data.Count > 0)
                {
                    if (data[0].Cylinder_indicative_price_id != rqModel.Cylinderindicativepriceid)
                    {
                        QueryResEntity queryResEntity = new ()
                        {
                            Code = Codes.BadRequest,
                            Msg = "Cylinder already contain Price"
                        };
                        return queryResEntity;
                    }
                }
                IList<QueryResEntity> batch = conn.spGetData<QueryResEntity>(null!, SpCylinderIndicativePrice.SpUpdateCylinderIndicativePrice(rqModel));
                return batch.First();

            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
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
        
        public QueryResEntity UpdateCylinderIndicativePriceStatus(UpdateCylinderIndicativePriceStatusModel rqModel)
        {
            try
            {
                IList<QueryResEntity> batch = conn.spGetData<QueryResEntity>(null!, SpCylinderIndicativePrice.SpUpdateCylinderIndicativePriceStatus(rqModel));
                return batch.First();

            }
            #region catch
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23514")
                {
                    // Handle a specific constraint violation (e.g., foreign key violation)
                    Logger.Logger.Error("Foreign key constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
                    throw new NpgsqlException("Foreign key constraint violation");
                }
                else if (ex.SqlState == "23505")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Unique constraint violation: " + ex.InnerException == null ? ex.Message : ex.InnerException!.Message);
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
