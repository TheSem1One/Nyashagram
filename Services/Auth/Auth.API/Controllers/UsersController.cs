using User.Application.Commands;
using User.Application.Queries;
using User.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Domain.DTO;

namespace User.API.Controllers
{
    public class UsersController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{nickName}")]
        public async Task<ActionResult<UserResponse>> GetUser([FromRoute] string nickName)
        {
            var query = new GetUserQuery(nickName);
            var result = await _mediator.Send((query));
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> CreateUser([FromBody] RegisterDto registerDto)
        {
            var command = new CreateUserCommand(registerDto.NickName, registerDto.Email, registerDto.Password);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> LoginUser([FromBody] LoginDto loginDto)
        {
            var command = new LoginUserCommand(loginDto.Email, loginDto.Password);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

