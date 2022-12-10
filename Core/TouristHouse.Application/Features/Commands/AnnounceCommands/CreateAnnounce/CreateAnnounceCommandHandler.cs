using MediatR;
using TouristHouse.Application.Abstractions.Services;

namespace TouristHouse.Application.Features.Commands.AnnounceCommands.CreateAnnounce
{
    public class CreateAnnounceCommandHandler : IRequestHandler<CreateAnnounceCommandRequest, CreateAnnounceCommandResponse>
    {
        private readonly IAnnounceService _announceService;

        public CreateAnnounceCommandHandler(IAnnounceService announceService)
        {
            _announceService = announceService;
        }

        public async Task<CreateAnnounceCommandResponse> Handle(CreateAnnounceCommandRequest request, CancellationToken cancellationToken)
        {
            var result= await _announceService.AddAsync(request.CreateAnnounceDto);
            CreateAnnounceCommandResponse response = new() { ResponseAnnounceDto = result };

            return response;
        }
    }
}
