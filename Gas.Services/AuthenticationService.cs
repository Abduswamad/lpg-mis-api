using Gas.Domain.Entity.CompanyManagement;
using Gas.Utils.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gas.Services
{
    public class Authentication 
    {
        public static string TokenAuthentication(StaffLoginEntity result)
        {
            try
            {
                // 1. Create Security Token Handler
                var tokenHandler = new JwtSecurityTokenHandler();

                // 2. Create Private Key to Encrypted
                var tokenKey = Encoding.ASCII.GetBytes(ServiceSettings.GetWorkerServiceSettings().Jwt.Key);

                var claims = new List<Claim>();

                foreach (var property in typeof(StaffEntity).GetProperties())
                {
                    claims.Add(new Claim(property.Name, property.GetValue(result.StaffDetails)?.ToString() ?? ""));
                }

                if (result.StaffRole != null)
                {
                    foreach (var role in result.StaffRole)
                    {
                        claims.Add(new Claim("role", role.Role_name));
                    }
                }

               // claims.Add(new Claim("UserData", JsonConvert.SerializeObject(result.StaffDetails)));


                //3. Create JETdescriptor
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
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
                Logger.Logger.Error($"Error sending email: {ex.Message}");
                return ex.Message;
            }

        }
    }
}
