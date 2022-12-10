using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Abstractions.Token;
using TouristHouse.Domain.Entites;
using static System.Net.Mime.MediaTypeNames;

namespace TouristHouse.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly UserManager<AppUser> _userManager;

        public TokenHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Application.Models.Token> CreateAccessTokenAsync(AppUser user)
        {
            Application.Models.Token token = new();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var secretkey = Configuration.GetSecretKey;

            SymmetricSecurityKey key =
                    new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretkey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            token.Expiration = DateTime.UtcNow.AddDays(7);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,

                Issuer = "https://localhost:44329",
                Audience = "https://localhost:44329",
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenS = tokenHandler.CreateToken(tokenDescriptor);

            JwtSecurityTokenHandler TokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(tokenS);

            token.RefreshToken = CreateRefreshToken();
            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
