using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Abstractions.Services;

namespace TouristHouse.Application.Features.Queries.Announce.GetByIdAnnounce
{
    public class GetByIdAnnounceQueryHandler : IRequestHandler<GetByIdAnnounceQueryRequest, GetByIdAnnounceQueryResponse>
    {
        private readonly IAnnounceService _announceService;

        public GetByIdAnnounceQueryHandler(IAnnounceService announceService)
        {
            _announceService = announceService;
        }

        public async Task<GetByIdAnnounceQueryResponse> Handle(GetByIdAnnounceQueryRequest request, CancellationToken cancellationToken)
        {
            var model = await _announceService.GetSingleAsync(request.Id);
            return new() { ResponseAnnounceDto = model };
        }
    }
}
