using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Common
{
    public class JWT_Token
    {

        public static string GenerateJSONWebToken(string EmailId, string SecretKey)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var signCred = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new ClaimsIdentity(new Claim[] {
            new Claim ("Email",EmailId)
            });

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {

                Issuer = "Test",
                Audience = "Test",
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signCred
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
