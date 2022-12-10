using TouristHouse.Application.Dtos.User;
using TouristHouse.Domain.Entites;

namespace TouristHouse.Application.Abstractions.Services.User
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task CreateRoleAsync();
    }
}
