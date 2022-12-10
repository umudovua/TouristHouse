using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouristHouse.Application.Features.Commands.AnnounceCommands.CreateAnnounce;
using TouristHouse.Application.Features.Queries.Announce.GetByIdAnnounce;

namespace TouristHouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnounceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnnounceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult>Create(CreateAnnounceCommandRequest createAnnounceCommandRequest)
        {
            CreateAnnounceCommandResponse response = await _mediator.Send(createAnnounceCommandRequest);

            return Ok(response);
        }


        [HttpGet("item")]
        public async Task<IActionResult>GetById(GetByIdAnnounceQueryRequest getByIdAnnounceQueryRequest)
        {
            GetByIdAnnounceQueryResponse response = await _mediator.Send(getByIdAnnounceQueryRequest);

            return Ok(response);
        }
    }
}
