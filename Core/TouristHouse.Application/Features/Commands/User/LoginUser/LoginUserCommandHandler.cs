using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Abstractions.Services.User;

namespace TouristHouse.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _authService.LoginAsync(new()
                {
                    PhoneNumberOrEmail = request.PhoneNumberOrEmail,
                    Password = request.Password
                });

                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };
            }
            catch (Exception ex)
            {
                return new LoginUserErrorCommandResponse()
                {
                    Message = ex.Message
                };
            }

        }
    }
}
