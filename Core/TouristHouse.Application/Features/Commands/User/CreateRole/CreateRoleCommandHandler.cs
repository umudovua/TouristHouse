using MediatR;
using TouristHouse.Application.Abstractions.Services.User;

namespace TouristHouse.Application.Features.Commands.User.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        readonly IUserService _userService;

        public CreateRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.CreateRoleAsync();

            return new()
            {
                Message = "Has been succesfull"
            };
        }
    }
}
