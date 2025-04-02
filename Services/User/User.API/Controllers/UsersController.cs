using User.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Domain.DTO;
using User.Application.Features.Orders;
using LoginUserCommand = User.Application.Features.Orders.LoginUserCommand;

namespace User.API.Controllers
{
    public class UsersController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{nickName}")]
        public async Task<ActionResult<UserResponse>> GetUser([FromRoute] GetUserQuery query)
        {
            var result = await _mediator.Send((query));
            return Ok(result);
        }

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

