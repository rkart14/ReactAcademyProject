using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.Infrastructure.Interfaces;
using RestaurantManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Helpers
{
    public class JwtSecurityTokenGenerator : IJwtSecurityTokenGenerator
    {
        private readonly IOptions<TokenSettings> _options;
        public JwtSecurityTokenGenerator(IOptions<TokenSettings> options)
        {
            _options = options;
        }
        public string Generate(List<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_options.Value.ExpirationTimeInMinutes),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }

}
