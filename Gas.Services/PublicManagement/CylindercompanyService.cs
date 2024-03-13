using DBConnector;
using Gas.Domain.Entities;
using Gas.Domain.Entity.PublicManagement;
using Gas.Domain.Enums;
using Gas.Infrastructure.DBQueries.SchemaPublicManagement;
using Gas.Model.PublicManagement;
using Gas.Utils;
using Gas.Utils.Settings;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data.SqlClient;

namespace Gas.Services.PublicManagement
{
    public class CylindercompanyService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all Cylindercompany
        public IList<CylindercompanyEntity> GetCylindercompany()
        {
            try
            {
                IList<CylindercompanyEntity> Cylindercompany = conn.spGetData<CylindercompanyEntity>(null, SpCylindercompany.SpGetCylindercompany(null));
                return Cylindercompany.Where(x => (bool)x.Is_active).ToList();
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

        //Query to get Cylindercompany by Model
        public IList<CylindercompanyEntity> GetCylindercompany(GetCylindercompanyModel? rqModel)
        {
            try
            {
                IList<CylindercompanyEntity> Cylindercompany = conn.spGetData<CylindercompanyEntity>(null, SpCylindercompany.SpGetCylindercompany(rqModel!));
                return Cylindercompany;
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

        public QueryResEntity AddCylindercompany(InsCylindercompanyModel rqModel)
        {
            try
            {
                int? number = 0;
                var data = GetCylindercompany(null).OrderByDescending(x => x.Cylinder_company_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    number = data[0].Cylinder_company_id + 1;
                }
                var CheckCylindercompanyExist = data.Where(x => x.Cylinder_company_name.ToLower() == rqModel.Cylindercompanyname.ToLower()).ToList();

                if (CheckCylindercompanyExist.Count > 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Cylindercompany with Cylindercompany Name {rqModel.Cylindercompanyname} already exist"
                    };
                    return res;
                }
                else
                {
                    rqModel.Cylindercompanyid = number;
                    IList<QueryResEntity> Cylindercompany = conn.spGetData<QueryResEntity>(null, SpCylindercompany.SpInsCylindercompany(rqModel));
                    return Cylindercompany.First();
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

        public QueryResEntity UpdateCylindercompany(UpdateCylindercompanyModel rqModel)
        {
            try
            {
                var data = GetCylindercompany(null).OrderByDescending(x => x.Cylinder_company_id).ToList();

                IList<QueryResEntity> Cylindercompany = conn.spGetData<QueryResEntity>(null, SpCylindercompany.SpUpdateCylindercompany(rqModel));
                return Cylindercompany.First();

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

        public QueryResEntity UpdateStatusCylindercompany(RequestCylindercompanyStatusModel rqModel)
        {
            try
            {
                var data = GetCylindercompany(null).OrderByDescending(x => x.Cylinder_company_id).ToList();

                var CheckCylindercompanyExist = data.Where(x => x.Cylinder_company_id == rqModel.Cylindercompanyid).ToList();

                if (CheckCylindercompanyExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Cylindercompany ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    IList<QueryResEntity> Cylindercompany = conn.spGetData<QueryResEntity>(null, SpCylindercompany.SpUpdateCylindercompanyStatus(rqModel));
                    return Cylindercompany.First();
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