using Gas.Domain.Entity.CompanyManagement;
using Gas.Utils.Settings;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gas.Services
{
    public class Authentication 
    {

        public string Token_Authentication(StaffLoginEntity result)
        {
            try
            {
                // 1. Create Security Token Handler
                var tokenHandler = new JwtSecurityTokenHandler();

                // 2. Create Private Key to Encrypted
                var tokenKey = Encoding.ASCII.GetBytes(ServiceSettings.GetWorkerServiceSettings().Jwt.Key);

                //3. Create JETdescriptor
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim("Name", result.StaffDetails.Username),
                            new Claim("Email", result.StaffDetails.Email),
                            new Claim("GivenName", result.StaffDetails.First_name),
                            new Claim("Surname", result.StaffDetails.Last_name),
                            new Claim("StreetAddress", result.StaffDetails.Common_street_name),
                            new Claim("MobilePhone", result.StaffDetails.Phone_number),
                            new Claim("Role", JsonConvert.SerializeObject(result.StaffRole)),
                            new Claim("UserData", JsonConvert.SerializeObject(result.StaffDetails)),
                        }),
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                //4. Create Token
                var token = tokenHandler.CreateToken(tokenDescriptor);

                // 5. Return Token from method
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
