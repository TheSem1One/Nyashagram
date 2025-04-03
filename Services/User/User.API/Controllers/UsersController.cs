using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Profile;
using User.Domain.DTO;

namespace User.API.Controllers
{
    public class UsersController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{nickName}")]
        public async Task<ActionResult<UserDto>> GetProfile([FromRoute] string nickName)
        {
            var query = new GetProfileQuery { NickName = nickName };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPatch]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateProfileCommand command)
        {
            var result = await _mediator.Send((command));
            return Ok(result);
        }

        [HttpPatch("subscribe")]
        public async Task<ActionResult<bool>> Subscribe([FromBody] SubscribeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
