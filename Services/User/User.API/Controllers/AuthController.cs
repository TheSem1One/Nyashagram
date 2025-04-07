using User.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Auth;
using LoginUserCommand = User.Application.Features.Auth.LoginUserCommand;

namespace User.API.Controllers
{
    public class AuthController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> LoginUser([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

