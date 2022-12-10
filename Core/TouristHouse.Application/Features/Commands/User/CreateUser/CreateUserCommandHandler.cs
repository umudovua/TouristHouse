using MediatR;
using TouristHouse.Application.Abstractions.Services.User;
using TouristHouse.Application.Dtos.User;

namespace TouristHouse.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Name=request.Name,
                Email=request.Email,
                PhoneNumber=request.PhoneNumber,
                Password=request.Password,
                PasswordConfirm=request.PasswordConfirm
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}
