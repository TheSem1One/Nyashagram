using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Profile;
using User.Application.Features.Users;
using User.Domain.DTO;
using User.Domain.DTO.Profile;
using User.Domain.DTO.Users;

namespace User.API.Controllers
{
    public class UsersController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{nickName}")]
        public async Task<ActionResult<GetUserDto>> GetUserByNickName([FromRoute] string nickName)
        {
            var query = new GetUsersByNickNameQuery { NickName = nickName };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("find={nickName}")]
        public async Task<ActionResult<IEnumerable<FindDto>>> FindUsers([FromRoute] string nickName)
        {
            var query = new FindUsersQuery { NickName = nickName };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPatch("subscribe")]
        public async Task<ActionResult<bool>> Subscribe([FromBody] SubscribeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch("unsubscribe")]
        public async Task<ActionResult<bool>> Unsubscribe([FromBody] UnsubscribeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
