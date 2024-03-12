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
    public class StafftypeService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all Stafftype
        public IList<StaffTypeEntity> GetStafftype()
        {
            try
            {
                IList<StaffTypeEntity> Stafftype = conn.spGetData<StaffTypeEntity>(null, SpStafftype.SpGetStafftype(null));
                return Stafftype.Where(x => (bool)x.Is_active).ToList();
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
                    throw;
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

        //Query to get Stafftype by Model
        public IList<StaffTypeEntity> GetStafftype(GetStafftypeModel? rqModel)
        {
            try
            {
                IList<StaffTypeEntity> Stafftype = conn.spGetData<StaffTypeEntity>(null, SpStafftype.SpGetStafftype(rqModel!));
                return Stafftype;
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
                    throw;
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

        public QueryResEntity AddStafftype(InsStafftypeModel rqModel)
        {
            try
            {
                int? number = 0;
                var data = GetStafftype(null).OrderByDescending(x => x.Staff_type_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    number = data[0].Staff_type_id + 1;
                }
                var CheckStafftypeExist = data.Where(x => x.Staff_type_name.ToLower() == rqModel.Stafftypename.ToLower()).ToList();

                if (CheckStafftypeExist.Count > 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Stafftype with Stafftype Name {rqModel.Stafftypename} already exist"
                    };
                    return res;
                }
                else
                {
                    rqModel.Stafftypeid = number;
                    IList<QueryResEntity> Stafftype = conn.spGetData<QueryResEntity>(null, SpStafftype.SpInsStafftype(rqModel));
                    return Stafftype.First();
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
                    throw;
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

        public QueryResEntity UpdateStafftype(UpdateStafftypeModel rqModel)
        {
            try
            {
                var data = GetStafftype(null).OrderByDescending(x => x.Staff_type_id).ToList();

                IList<QueryResEntity> Stafftype = conn.spGetData<QueryResEntity>(null, SpStafftype.SpUpdateStafftype(rqModel));
                return Stafftype.First();

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
                    throw;
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

        public QueryResEntity UpdateStatusStafftype(RequestStafftypeStatusModel rqModel)
        {
            try
            {
                var data = GetStafftype(null).OrderByDescending(x => x.Staff_type_id).ToList();

                var CheckStafftypeExist = data.Where(x => x.Staff_type_id == rqModel.Stafftypeid).ToList();

                if (CheckStafftypeExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Stafftype ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    IList<QueryResEntity> Stafftype = conn.spGetData<QueryResEntity>(null, SpStafftype.SpUpdateStafftypeStatus(rqModel));
                    return Stafftype.First();
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
                    throw;
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