﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TouristHouse.Application.Abstractions.Token;
using TouristHouse.Domain.Entites;

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
                new Claim("PhoneNumber", user.PhoneNumber),
            };
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var secretkey = Configuration.GetSecretKey;

            SymmetricSecurityKey key =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            token.Expiration = DateTime.UtcNow.AddDays(7);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,

                Issuer = "https://localhost:7045",
                Audience = "https://localhost:7045",
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
