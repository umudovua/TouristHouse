using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TouristHouse.Application.Abstractions.Services.User;
using TouristHouse.Application.Abstractions.Token;
using TouristHouse.Application.Dtos.User;
using TouristHouse.Application.Models;
using TouristHouse.Domain.Entites;

namespace TouristHouse.Persistence.Services.User
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userService;
        readonly ITokenHandler _tokenHandler;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IUserService userService, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public async Task<Token> LoginAsync(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.PhoneNumberOrEmail);
            if (user == null)
                user = await _userManager.FindByNameAsync(loginDto.PhoneNumberOrEmail);

            if (user == null)
                throw new Exception("Authentication error");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
            await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
            if (result.Succeeded)
            {
                Token token = await _tokenHandler.CreateAccessTokenAsync(user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 7);
                return token;
            }

            throw new Exception("Authentication error");
        }


        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = await _tokenHandler.CreateAccessTokenAsync(user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 7);
                return token;
            }
            else
                throw new Exception("User Not Found");
        }


        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true;

        }

        public async Task<SignInResult> LoginMvcAsync(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.PhoneNumberOrEmail);
            if (user == null)
                user = await _userManager.FindByNameAsync(loginDto.PhoneNumberOrEmail);
            if (user == null)
                throw new Exception("User Not Found");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
            await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
            return result;
        }
    }
}
