using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HireMeAPI.BLL.Services
{
    public class TokentService:ITokenService
    {
        private readonly IConfiguration _config;

        public TokentService(IConfiguration config)
        {
            _config = config;
        }
        public string CreateToken(User user)
        {

            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtSecret")!));
            var signingCreds = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha512);


            var Claims = new List<Claim>(){

                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email??""),
                new Claim(ClaimTypes.Role,"user")

            };

            var token = new JwtSecurityToken("HireMeAPI", "client", Claims, expires: DateTime.Now.AddHours(2), signingCredentials: signingCreds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
