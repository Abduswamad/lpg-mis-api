using DBConnector;
using Gas.Domain.Entities;
using Gas.Domain.Entity.PublicManagement;
using Gas.Domain.Enums;
using Gas.Infrastructure.DBQueries.SchemaPublicManagement;
using Gas.Model.PublicManagement;
using Gas.Utils.Settings;
using Npgsql;
using System.Data.SqlClient;

namespace Gas.Services.PublicManagement
{
    public class AccessorybrandService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all Accessorybrand
        public IList<AccessorybrandEntity> GetAccessorybrand()
        {
            try
            {
                IList<AccessorybrandEntity> Accessorybrand = conn.spGetData<AccessorybrandEntity>(null!, SpAccessorybrand.SpGetAccessorybrand(null));
                return Accessorybrand.Where(x => (bool)x.Is_active!).ToList();
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
                else if (ex.SqlState == "42883")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Function not found: " + ex.Message);
                    throw new NpgsqlException("Function specified not found");
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

        //Query to get Accessorybrand by Model
        public IList<AccessorybrandEntity> GetAccessorybrand(GetAccessorybrandModel? rqModel)
        {
            try
            {
                IList<AccessorybrandEntity> Accessorybrand = conn.spGetData<AccessorybrandEntity>(null!, SpAccessorybrand.SpGetAccessorybrand(rqModel!));
                return Accessorybrand;
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
                else if (ex.SqlState == "42883")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Function not found: " + ex.Message);
                    throw new NpgsqlException("Function specified not found");
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

        public QueryResEntity AddAccessorybrand(InsAccessorybrandModel rqModel)
        {
            try
            {
                int? number = 0;
                var data = GetAccessorybrand(null).OrderByDescending(x => x.Accessory_brand_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    number = data[0].Accessory_brand_id + 1;
                }
                var CheckAccessorybrandExist = data.Where(x => x.Accessory_brand_name.ToLower() == rqModel.Accessorybrandname.ToLower()).ToList();

                if (CheckAccessorybrandExist.Count > 0)
                {
                    if ((bool)!CheckAccessorybrandExist[0].Is_active!)
                    {
                        RequestAccessorybrandStatusModel rqIsActiveModel = new RequestAccessorybrandStatusModel()
                        {
                            Accessorybrandid = (int)CheckAccessorybrandExist[0].Accessory_brand_id!,
                            Isactive = true
                        };
                        var status = UpdateStatusAccessorybrand(rqIsActiveModel);
                        return status;
                    }
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Accessorybrand with Accessorybrand Name {rqModel.Accessorybrandname} already exist"
                    };
                    return res;
                }
                else
                {
                    rqModel.Accessorybrandid = number;
                    IList<QueryResEntity> Accessorybrand = conn.spGetData<QueryResEntity>(null!, SpAccessorybrand.SpInsAccessorybrand(rqModel));
                    return Accessorybrand.First();
                }

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
                else if (ex.SqlState == "42883")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Function not found: " + ex.Message );
                    throw new NpgsqlException("Function specified not found");
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

        public QueryResEntity UpdateAccessorybrand(UpdateAccessorybrandModel rqModel)
        {
            try
            {
                var data = GetAccessorybrand(null).OrderByDescending(x => x.Accessory_brand_id).ToList();

                IList<QueryResEntity> Accessorybrand = conn.spGetData<QueryResEntity>(null!, SpAccessorybrand.SpUpdateAccessorybrand(rqModel));
                return Accessorybrand.First();

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
                else if (ex.SqlState == "42883")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Function not found: " + ex.Message);
                    throw new NpgsqlException("Function specified not found");
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

        public QueryResEntity UpdateStatusAccessorybrand(RequestAccessorybrandStatusModel rqModel)
        {
            try
            {
                var data = GetAccessorybrand(null).OrderByDescending(x => x.Accessory_brand_id).ToList();

                var CheckAccessorybrandExist = data.Where(x => x.Accessory_brand_id == rqModel.Accessorybrandid).ToList();

                if (CheckAccessorybrandExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Accessorybrand ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    IList<QueryResEntity> Accessorybrand = conn.spGetData<QueryResEntity>(null!, SpAccessorybrand.SpUpdateAccessorybrandStatus(rqModel));
                    return Accessorybrand.First();
                }

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
                else if (ex.SqlState == "42883")
                {
                    // Handle another constraint violation (e.g., unique constraint violation)
                    Logger.Logger.Error("Function not found: " + ex.Message);
                    throw new NpgsqlException("Function specified not found");
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