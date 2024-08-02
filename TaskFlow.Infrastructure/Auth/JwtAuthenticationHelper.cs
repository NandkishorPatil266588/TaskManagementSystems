using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Infrastructure.Auth
{
    public class JwtAuthenticationHelper
    {
        public static string CreateToken(UserData userInfo, IConfiguration _config)
        {

            List<Claim> claims = new List<Claim>
             {
              new Claim(ClaimTypes.Email,userInfo.EmpEmailId),
              new Claim(ClaimTypes.Role, userInfo.EmpRole),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(100),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
