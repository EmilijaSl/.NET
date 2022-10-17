using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GetJwtToken(string username, string role)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, username), //paimta is enumo
            new Claim(ClaimTypes.Role, role)
            };
            var secret = _configuration.GetSection("Database:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Database:Issuer").Value,
                audience: _configuration.GetSection("Database:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
