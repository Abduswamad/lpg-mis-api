using DBConnector;
using Gas.Domain.Entities;
using Gas.Domain.Entity.SalesManagement;
using Gas.Domain.Enums;
using Gas.Infrastructure.DBQueries.SchemaSalesManagement;
using Gas.Model.CompanyManagement;
using Gas.Model.SalesManagement;
using Gas.Utils.Settings;
using Npgsql;
using System.Data.SqlClient;

namespace Gas.Services.SalesManagement
{
    public class AccessoryIndicativePriceService
    {
        readonly PSQLCONNECT conn = new (ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all Batch
        public IList<AccessoryIndicativePriceEntity> GetAccessoryIndicativePrice()
        {
            try
            {
                IList<AccessoryIndicativePriceEntity> Batch = conn.spGetData<AccessoryIndicativePriceEntity>(null!, SpAccessoryIndicativePrice.SpGetAccessoryIndicativePrice(null));
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
        public IList<AccessoryIndicativePriceEntity> GetAccessoryIndicativePrice(GetAccessoryIndicativePriceModel? rqModel)
        {
            try
            {
                IList<AccessoryIndicativePriceEntity> Batch = conn.spGetData<AccessoryIndicativePriceEntity>(null!, SpAccessoryIndicativePrice.SpGetAccessoryIndicativePrice(rqModel!));
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

        public QueryResEntity AddAccessoryIndicativePrice(InsAccessoryIndicativePriceModel rqModel)
        {
            try
            {
                int? number = 0;
                var data = GetAccessoryIndicativePrice(null).OrderByDescending(x => x.Accessory_indicative_price_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    var checkeddata = data.Where(x => x.Accessory_id == rqModel.Accessoryid).ToList();

                    if (checkeddata.Count > 0)
                    {
                        if ((bool)!checkeddata[0].Is_active!)
                        {
                            UpdateAccessoryIndicativePriceStatusModel rqIsActiveModel = new()
                            {
                                Accessoryindicativepriceid = (int)checkeddata[0].Accessory_indicative_price_id!,
                                IsActive = true
                            };
                            var status = UpdateAccessoryIndicativePriceStatus(rqIsActiveModel);
                            return status;
                        }

                        QueryResEntity queryResEntity = new ()
                        {
                            Code = Codes.BadRequest,
                            Msg = $"Accessory already contain Price"
                        };
                        return queryResEntity;

                    }
                    number = data[0].Accessory_indicative_price_id + 1;
                }
                
                rqModel.Accessoryindicativepriceid = number;
                IList<QueryResEntity> batch = conn.spGetData<QueryResEntity>(null!, SpAccessoryIndicativePrice.SpInsertAccessoryIndicativePrice(rqModel));
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

        public QueryResEntity UpdateAccessoryIndicativePrice(UpdateAccessoryIndicativePriceModel rqModel)
        {
            try
            {
                var data = GetAccessoryIndicativePrice(null).Where(x => x.Accessory_id == rqModel.Accessoryid).ToList();
                if (data.Count > 0)
                {
                    if (data[0].Accessory_indicative_price_id != rqModel.Accessoryindicativepriceid)
                    {
                        QueryResEntity queryResEntity = new ()
                        {
                            Code = Codes.BadRequest,
                            Msg = "Accessory already contain Price"
                        };
                        return queryResEntity;
                    }                   
                }
                IList<QueryResEntity> batch = conn.spGetData<QueryResEntity>(null!, SpAccessoryIndicativePrice.SpUpdateAccessoryIndicativePrice(rqModel));
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
        
        public QueryResEntity UpdateAccessoryIndicativePriceStatus(UpdateAccessoryIndicativePriceStatusModel rqModel)
        {
            try
            {
                IList<QueryResEntity> batch = conn.spGetData<QueryResEntity>(null!, SpAccessoryIndicativePrice.SpUpdateAccessoryIndicativePriceStatus(rqModel));
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
