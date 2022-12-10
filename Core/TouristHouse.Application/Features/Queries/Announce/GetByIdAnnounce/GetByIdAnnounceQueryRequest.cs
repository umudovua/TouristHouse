using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristHouse.Application.Features.Queries.Announce.GetByIdAnnounce
{
    public class GetByIdAnnounceQueryRequest:IRequest<GetByIdAnnounceQueryResponse>
    {
        public string? Id { get; set; }
    }
}
