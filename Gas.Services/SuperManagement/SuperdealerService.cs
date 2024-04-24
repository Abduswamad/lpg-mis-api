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
    public class SuperdealerService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all Superdealer
        public IList<SuperdealerEntity> GetSuperdealer()
        {
            try
            {
                IList<SuperdealerEntity> Superdealer = conn.spGetData<SuperdealerEntity>(null!, SpSuperdealer.SpGetSuperdealer(null));
                return Superdealer.Where(x => (bool)x.Is_active!).ToList();
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

        //Query to get Superdealer by Model
        public IList<SuperdealerEntity> GetSuperdealer(GetSuperdealerModel? rqModel)
        {
            try
            {
                IList<SuperdealerEntity> Superdealer = conn.spGetData<SuperdealerEntity>(null!, SpSuperdealer.SpGetSuperdealer(rqModel!));
                return Superdealer;
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

        public QueryResEntity AddSuperdealer(InsSuperdealerModel rqModel)
        {
            try
            {
                int? number = 0;
                var data = GetSuperdealer(null).OrderByDescending(x => x.Super_dealer_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    number = data[0].Super_dealer_id + 1;
                }
                var CheckSuperdealerExist = data.Where(x => x.Super_dealer_name.ToLower() == rqModel.Superdealername.ToLower()).ToList();

                if (CheckSuperdealerExist.Count > 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Superdealer with Superdealer Name {rqModel.Superdealername} already exist"
                    };
                    return res;
                }
                else
                {
                    rqModel.Superdealerid = number;
                    IList<QueryResEntity> Superdealer = conn.spGetData<QueryResEntity>(null!, SpSuperdealer.SpInsSuperdealer(rqModel));
                    return Superdealer.First();
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

        public QueryResEntity UpdateSuperdealer(UpdateSuperdealerModel rqModel)
        {
            try
            {
                var data = GetSuperdealer(null).OrderByDescending(x => x.Super_dealer_id).ToList();

                IList<QueryResEntity> Superdealer = conn.spGetData<QueryResEntity>(null!, SpSuperdealer.SpUpdateSuperdealer(rqModel));
                return Superdealer.First();

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

        public QueryResEntity UpdateStatusSuperdealer(RequestSuperdealerStatusModel rqModel)
        {
            try
            {
                var data = GetSuperdealer(null).OrderByDescending(x => x.Super_dealer_id).ToList();

                var CheckSuperdealerExist = data.Where(x => x.Super_dealer_id == rqModel.Superdealerid).ToList();

                if (CheckSuperdealerExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Superdealer ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    IList<QueryResEntity> Superdealer = conn.spGetData<QueryResEntity>(null!, SpSuperdealer.SpUpdateSuperdealerStatus(rqModel));
                    return Superdealer.First();
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