using ContactBook.Core.Interfaces;
using ContactBook.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Implementations
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly UserManager<User> _userManager;

        public TokenGenerator(IServiceProvider service)
        {
            _userManager = service.GetRequiredService<UserManager<User>>();
        }
       

        public async Task<string> GenerateToken(User user, IConfiguration _configuration)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var siginingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:SecretKey"]));

            var token = new JwtSecurityToken
                (audience: _configuration["JWTSettings:Audience"],
                issuer: _configuration["JWTSettings:Issuer"],
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: new SigningCredentials(siginingKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
