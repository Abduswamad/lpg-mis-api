using Gas.Domain.Entity.CompanyManagement;
using Gas.Utils.Settings;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
                            new Claim(ClaimTypes.Name, result.StaffDetails.Username),
                            new Claim(ClaimTypes.Email, result.StaffDetails.Email),
                            new Claim(ClaimTypes.GivenName, result.StaffDetails.First_name),
                            new Claim(ClaimTypes.Surname, result.StaffDetails.Last_name),
                            new Claim(ClaimTypes.StreetAddress, result.StaffDetails.Common_street_name),
                            new Claim(ClaimTypes.MobilePhone, result.StaffDetails.Phone_number),
                            new Claim(ClaimTypes.Role, JsonConvert.SerializeObject(result.StaffRole)),
                            new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(result)),
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
