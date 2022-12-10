using TouristHouse.Application.Dtos.User;

namespace TouristHouse.Application.Abstractions.Services.User
{
    public interface IInternalAuthentication
    {
        Task<Models.Token> LoginAsync(LoginDto loginDto);
        Task<Models.Token> RefreshTokenLoginAsync(string refreshToken);
        Task<Microsoft.AspNetCore.Identity.SignInResult> LoginMvcAsync(LoginDto loginDto);
        Task<bool> Logout();
    }
}
