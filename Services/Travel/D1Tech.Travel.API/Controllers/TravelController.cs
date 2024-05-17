using D1Tech.Travel.Application.Commands.TravelCommands;
using D1Tech.Travel.Application.Queries.TravelQueries;
using D1Tech.Travel.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D1Tech.Travel.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController(IMediator mediator) : CustomBaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("CreateTravel")]
        public async Task<IActionResult> CreateTravel(CreateTravelCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetTravelById")]
        public async Task<IActionResult> GetTravelById(int id)
        {
            var response = await _mediator.Send(new GetTravelByIdQuery(id));

            return CreateActionResultInstance(response);
        }

        [HttpPost("UpdateTravel")]
        public async Task<IActionResult> UpdateTravel(UpdateTravelCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("DeleteTravel")]
        public async Task<IActionResult> DeleteTravel(DeleteTravelCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetAllTravel")]
        public async Task<IActionResult> GetAllTravel()
        {
            var response = await _mediator.Send(new GetAllTravelQuery());

            return CreateActionResultInstance(response);
        }
    }
}
