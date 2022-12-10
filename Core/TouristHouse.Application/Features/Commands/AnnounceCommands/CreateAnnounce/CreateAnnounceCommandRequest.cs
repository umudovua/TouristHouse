using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Dtos.AnnounceDto;

namespace TouristHouse.Application.Features.Commands.AnnounceCommands.CreateAnnounce
{
    public class CreateAnnounceCommandRequest:IRequest<CreateAnnounceCommandResponse>
    {
        public CreateAnnounceDto? CreateAnnounceDto { get; set; }
    }
}
