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
    public class StaffService
    {
        readonly PSQLCONNECT conn = new PSQLCONNECT(ServiceSettings.GetWorkerServiceSettings().DBConnection.GasDB);

        //Query to get all User
        public IList<StaffEntity> GetStaff()
        {
            try
            {
                IList<StaffEntity> Users = conn.spGetData<StaffEntity>(null, SpStaff.SpGetStaff(null));
                return Users.Where(x => (bool)x.Is_active).ToList();
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
                    Logger.Logger.Error("NpgsqlException: " + ex.InnerException.Message);
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

        //Query to get Staff by Model
        public IList<StaffEntity> GetStaff(GetStaffModel? rqModel)
        {
            try
            {
                IList<StaffEntity> Users = conn.spGetData<StaffEntity>(null, SpStaff.SpGetStaff(rqModel!));
                return Users;
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

        public QueryResEntity AddStaff(InsStaffModel rqModel)
        {
            try
            {
                GetStaffModel getStaffModel = new GetStaffModel()
                {
                    Staffusername = rqModel.Staffusername
                };

                int? number = 0;
                var data = GetStaff(null).OrderByDescending(x => x.Staff_id).ToList();
                if (data.Count <= 0)
                {
                    number = 1;
                }
                else
                {
                    number = data[0].Staff_id + 1;
                }
                string userpass = UserUtils.CapitalizeFirstLetter($"{rqModel.Firstname.ToLower()}.{rqModel.Lastname}") + CodesMessage.DefaultPassword;
                string password = UserUtils.ComputePasswordHash(userpass);
                var CheckUserExist = data.Where(x => x.Username.ToLower() == rqModel.Staffusername.ToLower() || x.Staff_id_number.ToLower() == rqModel.Staffidnumber).ToList();

                if (CheckUserExist.Count > 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Staff with Username {rqModel.Staffusername} already exist with Staff Id Number {rqModel.Staffidnumber}"
                    };
                    return res;
                }
                else
                {
                    rqModel.Staffpassword = password;
                    rqModel.Staffid = number;
                    IList<QueryResEntity> Staff = conn.spGetData<QueryResEntity>(null, SpStaff.SpInsStaff(rqModel));
                    return Staff.First();
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

        public QueryResEntity UpdateStaff(UpdateStaffModel rqModel)
        {
            try
            {
                var data = GetStaff(null).OrderByDescending(x => x.Staff_id).ToList();
               
                var CheckUserExist = data.Where(x => (x.Username.ToLower() == rqModel.Staffusername.ToLower() || x.Staff_id_number.ToLower() == rqModel.Staffidnumber) && x.Staff_id == rqModel.Staffid).ToList();
              
                if (CheckUserExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Staff with Username {rqModel.Staffusername} already exist with Staff Id Number {rqModel.Staffidnumber}"
                    };
                    return res;
                }
                else
                {
                    IList<QueryResEntity> Staff = conn.spGetData<QueryResEntity>(null, SpStaff.SpUpdateStaff(rqModel));
                    return Staff.First();
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

        public QueryResEntity UpdateStatusStaff(RequestStaffStatusModel rqModel)
        {
            try
            {
                var data = GetStaff(null).OrderByDescending(x => x.Staff_id).ToList();

                var CheckUserExist = data.Where(x => x.Staff_id == rqModel.Staffid).ToList();

                if (CheckUserExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Staff ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    IList<QueryResEntity> Staff = conn.spGetData<QueryResEntity>(null, SpStaff.SpUpdateStaffStatus(rqModel));
                    return Staff.First();
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

        public StaffEntity StaffLogin(RequestStaffLoginEntity rqModel)
        {
            try
            {
                var data = GetStaff(null).OrderByDescending(x => x.Staff_id).ToList();

                var CheckUserExist = data.Where(x => x.Username.ToLower() == rqModel.Staffusername.ToLower()).ToList();

                if (CheckUserExist.Count <= 0)
                {
                    throw new Exception("Username does not exist");
                }
                else
                {
                    if(CheckUserExist.Where(x => (bool)x.Is_first_time).ToList().Count() > 0){
                        throw new Exception("Please Change Password Before you login");
                    }
                    string password = UserUtils.ComputePasswordHash(rqModel.Password);
                    rqModel.Password = password;
                    IList<StaffEntity> Usersresp = conn.spGetData<StaffEntity>(null, SpStaff.SpGetStaffLogin(rqModel));
                    if(Usersresp.Count > 0)
                    {
                        return CheckUserExist[0];
                    }
                    throw new Exception("Invalid UserName or PassWord");
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

        public QueryResEntity StaffChangePassword(RequestStaffpassChangeModel rqModel)
        {
            try
            {
                var data = GetStaff(null).OrderByDescending(x => x.Staff_id).ToList();

                var CheckUserExist = data.Where(x => x.Staff_id == rqModel.Staffid).ToList();

                if (CheckUserExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Staff ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    string password = UserUtils.ComputePasswordHash(rqModel.Oldpassword);
                    string newpassword = UserUtils.ComputePasswordHash(rqModel.Staffpassword);

                    if (CheckUserExist.Where(x => x.Staff_password == password).ToList().Count() <= 0)
                    {
                        QueryResEntity res = new()
                        {
                            Code = Codes.BadRequest,
                            Msg = $"Old Password is Invalid"
                        };
                        return res;
                    }else if(password == newpassword)
                    {
                        QueryResEntity res = new()
                        {
                            Code = Codes.BadRequest,
                            Msg = $"Please use different New Password"
                        };
                        return res;
                    }
                    rqModel.Staffpassword = newpassword;
                    IList<QueryResEntity> Staff = conn.spGetData<QueryResEntity>(null, SpStaff.SpChangePassword(rqModel));
                    return Staff.First();
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

        public QueryResEntity StaffResetPassword(RequestStaffResetpassChangeModel rqModel)
        {
            try
            {
                var data = GetStaff(null).OrderByDescending(x => x.Staff_id).ToList();

                var CheckUserExist = data.Where(x => x.Staff_id == rqModel.Staffid).ToList();

                if (CheckUserExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Staff ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    string newpassword = UserUtils.ComputePasswordHash(rqModel.Staffpassword);

                    rqModel.Staffpassword = newpassword;
                    IList<QueryResEntity> Staff = conn.spGetData<QueryResEntity>(null, SpStaff.SpResetPassword(rqModel));
                    return Staff.First();
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

        public QueryResEntity StaffChangePasswordOnLogin(RequestStaffpassChangeModel rqModel)
        {
            try
            {
                var data = GetStaff(null).OrderByDescending(x => x.Staff_id).ToList();

                var CheckUserExist = data.Where(x => x.Staff_id == rqModel.Staffid).ToList();

                if (CheckUserExist.Count <= 0)
                {
                    QueryResEntity res = new()
                    {
                        Code = Codes.BadRequest,
                        Msg = $"Staff ID doesn't Exist"
                    };
                    return res;
                }
                else
                {
                    string password = UserUtils.ComputePasswordHash(rqModel.Oldpassword);
                    string newpassword = UserUtils.ComputePasswordHash(rqModel.Staffpassword);

                    if (CheckUserExist.Where(x => x.Staff_password == password).ToList().Count() <= 0)
                    {
                        QueryResEntity res = new()
                        {
                            Code = Codes.BadRequest,
                            Msg = $"Old Password is Invalid"
                        };
                        return res;
                    }
                    else if (password == newpassword)
                    {
                        QueryResEntity res = new()
                        {
                            Code = Codes.BadRequest,
                            Msg = $"Please use different New Password"
                        };
                        return res;
                    }
                    rqModel.Staffpassword = newpassword;
                    IList<QueryResEntity> Staff = conn.spGetData<QueryResEntity>(null, SpStaff.SpChangePasswordOnFirstLogin(rqModel));
                    return Staff.First();
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