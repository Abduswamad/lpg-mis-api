using DBConnector;
using Gas.Domain.Entities;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Domain.Enums;
using Gas.Infrastructure.DBQueries.SchemaCompanyManagement;
using Gas.Model.CompanyManagement;
using Gas.Utils;
using Gas.Utils.Settings;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data.SqlClient;

namespace Gas.Services.CompanyManagement
{
    public class DepoService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all Depo
        public IList<DepoEntity> GetDepo()
        {
            try
            {
                IList<DepoEntity> Depo = conn.spGetData<DepoEntity>(null, SpDepo.SpGetDepo(null));
                return Depo.Where(x => (bool)x.Is_active).ToList();
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
                    Logger.Logger.Error("NpgsqlException: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
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

        //Query to get Depo by Model
        public IList<DepoEntity> GetDepo(GetDepoModel? rqModel)
        {
            try
            {
                IList<DepoEntity> Depo = conn.spGetData<DepoEntity>(null, SpDepo.SpGetDepo(rqModel!));
                return Depo;
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
                    Logger.Logger.Error("NpgsqlException: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
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

        public QueryResEntity AddDepo(InsDepoModel rqModel)
        {
            try
            {
                int? number = 0;
                var data = GetDepo(null).OrderByDescending(x => x.Depo_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    number = data[0].Depo_id + 1;
                }
                var CheckDepoExist = data.Where(x => x.Depo_name.ToLower() == rqModel.Deponame.ToLower()).ToList();

                if (CheckDepoExist.Count > 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Depo with Depo Name {rqModel.Deponame} already exist"
                    };
                    return res;
                }
                else
                {
                    rqModel.Depoid = number;
                    IList<QueryResEntity> Depo = conn.spGetData<QueryResEntity>(null, SpDepo.SpInsDepo(rqModel));
                    return Depo.First();
                }

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
                    Logger.Logger.Error("NpgsqlException: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
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

        public QueryResEntity UpdateDepo(UpdateDepoModel rqModel)
        {
            try
            {
                var data = GetDepo(null).OrderByDescending(x => x.Depo_id).ToList();

                IList<QueryResEntity> Depo = conn.spGetData<QueryResEntity>(null, SpDepo.SpUpdateDepo(rqModel));
                return Depo.First();

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
                    Logger.Logger.Error("NpgsqlException: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
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

        public QueryResEntity UpdateStatusDepo(RequestDepoStatusModel rqModel)
        {
            try
            {
                var data = GetDepo(null).OrderByDescending(x => x.Depo_id).ToList();

                var CheckDepoExist = data.Where(x => x.Depo_id == rqModel.Depoid).ToList();

                if (CheckDepoExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Depo ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    IList<QueryResEntity> Depo = conn.spGetData<QueryResEntity>(null, SpDepo.SpUpdateDepoStatus(rqModel));
                    return Depo.First();
                }

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
                    Logger.Logger.Error("NpgsqlException: " + ex.InnerException == null?ex.Message: ex.InnerException.Message);
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