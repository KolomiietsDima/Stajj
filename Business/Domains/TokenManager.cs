using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Staj
{
    public class TokenManager
    {
        public static string GenerateToken(Users user,string ISSUER,string AUDIENCE,string KEY)
        {
            List<Claim> claimsIdentity = new List<Claim>();
            claimsIdentity.Add(new Claim(ClaimTypes.Name, user.Email));
            claimsIdentity.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
           

            var now = DateTime.UtcNow;
         
            
            var jwt = new JwtSecurityToken(
                    issuer: ISSUER,
                    audience: AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity,
                    expires: now.Add(TimeSpan.FromMinutes(55)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(KEY)), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;

        }



    }

}
