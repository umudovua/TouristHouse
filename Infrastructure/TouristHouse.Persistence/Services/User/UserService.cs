using Microsoft.AspNetCore.Identity;
using TouristHouse.Application.Abstractions.Services.User;
using TouristHouse.Application.Dtos.User;
using TouristHouse.Domain.Entites;

namespace TouristHouse.Persistence.Services.User
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            AppUser user = new()
            {
                Name=model.Name,
                UserName = model.PhoneNumber,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            await _userManager.AddToRoleAsync(user, AppRole.Member.ToString());
            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "The user has been successfully created.";
            }

            else
            {
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";
            }


            return response;
        }

        

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddDays(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception("User Not Found");
        }

        public async Task CreateRoleAsync()
        {
            foreach (var item in Enum.GetValues(typeof(AppRole)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
                }
            };
        }
    }   
}
