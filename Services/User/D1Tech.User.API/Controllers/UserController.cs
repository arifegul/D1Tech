using D1Tech.User.Application.Commands.UserCommands;
using D1Tech.User.Application.Queries.UserQueries;
using D1Tech.User.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D1Tech.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : CustomBaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var response = await _mediator.Send(query);

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await _mediator.Send(new GetAllUserQuery());

            return CreateActionResultInstance(response);
        }
    }
}
