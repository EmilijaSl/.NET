using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pamoka11JWT.Services
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


            var secret = _configuration.GetSection("JWT:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("JWT:Issuer").Value,
                audience: _configuration.GetSection("JWT:Audience").Value,
                claims: claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
